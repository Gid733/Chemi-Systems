using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Infrastructure;
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
        public ActionResult Messages()
        {
            return View();
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