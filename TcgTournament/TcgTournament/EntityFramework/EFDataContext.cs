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

        public DbSet<Match>Matches;
        public DbSet<Player> Players;
        public DbSet<Tournament> Tournaments;

    }
}
