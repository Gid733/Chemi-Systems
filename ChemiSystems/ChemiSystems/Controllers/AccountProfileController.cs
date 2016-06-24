using System;
using System.Collections.Generic;
using System.Linq;
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
            var user = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(User.Identity.GetUserId());

            var userSettings = new UserSettingsModel()
            {
                Country = user.Country,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Street = user.Street,
                ZipCode = user.ZipCode
            };

            return View(userSettings);
        }

        // POST: AccountProfile/SaveSettings
        [Authorize]
        [HttpPost]
        public ActionResult SaveSettings()
        {
            return View("Settings");
        }
    }
}