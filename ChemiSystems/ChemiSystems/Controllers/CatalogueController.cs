using ChemiSystems.Infrastructure;
using ChemiSystems.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ChemiSystems.Controllers
{
    public class PageInfo
        {
            public int PageNumber { get; set; } // номер текущей страницы
            public int PageSize { get; set; } // кол-во объектов на странице
            public int TotalItems { get; set; } // всего объектов

            public int TotalPages // всего страниц
                => (int)Math.Ceiling((decimal)TotalItems / PageSize);
        }
    public class CatalogueController : Controller
    {
        ChemiContext db = new ChemiContext();

        
        // GET: Catalogue
        public ActionResult Index()
        {           
            var users = db.Products;
            return View("Catalogue");
        }

        public ActionResult GetSidebar()
        {
            var categories = db.ProductCategories.ToList();
            return PartialView("~/Views/Catalogue/_CatalogueSidebarPartial.cshtml", categories);
        }

        public ActionResult GetProducts(Guid? id)
        {
            List<Product> products;
            if (id.HasValue)
            {
                products = db.Products
                    .Include("ProductImage")
                    .Include("ProductCategory")
                    .Where(a => a.ProductCategoryId == id.Value)
                    .ToList();
            }
            else
            {
                products = db.Products.Include("ProductImage").ToList();
            }
            return PartialView("~/Views/Catalogue/_CatalogueProductsPartial.cshtml", products);
        }
    }
}
/*
 
     */
