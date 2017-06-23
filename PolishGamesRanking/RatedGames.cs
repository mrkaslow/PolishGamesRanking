namespace PolishGamesRanking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RatedGames
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string ApplicationUserId { get; set; }

        public int UsersRate { get; set; }
    }
}
