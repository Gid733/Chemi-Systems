using ChemiSystems.Infrastructure;
using ChemiSystems.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemiSystems.Controllers
{
    public class CatalogueController : Controller
    {
        ChemiContext db = new ChemiContext();
        // GET: Catalogue
        public ActionResult Index()
        {

            Product user1 = new Product
            {
                Id = new Guid(),
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Tom",
                VendorCode = "ss",
                DescriptionMain = "",
                DescriptionSecondary = "",
                Price = 33.44
            };
            // добавляем их в бд
            db.Products.Add(user1);
            db.SaveChanges();
            var users = db.Products;

            return View();
        }
    }
}