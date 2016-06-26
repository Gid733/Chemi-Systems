using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Models;

namespace ChemiSystems.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {          
            var topSells = _db.Products
                .Include("ProductImage")
                .OrderBy(r => Guid.NewGuid())
                .Take(3)
                .ToList();

            return View(topSells);
        }        
    }
}