using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ChemiSystems.Helpers;
using ChemiSystems.Infrastructure;
using ChemiSystems.Infrastructure.Entities;
using ChemiSystems.Models;
using ChemiSystems.Models.Payment;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ChemiSystems.Controllers
{
    public class OrderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // Checkout
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

        // POST: Refill/SendRefill
        //[HttpPost]
        //[Authorize]
        //public ActionResult Checkout(LiqPayModel model, Guid orderId)
        //{
            //var order = db.Orders.FirstOrDefault(a => a.Id == orderId);

            ////If order not found - return error
            //if (order == null)
            //{
                //return View("Error");
            //}

            //// Get current user
            //var user = System.Web.HttpContext.Current.GetOwinContext()
                //.GetUserManager<ApplicationUserManager>()
                //.FindById(User.Identity.GetUserId());

            //// If we not get an user - return error 
            //if (user == null)
            //{
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //// if Amount invalid - return error
            //if (model.Amount <= 0 || model.Amount > 100000)
            //{
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //// Initialize a SHA256 hash object for orderid hash
            //Random rnd = new Random(DateTime.Now.Millisecond);
            //var rndstr = rnd.Next(1, 99999).ToString();
            //SHA512 shaM = new SHA512Managed();
            //byte[] orderHash =
                //shaM.ComputeHash(Encoding.UTF8.GetBytes(rndstr + user.Id + model.PublicKey + model.Amount));

            //// string representation (similar to UNIX format)
            //var orderHashString = BitConverter.ToString(orderHash)
                //// without dashes
                //.Replace("-", string.Empty).ToLower();

            //// Prepare liqpay model
            //model.ServerUrl = HttpContext.Request.Url?.Scheme + "://" + HttpContext.Request.Url?.Host +
                              //"/Order/Checkout";
            //model.OrderId = orderHashString;
            //model.Description = "Checkout for user order:" + user.FirstName + " " + user.LastName;

            //// Prepare JSON string
            //var json = "{ \"version\" : 3,\"public_key\" : \"" + model.PublicKey
                       //+ "\", \"action\" : \"pay\", \"amount\" : " + model.Amount
                       //+ ", \"server_url\" : \"" + model.ServerUrl
                       //+ "\", \"currency\" : \"UAH\",\"description\" : \"" + model.Description + "\",\"" +
                       //"+order_id\" : \"" + model.OrderId + "\"}";

            //// Create DATA
            //var data = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            //// Create Signature
            //var signatureSource = model.PrivateKey + data + model.PrivateKey;
            //var signature = Convert.ToBase64String(SHA1.Create().ComputeHash(
                //Encoding.UTF8.GetBytes(signatureSource)));

            //// Send data to ViewBag
            //ViewBag.data = data;
            //ViewBag.signature = signature;

            //// Create PaymentTransaction model
            //var payment = new PaymentTransaction
            //{
                //UserId = Guid.Parse(user.Id),
                //OrderId = order.Id, 
                //OperationType = OperationType.AddMoney,
                //Amount = model.Amount,
                //PaymentAction = PaymentTransactionAction.Deposit,
                //PaymentStatus = PaymentTransactionStatus.Pending,
                //PaymentId = orderHashString
            //};

            //try
            //{
                //// Add new pending Transaction
                //_paymentTransactionService.Add(payment);
                //_paymentTransactionService.SavePaymentTransaction();
            //}
            //catch (DataException)
            //{
                //return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            //}

            //// Show form for user
            //return System.Web.UI.WebControls.View(model);
        //}

        //GET: Order/GetOrder
        public Guid? GetOrder(string jsonLocalStorageObj)
        {
            var products = StorageHelper.GetProductsLocal(jsonLocalStorageObj, db);
            var currentUserId = User.Identity.GetUserId();
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
                OrderedBy = currentUserId,
                ProductsInOrder = productsInOrder,
                OrderStatus = new OrderStatus()
            };

            db.Orders.Add(order);
            db.SaveChanges();

            return order.Id;
        }
    }
}