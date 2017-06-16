using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolishGamesRanking.Models
{
    public class Rate
    {
        public int Id { get; set; } 
        public string RateName { get; set; }

        [Required]
        public int RateValue { get; set; }
    }
}