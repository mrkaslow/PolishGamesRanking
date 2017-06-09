using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.Mvc;
using PolishGamesRanking.Models;
using PolishGamesRanking.ViewModels;

namespace PolishGamesRanking.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var games = _context.Games.Include(c=> c.GameGenre).ToList();

            var orderedGames = games.OrderByDescending(c => c.Rating);

            return View(orderedGames);
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(c => c.GameGenre).SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            return View(game);
        }

        public ActionResult New()
        {
            var gameGenres = _context.GameGenres.ToList();
            var viewModel = new NewGameViewModel
            {
                Game = new Game(),
                GameGenres = gameGenres
            };
            return View("New", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            var viewModel = new NewGameViewModel
            {
                Game = game,
                GameGenres = _context.GameGenres.ToList()
            };

            return View("New", viewModel);
        }

        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Save(Game game)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewGameViewModel
                {
                    Game = game,
                    GameGenres = _context.GameGenres.ToList()
                };
                return View("New", viewModel);
            }

            if (game.Id == 0)
            {
                game.DateAdded = DateTime.Now;
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(c => c.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.Developer = game.Developer;
                gameInDb.Publisher = game.Publisher;
                gameInDb.GameGenreId = game.GameGenreId;
                gameInDb.ReleaseDate = game.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Games");
        }
    }
}