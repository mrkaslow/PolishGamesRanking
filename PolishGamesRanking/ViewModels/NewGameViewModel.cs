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

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte? GameGenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public float Rating { get; set; }

        public int RatingsCount { get; set; }

        public int AllRates { get; set; }

        public int RatingId { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edycja gry" : "Nowa gra"; }
        }

        public ICollection<File> Files { get; set; }

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
            Files = game.Files;
            Developer = game.Developer;
            Publisher = game.Publisher;
            DateAdded = game.DateAdded;
            Rating = game.Rating;
            AllRates = game.AllRates;
            RatingsCount = game.RatingsCount;
        }
    }
}