using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using ChemiSystems.Infrastructure;
using ChemiSystems.Infrastructure.Entities;
using ChemiSystems.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ChemiSystems.Controllers
{
    public class AccountProfileController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: AccountProfile/Orders/
        [Authorize]
        public ActionResult Orders()
        {
            //get current user and get his orders from db
            var currentUser = User.Identity.GetUserId();
            var userOrders = _db.Orders
                .Include("ProductsInOrder")
                .Include("ProductsInOrder.ProductImage")
                .Include("OrderStatus")               
                .Where(a => a.OrderedBy == currentUser && !a.OrderStatus.Status.Equals("Deleted")).ToList();

            return View(userOrders);
        }

        //POST: /AccountProfile/DeleteOrder
        [Authorize]
        public ActionResult DeleteOrder (Guid orderId)
        {
            //select all orders with current order id and status Archived
            var currentOrder = _db.Orders
                .Include("OrderStatus")
                .FirstOrDefault(a => a.Id == orderId && a.OrderStatus.Status.Equals("Archived"));
            var currentUser = User.Identity.GetUserId();

            //if anything in current order and order id== user id - allow delete
            if (currentOrder != null && currentOrder.OrderedBy.Equals(currentUser))
            {
                currentOrder.OrderStatus.Status = "Deleted";
                _db.SaveChanges();
            }
            else
            {
                return View("Error");
            }
            return RedirectToAction("Orders");
        }

        // GET: AccountProfile/Messages/
        [Authorize]
        public ActionResult Messages(Guid orderId)
        {
            //check if user have that order
            var currentUser = GetUserData();
            var userOrder = _db.Orders.FirstOrDefault(a => a.OrderedBy.Equals(currentUser.Id));
            if (userOrder == null)
            {
                return View("Error");
            }
            //find current order by guid
            var currentOrder = _db.Orders.Include("OrderMessages").FirstOrDefault(a => a.Id.Equals(orderId));
            List<MessageViewModel> messages = new List<MessageViewModel>();

            //if current order inst null - add all messages by user to list in current order
            if (currentOrder != null)
                messages.AddRange(from a in currentOrder.OrderMessages
                    let senderUser = _db.Users.FirstOrDefault(x => x.Id.Equals(a.UserId.ToString()))
                    select new MessageViewModel()
                    {
                        MessageContent = a.Content,
                        MessageDate = a.DateSend,
                        SenderFullName = senderUser.FirstName + " " + senderUser.LastName
                    });
            else
            {
                return View("Error");
            }

            ViewBag.OrderId = currentOrder.Id;

            return View(messages);
        }

        // POST: AccountProfile/AddMessage/
        [Authorize]
        [HttpPost]
        public ActionResult AddMessage(Guid orderId, string messageContent)
        {
            //check if user have that order
            var currentUser = GetUserData();
            var userOrder = _db.Orders.FirstOrDefault(a => a.OrderedBy.Equals(currentUser.Id));
            if (userOrder == null)
            {
                return View("Error");
            }

            var currentOrder = _db.Orders.Include("OrderMessages").FirstOrDefault(a => a.Id.Equals(orderId));

            currentOrder?.OrderMessages.Add(new OrderMessage()
            {
                Content = messageContent,
                UserId = Guid.Parse(currentUser.Id)
            });

            _db.SaveChanges();

            if (currentOrder != null)
                return RedirectToAction("Messages", new {orderId});
            else
            {
                return View("Error");
            }
        }

        // GET: AccountProfile/Settings
        [Authorize]
        public ActionResult Settings()
        {
            var userData = GetUserData();
            var userSettings = new UserSettingsModel()
            {
                Country = userData.Country,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Street = userData.Street,
                ZipCode = userData.ZipCode
            };

            return View(userSettings);
        }

        // POST: AccountProfile/SaveSettings
        [Authorize]
        [HttpPost]
        public ActionResult SaveSettings(UserSettingsModel model)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userData = GetUserData();
            userData.FirstName = model.FirstName;
            userData.LastName = model.LastName;
            userData.Country = model.Country;
            userData.Street = model.Street;
            userData.ZipCode = model.ZipCode;
            manager.Update(userData);
            System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
            return View("Settings");
        }

        private ApplicationUser GetUserData()
        {
            var userData = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(User.Identity.GetUserId());
            return userData;
        }        
    }
}