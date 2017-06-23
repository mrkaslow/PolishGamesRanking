namespace PolishGamesRanking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            Files = new HashSet<Files>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte GameGenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public int RatingsCount { get; set; }

        public int AllRates { get; set; }

        public DateTime DateAdded { get; set; }

        public byte RatingId { get; set; }

        public int? RateType_Id { get; set; }

        public float Rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Files> Files { get; set; }

        public virtual GameGenres GameGenres { get; set; }

        public virtual Rates Rates { get; set; }
    }
}
