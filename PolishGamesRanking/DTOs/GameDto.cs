using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wybierz gatunek.")]
        public byte? GameGenreId { get; set; }

        [Required(ErrorMessage = "Podaj datę premiery.")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public virtual ICollection<File> Files { get; set; }

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

        public byte RatingId { get; set; }

        public string Description { get; set; }

        public bool DLC { get; set; }

        public string Engine { get; set; }
    }
}
