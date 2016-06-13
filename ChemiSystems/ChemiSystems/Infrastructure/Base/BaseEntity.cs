using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChemiSystems.Infrastructure.Base
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ChangedBy { get; set; }
        public Guid CreatedBy { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ChangedDate { get; set; }

        public BaseEntity ()
        {
            CreatedDate = DateTime.Now;
        }
    }
}