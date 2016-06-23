using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Infrastructure;
using ChemiSystems.Models;
using Microsoft.AspNet.Identity;

namespace ChemiSystems.Controllers
{
    public class AccountProfileController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: AccountProfile/Orders/
        [Authorize]
        public ActionResult Orders()
        {
            //get current user and get his orders from db
            var currentUser = User.Identity.GetUserId();
            var userOrders = db.Orders
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
            var currentOrder = db.Orders
                .Include("OrderStatus")
                .FirstOrDefault(a => a.Id == orderId && a.OrderStatus.Status.Equals("Archived"));
            var currentUser = User.Identity.GetUserId();

            //if anything in current order and order id== user id - allow delete
            if (currentOrder != null && currentOrder.OrderedBy.Equals(currentUser))
            {
                currentOrder.OrderStatus.Status = "Deleted";
                db.SaveChanges();
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
            return View();
        }
    }
}