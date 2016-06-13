using System.Collections.Generic;
using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } 
    }
}
