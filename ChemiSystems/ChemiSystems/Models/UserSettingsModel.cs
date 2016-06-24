using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemiSystems.Models
{
    public class UserSettingsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
    }
}