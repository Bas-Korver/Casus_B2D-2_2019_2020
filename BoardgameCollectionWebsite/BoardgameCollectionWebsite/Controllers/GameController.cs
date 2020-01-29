using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardgameCollectionWebsite.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Compare()
        {
            return View();
        }
    }
}