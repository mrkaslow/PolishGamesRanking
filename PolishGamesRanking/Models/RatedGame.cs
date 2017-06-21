using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolishGamesRanking.Models
{
    public class RatedGame
    {
        public int Id { get; set; }
        [Required]
        public int GameId { get; set; }

        public string ApplicationUserId { get; set; }

        public int UsersRate { get; set; }
    }
}