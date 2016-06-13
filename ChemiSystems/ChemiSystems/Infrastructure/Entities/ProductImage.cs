using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImageMain { get; set; }
        public string ImageMolecular { get; set; }
        public string ImageFormula { get; set; }
    }
}