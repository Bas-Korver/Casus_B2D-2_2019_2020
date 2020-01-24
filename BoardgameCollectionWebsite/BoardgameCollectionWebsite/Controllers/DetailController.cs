using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGames.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Game()
        {
            return View();
        }
    }
}