using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcgTournament.Models;
using TcgTournament.EntityFramework;
using TcgTournament.EntityFramework.EfModels;

namespace TcgTournament.Controlers
{
    public class SuperControler
    {
        private Tournament tournament;
        private EFTournamentMapper mapper;
        public SuperControler(Tournament t, EFTournamentMapper mapp)
        {
            tournament = t;
            Mapper = mapp;
        }
        public Tournament ActualTournament
        {
            get { return this.tournament; }
            set { this.tournament = value; }
        }

        public EFTournamentMapper Mapper
        {
            get
            {
                return mapper;
            }

            set
            {
                mapper = value;
            }
        }
    }
}
