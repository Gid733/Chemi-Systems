using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemiSystems.Controllers
{
    public class AccountProfileController : Controller
    {
        // GET: AccountProfile/Orders/
        public ActionResult Orders()
        {
            return View();
        }

        // GET: AccountProfile/Messages/
        public ActionResult Messages()
        {
            return View();
        }

        // GET: AccountProfile/Settings
        public ActionResult Settings()
        {
            return View();
        }
    }
}