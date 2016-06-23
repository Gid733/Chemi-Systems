using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Helpers;
using ChemiSystems.Infrastructure;
using ChemiSystems.Infrastructure.Entities;
using ChemiSystems.Models;
using Microsoft.AspNet.Identity;

namespace ChemiSystems.Controllers
{
    public class OrderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Order
        public ActionResult Index(Guid? id)
        {
            var order = db.Orders.FirstOrDefault(a => a.Id == id);
            if (order == null)
            {
                return View("Error");
            }

            return View("Checkout", order);
        }

        public Guid? GetOrder(string jsonLocalStorageObj)
        {
            var products = StorageHelper.GetProductsLocal(jsonLocalStorageObj, db);
            var currentUser = User.Identity.GetUserId();
            if (products == null)
            {
                return null;
            }

            List<ProductInOrder> productsInOrder = products.Select(p => new ProductInOrder()
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
            }).ToList();
           
            Order order = new Order()
            {
                CreatedDate = DateTime.Now,
                ChangedDate = DateTime.Now,
                DeliverToDate = DateTime.Now,
                DeliverToAddress = "",
                OrderedBy = currentUser,
                ProductsInOrder = productsInOrder,
                OrderStatus = new OrderStatus()
            };

            db.Orders.Add(order);
            db.SaveChanges();

            return order.Id;
        }
    }
}