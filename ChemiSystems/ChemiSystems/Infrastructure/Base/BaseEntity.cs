using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemiSystems.Infrastructure.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ChangedBy { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }

        public BaseEntity ()
        {
            CreatedDate = DateTime.Now;
        }
    }
}