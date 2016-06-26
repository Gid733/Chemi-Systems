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
        private ApplicationDbContext _db = new ApplicationDbContext();
        
        // GET: Catalogue
        public ActionResult Index()
        {           
            var users = _db.Products;
            return View("Catalogue");
        }

        public ActionResult GenerateDb()
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
                ImageMolecular = "~/Content/img/molecular.png",
                ImageFormula = "~/Content/img/formula.jpg"
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
                ImageMolecular = "~/Content/img/molecular.png",
                ImageFormula = "~/Content/img/formula.jpg"
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
                ImageMolecular = "~/Content/img/molecular.png",
                ImageFormula = "~/Content/img/formula.jpg"
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
                DescriptionSecondary = "Boric acid boiling point - 30 degrees",
                Price = 12.55,
                ProductCategory = category1,
                ProductImage = image13
            };

            ProductImage image21 = new ProductImage
            {
                ImageMain = "~/Content/img/hydrochloric-acid/hydrochloric-acid.jpg",
                ImageMolecular = "~/Content/img/hydrochloric-acid/molecular.jpg",
                ImageFormula = "~/Content/img/hydrochloric-acid/formula.png"
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
                ImageMolecular = "~/Content/img/hydrochloric-acid/molecular.jpg",
                ImageFormula = "~/Content/img/hydrochloric-acid/formula.png"
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
                ImageMolecular = "~/Content/img/hydrochloric-acid/molecular.jpg",
                ImageFormula = "~/Content/img/hydrochloric-acid/formula.png"
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



            _db.ProductCategories.Add(category1);
            _db.ProductCategories.Add(category2);
            _db.SaveChanges();
            _db.ProductImages.AddRange(new List<ProductImage> { image11, image12, image13, image21, image22, image23 });
            _db.SaveChanges();
            _db.Products.AddRange(new List<Product> { product11, product12, product13, product21, product22, product23 });
            _db.SaveChanges();
            return null;
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

            ////    from p in db.Products.Include("ProductImage")
            ////              .Where(p => p.VendorCode == vendorCode)
            ////              select p;
            return View("Product", product);
        }
    }
}
/*
 
     */
