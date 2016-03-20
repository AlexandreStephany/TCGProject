using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcgTournament.EntityFramework.EfModels
{
    [Serializable]
    public class DbMatch
    {
        long idMatch;
        DbTournament tournament;
        DbPlayer winner;
        DbPlayer loser;
        int winPoints;
        int losePoints;

        public long IdMatch
        {
            get
            {
                return idMatch;
            }

            set
            {
                idMatch = value;
            }
        }

        public DbTournament Tournament
        {
            get
            {
                return tournament;
            }

            set
            {
                tournament = value;
            }
        }

        public DbPlayer Winner
        {
            get
            {
                return winner;
            }

            set
            {
                winner = value;
            }
        }

        public DbPlayer Loser
        {
            get
            {
                return loser;
            }

            set
            {
                loser = value;
            }
        }

        public int LosePoints
        {
            get
            {
                return losePoints;
            }

            set
            {
                losePoints = value;
            }
        }

        public int WinPoints
        {
            get
            {
                return winPoints;
            }

            set
            {
                winPoints = value;
            }
        }

        public DbMatch(DbTournament idTour, DbPlayer win, DbPlayer los,int winpoint,int lospoint)
        {
            IdMatch = 0;
            tournament = idTour;
            Winner = win;
            Loser = los;
            WinPoints = winpoint;
            LosePoints = lospoint;
        }
    }
}
