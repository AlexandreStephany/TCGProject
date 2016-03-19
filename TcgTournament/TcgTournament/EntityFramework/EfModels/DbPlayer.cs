using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcgTournament.EntityFramework.EfModels
{
    [Serializable]
    public class DbPlayer
    {
        string pseudo;
        List<DbTournament> tournaments;
        public DbPlayer(string pseudo)
        {
            this.Pseudo = pseudo;
            Tournaments = new List<DbTournament>();
        }

        public string Pseudo
        {
            get
            {
                return pseudo;
            }

            set
            {
                pseudo = value;
            }
        }

        public List<DbTournament> Tournaments
        {
            get
            {
                return tournaments;
            }

            set
            {
                tournaments = value;
            }
        }
    }
}
