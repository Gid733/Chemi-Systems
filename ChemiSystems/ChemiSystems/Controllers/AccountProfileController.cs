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
            var currentUser = User.Identity.GetUserId();
            var userOrders = db.Orders
                .Include("ProductsInOrder")
                .Include("ProductsInOrder.ProductImage")
                .Include("OrderStatus")               
                .Where(a => a.OrderedBy == currentUser).ToList();

            return View(userOrders);
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