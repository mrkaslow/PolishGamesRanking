using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.Controllers
{
    [AllowAnonymous]
    public class AboutMeController : Controller
    {
        // GET: AboutMe
        public ActionResult Index()
        {
            return View();
        }
    }
}