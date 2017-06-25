using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        [Required(ErrorMessage = "Wybierz gatunek.")]
        public byte? GameGenreId { get; set; }

        [Required(ErrorMessage = "Podaj datę premiery.")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public bool DLC { get; set; }

        public string Engine { get; set; }  

        public virtual ICollection<File> Files { get; set; }

        public float Rating
        {
            get
            {
                if (RatingsCount == 0)
                {
                    return 0;
                }
                return (float)AllRates / (float)RatingsCount;
            }
            set { }
        }

        public int RatingsCount { get; set; }

        public int AllRates { get; set; }

        public Rate RateType { get; set; }

        [Display(Name = "Ocena")]
        public byte RatingId { get; set; }
    }
}