using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.ViewModels
{
    public class RandomGameViewModel
    {
        public Game Game { get; set; }
        public List<User> Users { get; set; } 
    }
}