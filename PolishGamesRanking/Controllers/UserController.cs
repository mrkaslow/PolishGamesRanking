using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PolishGamesRanking.Models;
using PolishGamesRanking.ViewModels;

namespace PolishGamesRanking.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        private UserStore<ApplicationUser> store;
        private UserManager<ApplicationUser> userManager;
        private List<ApplicationUser> users;

        public UserController()
        {
            store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            userManager = new UserManager<ApplicationUser>(store);
            users = userManager.Users.ToList();
        }

        // GET: User
        public ViewResult Index()
        {
            return View(users);
        }

        public ActionResult Details(string id)
        {
            var user = users.Find(c => c.Id == id);

            if (user == null)
                return HttpNotFound();
            return View(user);
        }

        //public ActionResult New()
        //{
        //    return View("UserForm");
        //}

        public ActionResult Edit(string id)
        {
            var user = users.Find(c => c.Id == id);
            if (user == null)
                return HttpNotFound();

            var viewModel = new EditUserViewModel(user)
            {
            };

            return View("UserForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(ApplicationUser user, string Id)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EditUserViewModel(user)
                {
                };
                return View("UserForm", viewModel);
            }

            var userInDb = userManager.Users.SingleOrDefault(c => c.Id == Id);

            userInDb.Age = user.Age;
            userInDb.Nick = user.Nick;
            userInDb.WantNewsletter = user.WantNewsletter;

            await userManager.UpdateAsync(userInDb);
            var ctx = store.Context;
            ctx.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}