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
            game = _context.Games.Include(c => c.Files).SingleOrDefault(c => c.Id == id);

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
                GameGenres = gameGenres,
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
        public ActionResult Save(Game game, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewGameViewModel
                {
                    Game = game,
                    GameGenres = _context.GameGenres.ToList(),
                };
                return View("New", viewModel);
            }
            if (image != null && image.ContentLength > 0)
            {
                var newImage = new File
                {
                    FileName = System.IO.Path.GetFileName(image.FileName),
                    ContentType = image.ContentType
                };
                using (var reader = new System.IO.BinaryReader(image.InputStream))
                {
                    newImage.Content = reader.ReadBytes(image.ContentLength);
                }
                game.Files = new List<File> { newImage };
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

        //public void UploadImage(ImageModel imageModel)
        //{
        //    if (imageModel.File.ContentLength > (2 * 1024 * 1024))
        //    {
        //        ModelState.AddModelError("CustomError", "Plik musi mieć poniżej 2 MB.");
        //    }
        //    if (!(imageModel.File.ContentType == "image/jpeg" || imageModel.File.ContentType == "image/gif"))
        //    {
        //        ModelState.AddModelError("CustomError", "Dozwolone formaty plików: jpeg i gif");
        //    }

        //    imageModel.FileName = imageModel.File.FileName;
        //    imageModel.ImageSize = imageModel.File.ContentLength;

        //    byte[] data = new byte[imageModel.File.ContentLength];
        //    imageModel.File.InputStream.Read(data, 0, imageModel.File.ContentLength);

        //    imageModel.ImageData = data;

        //    _context.Images.Add(imageModel);
        //    _context.SaveChanges();
        //}
    }
}