namespace PolishGamesRanking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public int Id { get; set; }

        public string Nick { get; set; }

        public int GamesAdded { get; set; }

        public int GamesRated { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime JoinedDate { get; set; }
    }
}
