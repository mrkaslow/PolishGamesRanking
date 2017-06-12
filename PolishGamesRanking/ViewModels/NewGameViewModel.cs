using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.DataHandler.Encoder;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.ViewModels
{
    public class NewGameViewModel
    {
        public IEnumerable<GameGenre> GameGenres { get; set; }
        public int? Id { get; set; }
        public Game Game { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte? GameGenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public string Title { get; set; }
        public int ImageSize { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }

        public HttpPostedFileBase File { get; set; }

        public NewGameViewModel()
        {
            Id = 0;
        }

        public NewGameViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            ReleaseDate = game.ReleaseDate;
            GameGenreId = game.GameGenreId;
            Title = game.Title;
        }
    }
}