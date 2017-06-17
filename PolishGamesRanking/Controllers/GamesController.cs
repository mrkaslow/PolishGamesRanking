using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing.Printing;
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

            var styles = RateList.Select(m => new SelectListItem
            {
                Value = m.RateValue.ToString(),
                Text = m.RateName,
                Selected = game.RatingId.Equals(m.Id.ToString())
            });
            ViewBag.Styles = styles;

            if (game == null)
                return HttpNotFound();

            var viewModel = new DetailViewModel
            {
                Game = game
            };

            return View(viewModel);
        }

        public ActionResult New()
        {
            var gameGenres = _context.GameGenres.ToList();
            var viewModel = new NewGameViewModel
            {
                GameGenres = gameGenres,
            };
            return View("New", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var game =  _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            var viewModel = new NewGameViewModel(game)
            {
                GameGenres = _context.GameGenres.ToList(),
                Files = _context.Files.ToList()
            };

            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Game game, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid || image == null)
            {
                var viewModel = new NewGameViewModel(game)
                {
                    GameGenres = _context.GameGenres.ToList(),
                };
                return View("New", viewModel);
            }

            if (image.ContentLength > 0)
            {
                File newImage;
                if (game.Id == 0)
                {
                    newImage = new File()
                    {
                        FileName = System.IO.Path.GetFileName(image.FileName),
                        ContentType = image.ContentType,
                        FileId = game.Id,
                        GameId = game.Id
                    };
                }
                else
                {
                    newImage = _context.Files.SingleOrDefault(c => c.GameId == game.Id);
                    newImage.FileName = System.IO.Path.GetFileName(image.FileName);
                    newImage.ContentType = image.ContentType;
                }
                using (var reader = new System.IO.BinaryReader(image.InputStream))
                {
                    newImage.Content = reader.ReadBytes(image.ContentLength);
                }
                game.Files = new List<File> {newImage};
            }

            if (game.Id == 0)
            {
                game.DateAdded = DateTime.Now;
                _context.Games.Add(game);
            } else
            {
                var gameInDb = _context.Games.Single(c => c.Id == game.Id);

                gameInDb.Name = game.Name;
                gameInDb.Developer = game.Developer;
                gameInDb.Publisher = game.Publisher;
                gameInDb.GameGenreId = game.GameGenreId;
                gameInDb.ReleaseDate = game.ReleaseDate;
                gameInDb.Files = game.Files;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Games");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rate(Game game, int id)
        {
            var gameInDb = _context.Games.Single(c => c.Id == id);
            gameInDb.AllRates += RateList.Find(x => x.Id == game.RatingId).RateValue;
            gameInDb.RatingsCount++;

            _context.SaveChanges();

            return RedirectToAction("Index", "Games");
        }

        private List<Rate> RateList= new List<Rate>{
            new Rate
            {
                Id = 1,
                RateName = "Nieporozumienie(1)",
                RateValue = 1
            },
            new Rate
            {
                Id = 2,
                RateName = "Bardzo zła(2)",
                RateValue = 2
            },
            new Rate
            {
                Id = 3,
                RateName = "Słaba(3)",
                RateValue = 3
            },
            new Rate
            {
                Id = 4,
                RateName = "Ujdzie(4)",
                RateValue = 4
            },
            new Rate
            {
                Id = 5,
                RateName = "Średnia(5)",
                RateValue = 5
            },
            new Rate
            {
                Id = 6,
                RateName = "Niezła(6)",
                RateValue = 6
            },
            new Rate
            {
                Id = 7,
                RateName = "Dobra(7)",
                RateValue = 7
            },
            new Rate
            {
                Id = 8,
                RateName = "Bardzo dobra(8)",
                RateValue = 8
            },
            new Rate
            {
                Id = 9,
                RateName = "Rewelacyjna(9)",
                RateValue = 9
            },
            new Rate
            {
                Id = 10,
                RateName = "Arcydzieło!(10)",
                RateValue = 10
            }
        };
    }
}