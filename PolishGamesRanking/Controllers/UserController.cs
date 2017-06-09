using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: User
        public ViewResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();
            return View(user);
        }

        public ActionResult New()
        {
            return View("UserForm");
        }

        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);
            if (user == null)
                return HttpNotFound();

            return View("UserForm", user);
        }
    }
}