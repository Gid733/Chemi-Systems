using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Helpers;
using ChemiSystems.Infrastructure;
using ChemiSystems.Infrastructure.Entities;
using Microsoft.AspNet.Identity;

namespace ChemiSystems.Controllers
{
    public class OrderController : Controller
    {
        ChemiContext db = new ChemiContext();

        // GET: Order
        public ActionResult Index(string jsonLocalStorageObj)
        {
            var products = StorageHelper.GetProductsLocal(jsonLocalStorageObj, db);

            if (products == null)
            {
                return PartialView("Error");
            }

            List<ProductInOrder> productsInOrder = new List<ProductInOrder>();
            
            foreach (var p in products)
            {
                ProductInOrder productInOrder = new ProductInOrder()
                {
                    Id = new Guid(),
                    Name = p.Product.Name,
                    VendorCode = p.Product.VendorCode,
                    DescriptionMain = p.Product.DescriptionMain,
                    DescriptionSecondary = p.Product.DescriptionSecondary,
                    Price = p.Product.Price,
                    Amount = p.Amount,
                    ProductImageId = p.Product.ProductImageId,
                    ProductImage = p.Product.ProductImage,
                    ProductCategoryId = p.Product.ProductCategoryId,
                    ProductCategory = p.Product.ProductCategory,
                    ChangedBy = p.Product.ChangedBy,
                    CreatedBy = p.Product.CreatedBy,
                    CreatedDate = p.Product.CreatedDate,
                    ChangedDate = p.Product.ChangedDate,
                };
                

                productsInOrder.Add(productInOrder);
            }

            Order order = new Order()
            {
                ProductsInOrder = productsInOrder
            };

            db.Orders.Add(order);
            db.SaveChanges();
            
            return View("Checkout");
        }
    }
}