using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Infrastructure;
using ChemiSystems.Infrastructure.Entities;

namespace ChemiSystems.Controllers
{
    public class ProductController : Controller
    {
        ChemiContext db = new ChemiContext();
        // GET: Product
        public ActionResult Index(string vendorCode)
        {
            if (vendorCode == null) return null;
            Product product = db.Products
                .Include("ProductImage")
                .Include("ProductCategory")
                .FirstOrDefault(a => a.VendorCode.Equals(vendorCode));            
            ////    from p in db.Products.Include("ProductImage")
            ////              .Where(p => p.VendorCode == vendorCode)
            ////              select p;
            return View("Index", product);
        }
    }
}