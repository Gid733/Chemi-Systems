using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChemiSystems.Infrastructure.Base;

namespace ChemiSystems.Infrastructure.Entities
{
    public class ProductCategory : BaseDirectoryEntity
    {
        //[Key]
        //[ForeignKey("Product")]
        //public override Guid Id { get; set; }
    }
}
