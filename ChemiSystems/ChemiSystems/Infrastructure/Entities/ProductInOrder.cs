using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ProductInOrder : BaseEntity
    {
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public string DescriptionMain { get; set; }
        public string DescriptionSecondary { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ProductImage ProductImage { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        
    }
}