using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Infrastructure.Entities;
using ChemiSystems.Infrastructure;
using ChemiSystems.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChemiSystems.Controllers
{
    public class CartController : Controller
    {
        ChemiContext db = new ChemiContext();
        // GET: Cart       
        public ActionResult Index()
        {           
            return View("Cart");
        }

        public ActionResult GetCart(string jsonLocalStorageObj)
        {
            var obj = JObject.Parse(jsonLocalStorageObj);
            Dictionary<Guid, int> dict = new Dictionary<Guid, int>();
            try
            {
                dict = obj.ToObject<Dictionary<Guid, int>>();
            }
            catch (JsonReaderException)
            {
                return PartialView("Error");
            }

            //Creating product list from base by Id
            List<ProductInCartViewModel> productList = dict.Select(d => new ProductInCartViewModel
            {
                Product = db.Products.Include("ProductImage").Include("ProductCategory").FirstOrDefault(a => a.Id == d.Key), Amount = d.Value
            }).ToList();
            if (jsonLocalStorageObj == null) throw new ArgumentNullException(nameof(jsonLocalStorageObj));

            //Check if list empty
            if (!productList.Any())
                return PartialView("_EmptyCartPartial");
             
            return PartialView("_ProductsInCartPartial", productList);
        }
    }
}