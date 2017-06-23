namespace PolishGamesRanking
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<GameGenres> GameGenres { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<RatedGames> RatedGames { get; set; }
        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<GameGenres>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.GameGenres)
                .HasForeignKey(e => e.GameGenreId);

            modelBuilder.Entity<Games>()
                .HasMany(e => e.Files)
                .WithRequired(e => e.Games)
                .HasForeignKey(e => e.GameId);

            modelBuilder.Entity<Rates>()
                .HasMany(e => e.Games)
                .WithOptional(e => e.Rates)
                .HasForeignKey(e => e.RateType_Id);
        }
    }
}
