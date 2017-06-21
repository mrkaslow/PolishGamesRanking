using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Nick { get; set; }
        public int Age { get; set; }
        public bool WantNewsletter { get; set; }
        public int GamesAdded { get; set; }
        public int GamesRatedCount { get; set; }


        public EditUserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Email = user.Email;
            Nick = user.Nick;
            Age = user.Age;
            WantNewsletter = user.WantNewsletter;
            GamesAdded = user.GamesAdded;
            GamesRatedCount = user.GamesRatedCount;
        }
    }
}