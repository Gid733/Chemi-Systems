using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Helpers;
using ChemiSystems.Infrastructure.Entities;
using ChemiSystems.Infrastructure;
using ChemiSystems.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChemiSystems.Controllers
{
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart       
        public ActionResult Index()
        {           
            return View("Cart");
        }

        public ActionResult GetCart(string jsonLocalStorageObj)
        {
            var products = StorageHelper.GetProductsLocal(jsonLocalStorageObj, db);
            if (products == null)
            {
                return PartialView("Error");
            }
            
            //Check if list empty
            if (!products.Any())
                return PartialView("_EmptyCartPartial");
             
            return PartialView("_ProductsInCartPartial", products);
        }

        //get products from localstorage
    }
}