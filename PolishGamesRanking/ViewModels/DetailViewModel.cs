using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.ViewModels
{
    public class DetailViewModel
    {
        public IEnumerable<Rate> Rates { get; set; }
        public Game Game { get; set; }
    }
}
