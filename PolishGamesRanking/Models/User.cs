using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolishGamesRanking.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime JoinedDate { get; set; }

        public string Nick { get; set; }

        public int GamesAdded { get; set; }

        public int GamesRated { get; set; }
    }
}