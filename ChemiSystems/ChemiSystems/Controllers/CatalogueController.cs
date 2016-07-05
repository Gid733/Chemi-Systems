using ChemiSystems.Infrastructure;
using ChemiSystems.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Models;
using PagedList;

namespace ChemiSystems.Controllers
{
    public class CatalogueController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        
        // GET: Catalogue
        public ActionResult Index()
        {           
            var users = _db.Products;
            return View("Catalogue");
        }        

        //GET: /Catalogue/Sidebar (partial)
        public ActionResult GetSidebar()
        {           
            var categories = _db.ProductCategories.ToList();
            return PartialView("~/Views/Catalogue/_CatalogueSidebarPartial.cshtml", categories);
        }

        //GET: /Catalogue/Products (partial)
        public ActionResult GetProducts(Guid? id)
        {
            
            List<Product> products;
            if (id.HasValue)
            {
                products = _db.Products
                    .Include("ProductImage")
                    .Include("ProductCategory")
                    .Where(a => a.ProductCategoryId == id.Value)
                    .ToList();
            }
            else
            {
                products = _db.Products.Include("ProductImage").ToList();
            }
            return PartialView("~/Views/Catalogue/_CatalogueProductsPartial.cshtml", products);
        }

        //GET: /Catalogue/Product (single product)
        public ActionResult Product(string vendorCode)
        {
            Product product = _db.Products
                .Include("ProductImage")
                .Include("ProductCategory")
                .FirstOrDefault(a => a.VendorCode.Equals(vendorCode));
            if (product == null)
            {
                Response.StatusCode = 404;
                return View("Error");
            }            
            return View("Product", product);
        }
    }
}
