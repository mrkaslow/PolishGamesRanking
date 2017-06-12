using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace PolishGamesRanking.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę.")]
        [StringLength(255)]
        public string Name { get; set; }

        public GameGenre GameGenre { get; set; }

        [Display(Name = "Gatunek")]
        [Required]
        public byte? GameGenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edycja gry" : "Nowa gra"; }
        }

        public float Rating
        {
            get
            {
                if (RatingsCount == 0)
                {
                    return 0;
                }
                return AllRates / RatingsCount;
            }
            set { }
        }

        public int RatingsCount { get; set; }

        public int AllRates { get; set; }
    }
}