using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemiSystems.Models
{
    public class GetProductsModel
    {
        public Guid? Id { get; set; }
        public int? Page { get; set; }
        public int? PageNumber { get; set; }

        public GetProductsModel()
        {
            PageNumber = 1;
        }
}
}