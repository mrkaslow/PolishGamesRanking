using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PolishGamesRanking.Models;
using PolishGamesRanking.ViewModels;

namespace PolishGamesRanking.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context;
        private UserStore<ApplicationUser> store;
        private UserManager<ApplicationUser> userManager;
        private List<ApplicationUser> users;

        public GamesController()
        {
            _context = new ApplicationDbContext();
            store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            userManager = new UserManager<ApplicationUser>(store);
            users = userManager.Users.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var games = _context.Games.Include(c=> c.GameGenre).ToList();

            var orderedGames = games.OrderByDescending(c => c.Rating);

            if (User.IsInRole(RoleName.CanDeleteAndEditGames))
                return View("Index", orderedGames);
                return View("NonAdminIndex", orderedGames);
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
                Game = game,
            };

            var userId = User.Identity.GetUserId();
            var userInDb = userManager.Users.Single(c => c.Id == userId);

            var rate = false;
            int userRate = 0;
            foreach (var rates in _context.RatedGames)
            {
                if (rates.ApplicationUserId == userId)
                {
                    if (rates.GameId == game.Id)
                    {
                        rate = true;
                        userRate = rates.UsersRate;
                    }
                }
            }
            if (rate)
            {
                viewModel = new DetailViewModel
                {
                    Game = game,
                    UsersRate = userRate
                };
                if (User.IsInRole(RoleName.CanDeleteAndEditGames))
                    return View("DetailsNoRating_Admin", viewModel);
                    return View("DetailsNoRating", viewModel);
            }
            if (User.IsInRole(RoleName.CanDeleteAndEditGames))
            return View("Details_Admin", viewModel);
            return View("Details", viewModel);
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

        [Authorize(Roles = RoleName.CanDeleteAndEditGames)]
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
        public async Task<ActionResult> Save(Game game, HttpPostedFileBase image)
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
                var user = users.Find(c => c.Id == User.Identity.GetUserId());
                user.GamesAdded++;

                await userManager.UpdateAsync(user);
                var ctx = store.Context;
                ctx.SaveChanges();
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
            TempData["Msg"] = "Gra została dodana do bazy.";
            return RedirectToAction("Index", "Games");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rate(Game game, int id, ApplicationUser user)
        {
            
            var gameInDb = _context.Games.Single(c => c.Id == id);
            var userId = User.Identity.GetUserId();
            var userInDb = userManager.Users.Single(c => c.Id == userId);

            
            

            var rate = false;
            foreach (var rates in _context.RatedGames)
            {
                if (rates.ApplicationUserId == userId)
                {
                    if (rates.GameId == game.Id)
                    {
                        rate = true;
                    }
                }
            }

            if (!rate)
            {
                var rateValue = RateList.Find(x => x.Id == game.RatingId).RateValue;
                gameInDb.AllRates += rateValue;
                gameInDb.RatingsCount++;
       
                var ratedGame = new RatedGame();
                ratedGame.GameId = gameInDb.Id;
                ratedGame.UsersRate = rateValue;
                ratedGame.ApplicationUserId = userId;
                _context.RatedGames.Add(ratedGame);
                userInDb.GamesRatedCount++;

                await userManager.UpdateAsync(userInDb);
                var ctx = store.Context;
                ctx.SaveChanges();
                _context.SaveChanges();
            }
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