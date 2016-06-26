using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemiSystems.Infrastructure.Entities
{
    public class OrderMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public DateTime? DateSend { get; set; }

        public OrderMessage()
        {
            DateSend = DateTime.Now;
        }
    }
}