using System;
using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public string DescriptionMain { get; set; }
        public string DescriptionSecondary { get; set; }
        public string DescriptionShort { get; set; }
        public double Price { get; set; }

        public Guid ProductImageId { get; set; }
        public ProductImage ProductImage { get; set; }
        
        public virtual Guid ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}