using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ChemiSystems.Infrastructure.Entities;
using ChemiSystems.Models;

namespace ChemiSystems.Helpers
{
    public class ContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //Сategories
            ProductCategory category1 = new ProductCategory
            {
                Name = "Boric & Acetic acids",
                CategoryIcon = "fa-flask"
            };

            ProductCategory category2 = new ProductCategory
            {
                Name = "Hydrochloric acids",
                CategoryIcon = "fa-eyedropper"
            };

            //ProductCategory category3 = new ProductCategory
            //{
            //    Name = "Nitrilic acids",
            //    CategoryIcon = "fa-cubes"
            //};


            //products
            ProductImage image11 = new ProductImage
            {
                ImageMain = "~/Content/img/boric-acid/boric-acid.jpg",
                ImageMolecular = "~/Content/img/boric-acid/molecular.png",
                ImageFormula = "~/Content/img/boric-acid/formula.jpg"
            };

            Product product11 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Boric Acid",
                VendorCode = "BA",
                DescriptionMain = "Boric acid, also called hydrogen borate, " +
                                  "boracic acid, orthoboric acid and acidum boricum, is a weak, " +
                                  "monobasic Lewis acid of boron often used as an antiseptic, insecticide, flame retardant, " +
                                  "neutron absorber, or precursor to other chemical compounds. It has the chemical formula H3BO3 (sometimes written B(OH)3), " +
                                  "and exists in the form of colorless crystals or a white powder that dissolves in water. When occurring as a mineral, " +
                                  "it is called sassolite.",
                DescriptionSecondary = "CAS No.: 10043-35-3 " +                          ",\n" +
                                       "EC Number: 233 - 139 - 2 " +                     ",\n" +
                                       "Appearance: White granules " +                   ",\n" +
                                       "Molecular Weight: 61.83 " +                      ",\n" +
                                       "Molecular Formula: H3BO3 " +                     ",\n" +
                                       "Melting Point: 169 deg.C(336.20F) " +            ",\n" +
                                       "Specific Gravity: 1.44(water = 1) " +            ",\n" +
                                       "Solubility in water: 4.9g / 100g @ 20C " + ",\n" +
                                       "pH: 3.6 - 4(4 % aq.soln)",
                DescriptionShort = "Boric acid is a weak, monobasic Lewis acid of boron often used as an antiseptic, " +
                                   "or precursor to other chemical compounds.",
                Price = 0.01,           
                ProductCategory = category1,
                ProductImage = image11  
            };

            ProductImage image12 = new ProductImage
            {
                ImageMain = "~/Content/img/acetic-acid/acetic-acid.png",
                ImageMolecular = "~/Content/img/acetic-acid/molecular.png",
                ImageFormula = "~/Content/img/acetic-acid/formula.png"
            };

            Product product12 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Acetic Acid 10%",
                VendorCode = "AA10",
                DescriptionMain = "Acetic acid, CH3COOH, also known as ethanoic acid, is an organic acid,with a pungent smell. It is a weak acid, in that it is only partially dissociated in an aqueous solution. " +
                                  "Acetic acid is one of the simplest carboxylic acids, and is a very important industrial chemical.",
                DescriptionSecondary = "CAS No.: 64-19-7 " +             ",\n" +
                                       "EC No: 200 - 580 - 7 " +         ",\n" +
                                       "Formula: C2H4O2 " +              ",\n" +
                                       "Molar mass: 60.05 g mol?1 " +    ",\n" +
                                       "Density: 1.049g / cm3 " +        ",\n" +
                                       "Melting Point: 16.5 oC " + ",\n" +
                                       "Boiling point: 118.1 oC ",
                DescriptionShort = "Acetic acid, CH3COOH, also known as ethanoic acid, is an organic acid,with a pungent smell.",
                Price = 0.02,                                             
                ProductCategory = category1,                              
                ProductImage = image12  
            };                          

            ProductImage image13 = new ProductImage
            {
                ImageMain = "~/Content/img/acetic-acid/acetic-acid.png",
                ImageMolecular = "~/Content/img/acetic-acid/molecular.png",
                ImageFormula = "~/Content/img/acetic-acid/formula.png"
            };

            Product product13 = new Product
            {
                ChangedBy = new Guid(),
                ChangedDate = DateTime.Now,
                CreatedBy = new Guid(),
                CreatedDate = DateTime.Now,
                Name = "Acetic Acid 80%",
                VendorCode = "AA30",
                DescriptionMain = "Acetic acid, CH3COOH, also known as ethanoic acid, is an organic acid, with a pungent smell. It is a weak acid, in that it is only partially dissociated in an aqueous solution. " +
                                  "Acetic acid is one of the simplest carboxylic acids, and is a very important industrial chemical.",
                DescriptionSecondary = "CAS No.: 64-19-7 " +                              ",\n" +
                                       "EC No: 200 - 580 - 7 " +                          ",\n" +
                                       "Formula: C2H4O2 " +                               ",\n" +
                                       "Purity: 75 - 80 % " +                             ",\n" +
                                       "Molar mass: 60.05 g mol-1 " +                     ",\n" +
                                       "Density: 1.049g / cm3 " +                         ",\n" +
                                       "Melting Point: 16.5 oC "+ ",\n" +
                                       "Boiling point: 118.1 oC ",
                DescriptionShort = "Acetic acid, CH3COOH, also known as ethanoic acid, is an organic acid,with a pungent smell.",
                Price = 0.03,                                                              
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
                Name = "Hydrochloric Acid 37%",
                VendorCode = "HA37",
                DescriptionMain = "Hydrochloric acid is a clear, colorless, highly pungent solution of hydrogen chloride (HCl) in water. " +
                                  "It is a highly corrosive, strong mineral acid with many industrial uses. " +
                                  "Hydrochloric acid is found naturally in gastric acid. When it reacts with an organic base it forms a hydrochloride salt.",
                DescriptionSecondary = "Molecular Formula: HCl " +                                               ",\n" +
                                       "Molecular Weight: 36.46 " +                                              ",\n" +
                                       "CAS No.: 7647 - 01 - 0 " +                                               ",\n" +
                                       "EC No. 231 - 595 - 7 " +                                                 ",\n" +
                                       "UN No.: 1789 % of Hydrogen chloride: 10 % " +                            ",\n" +
                                       "Appearance: Colorless or light yellow transparent liquid " +             ",\n" +
                                       "Iron(Fe): 0.006 % " +                                                    ",\n" +
                                       "Sulfate(based on SO4): 0.005 % " +                                       ",\n" +
                                       "Arsenic(As): 0.0001 % " +                                                ",\n" +
                                       "Ignition Residue: 0.08 % " + "\n" +
                                       "Oxide(based on Cl): 0.005 %",
                DescriptionShort = "Hydrochloric acid is a clear, colorless, highly pungent solution of hydrogen chloride (HCl) in water.",
                Price = 0.04,
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
                Name = "Hydrohloric Acid 10%",
                VendorCode = "HA10",
                DescriptionMain = "Hydrochloric acid is a clear, colorless, highly pungent solution of hydrogen chloride (HCl) in water. " +
                                  "It is a highly corrosive, strong mineral acid with many industrial uses. " +
                                  "Hydrochloric acid is found naturally in gastric acid. When it reacts with an organic base it forms a hydrochloride salt.",
                DescriptionSecondary = "Molecular Formula: HCl " +                                              ",\n" +
                                       "Molecular Weight: 36.46 " +                                             ",\n" +
                                       "CAS No.: 7647 - 01 - 0 " +                                              ",\n" +
                                       "EC No. 231 - 595 - 7 " +                                                ",\n" +
                                       "UN No.: 1789 % of Hydrogen chloride: 10 % " +                           ",\n" +
                                       "Appearance: Colorless or light yellow transparent liquid " +            ",\n" +
                                       "Iron(Fe): 0.006 % " +                                                   ",\n" +
                                       "Sulfate(based on SO4): 0.005 % " +                                      ",\n" +
                                       "Arsenic(As): 0.0001 % " +                                               ",\n" +
                                       "Ignition Residue: 0.08 % "                                              + ",\n" +
                                       "Oxide(based on Cl): 0.005 %",
                DescriptionShort = "Hydrochloric acid is a clear, colorless, highly pungent solution of hydrogen chloride (HCl) in water.",
                Price = 0.01,           
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
                Name = "Hydrohloric Acid 20%",
                VendorCode = "HA20",
                DescriptionMain = "Hydrochloric acid is a clear, colorless, highly pungent solution of hydrogen chloride (HCl) in water. " +
                                  "It is a highly corrosive, strong mineral acid with many industrial uses. " +
                                  "Hydrochloric acid is found naturally in gastric acid. When it reacts with an organic base it forms a hydrochloride salt.",
                DescriptionSecondary = "Molecular Formula: HCl " +                                                ",\n" +
                                       "Molecular Weight: 37.46 " +                                               ",\n" +
                                       "CAS No.: 7647 - 01 - 0 " +                                                ",\n" +
                                       "EC No. 231 - 595 - 7 " +                                                  ",\n" +
                                       "UN No.: 1789 % of Hydrogen chloride: 20 % " +                             ",\n" +
                                       "Appearance: Colorless or light yellow transparent liquid " +              ",\n" +
                                       "Iron(Fe): 0.008 % " +                                                     ",\n" +
                                       "Sulfate(based on SO4): 0.004 % " +                                        ",\n" +
                                       "Arsenic(As): 0.0001 % " +                                                 ",\n" +
                                       "Ignition Residue: 0.08 % " +                                              ",\n" +
                                       "Oxide(based on Cl): 0.004 %",
                DescriptionShort = "Hydrochloric acid is a clear, colorless, highly pungent solution of hydrogen chloride (HCl) in water.",
                Price = 0.02,
                ProductCategory = category2,
                ProductImage = image23
            };



            context.ProductCategories.Add(category1);
            context.ProductCategories.Add(category2);
            //context.ProductCategories.Add(category3);
            context.SaveChanges();
            context.ProductImages.AddRange(new List<ProductImage> { image11, image12, image13, image21, image22, image23 });
            context.SaveChanges();
            context.Products.AddRange(new List<Product> { product11, product12, product13, product21, product22, product23 });
            context.SaveChanges();

            //order statuses 
            OrderStatus orderStatus1 = new OrderStatus()
            {
                Status = "Pending",
                StatusColor = "btn btn-info",
                StatusIcon = "fa fa-credit-card"
            };

            OrderStatus orderStatus2 = new OrderStatus()
            {
                Status = "Processing",
                StatusColor = "btn btn-warning",
                StatusIcon = "fa fa-cogs"
            };

            OrderStatus orderStatus3 = new OrderStatus()
            {
                Status = "Delivered",
                StatusColor = "btn btn-success",
                StatusIcon = "fa fa-check"
            };

            OrderStatus orderStatus4 = new OrderStatus()
            {
                Status = "Cancelled",
                StatusColor = "btn btn-danger",
                StatusIcon = "fa fa-times"
            };

            OrderStatus orderStatus5 = new OrderStatus()
            {
                Status = "Archived",
                StatusColor = "btn btn-primary",
                StatusIcon = "fa fa-archive"
            };

            context.OrderStatuses.Add(orderStatus1);
            context.OrderStatuses.Add(orderStatus2);
            context.OrderStatuses.Add(orderStatus3);
            context.OrderStatuses.Add(orderStatus4);
            context.OrderStatuses.Add(orderStatus5);

            context.SaveChanges();
        }
    }
}