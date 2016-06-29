using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Infrastructure.Entities;
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

        [HttpPost]
        public HttpStatusCodeResult Feedback(string email, string content)
        {
            Feedback feedback = new Feedback()
            {
                Email = email,
                Content = content
            };

            try
            {
                _db.Feedbacks.Add(feedback);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }            
            return new HttpStatusCodeResult(HttpStatusCode.Accepted);
        }
    }
}