using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcgTournament.EntityFramework;
using TcgTournament.EntityFramework.EfModels;

namespace TcgTournament.EntityFramework
{
    public class EFDataContext: DbContext
    {
        public EFDataContext(string connexionString) : base(connexionString) { }

        public DbSet<DbMatch> Matches { get; set; }
        public DbSet<DbPlayer> Players { get; set; }
        public DbSet<DbTournament> Tournaments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbMatch>().ToTable("Matches");
            modelBuilder.Entity<DbMatch>().HasKey(m => m.IdMatch);
            modelBuilder.Entity<DbMatch>().HasOptional(m => m.Winner);
            modelBuilder.Entity<DbMatch>().HasOptional(m => m.Loser);
            modelBuilder.Entity<DbMatch>().HasRequired(m => m.Tournament);


            modelBuilder.Entity<DbPlayer>().ToTable("Players");
            modelBuilder.Entity<DbPlayer>().HasKey(p=>p.Pseudo);

            modelBuilder.Entity<DbTournament>().ToTable("Tournaments");
            modelBuilder.Entity<DbTournament>().HasKey(t => t.IdTournament);
            

            modelBuilder.Entity<DbTournament>().HasMany(t => t.Players).WithMany(p => p.Tournaments).Map(m => {
                m.ToTable("TournamantParticipation");
                m.MapLeftKey("Id Tournament");
                m.MapRightKey("Pseudo");
                
            });
        }

    }
}
