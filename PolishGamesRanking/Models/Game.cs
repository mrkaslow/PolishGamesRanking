using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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