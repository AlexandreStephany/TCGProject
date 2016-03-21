using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcgTournament.Models;

namespace TcgTournament.Controlers
{
    public class SuperControler
    {
        private Tournament tournament;
        public SuperControler(Tournament t)
        {
            tournament = t;
        }
        public Tournament ActualTournament
        {
            get { return this.tournament; }
            set { this.tournament = value; }
        }

    }
}
