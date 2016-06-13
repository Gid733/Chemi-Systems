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
            ProductCategory category1 = new ProductCategory
            {
                Name = "Boric acids"
            };

            ProductCategory category2 = new ProductCategory
            {
                Name = "Hydrochloric acids"
            };

            ProductImage image11 = new ProductImage
            {
                ImageMain = "~/Content/img/boric-acid.jpg",
                ImageMolecular = "",
                ImageFormula = ""
            };

            Product product11 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Boric Acid 10%",
                VendorCode = "BA10",
                DescriptionMain = "Boric acid at 10% concentration",
                DescriptionSecondary = "Boric acid boiling point - 10 degrees",
                Price = 10.55, 
                ProductCategory = category1,
                ProductImage = image11
            };

            ProductImage image12 = new ProductImage
            {
                ImageMain = "~/Content/img/boric-acid.jpg",
                ImageMolecular = "",
                ImageFormula = ""
            };

            Product product12 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Boric Acid 20%",
                VendorCode = "BA20",
                DescriptionMain = "Boric acid at 20% concentration",
                DescriptionSecondary = "Boric acid boiling point - 20 degrees",
                Price = 11.55,
                ProductCategory = category1,
                ProductImage = image12
            };

            ProductImage image13 = new ProductImage
            {
                ImageMain = "~/Content/img/boric-acid.jpg",
                ImageMolecular = "",
                ImageFormula = ""
            };

            Product product13 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Boric Acid 30%",
                VendorCode = "BA30",
                DescriptionMain = "Boric acid at 30% concentration",
                DescriptionSecondary =  "Boric acid boiling point - 30 degrees",
                Price = 12.55,
                ProductCategory = category1,
                ProductImage = image13
            };

            ProductImage image21 = new ProductImage
            {
                ImageMain = "~/Content/img/hydrochloric-acid/hydrochloric-acid.jpg",
                ImageMolecular = "",
                ImageFormula = ""
            };

            Product product21 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Hydrohloric Acid 10%",
                VendorCode = "HA10",
                DescriptionMain = "Hydrohloric Acid 10%",
                DescriptionSecondary = "Hydrohloric acid boiling point - 10 degrees",
                Price = 21.55,
                ProductCategory = category2,
                ProductImage = image21
            };

            ProductImage image22 = new ProductImage
            {
                ImageMain = "~/Content/img/hydrochloric-acid/hydrochloric-acid.jpg",
                ImageMolecular = "",
                ImageFormula = ""
            };

            Product product22 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Hydrohloric Acid 20%",
                VendorCode = "HA30",
                DescriptionMain = "Hydrohloric Acid 20%",
                DescriptionSecondary = "Hydrohloric acid boiling point - 20 degrees",
                Price = 22.55,
                ProductCategory = category2,
                ProductImage = image22
            };

            ProductImage image23 = new ProductImage
            {
                ImageMain = "~/Content/img/hydrochloric-acid/hydrochloric-acid.jpg",
                ImageMolecular = "",
                ImageFormula = ""
            };

            Product product23 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Hydrohloric Acid 30%",
                VendorCode = "HA30",
                DescriptionMain = "Hydrohloric Acid 30%",
                DescriptionSecondary = "Hydrohloric acid boiling point - 30 degrees",
                Price = 23.55,
                ProductCategory = category2,
                ProductImage = image23
            };
            

            // добавляем их в бд
            db.ProductCategories.Add(category1);
            db.ProductCategories.Add(category2);
            db.SaveChanges();
            db.ProductImages.AddRange(new List<ProductImage> { image11, image12, image13, image21, image22, image23 });                     
            db.SaveChanges();
            db.Products.AddRange(new List<Product> { product11, product12, product13, product21, product22, product23 });
            db.SaveChanges();
            var users = db.Products;

            return View();
        }
    }
}