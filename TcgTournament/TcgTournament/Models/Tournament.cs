using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcgTournament.Models
{
    public class Tournament
    {
        private Dictionary<int, List<Match>> matchesByRound;
        private List<Player> participating;
        public Tournament()
        {
            participating = new List<Player>();
            matchesByRound = new Dictionary<int, List<Match>>();
        }
        public Tournament(List<Player> players)
        {
            participating = players;
            matchesByRound = new Dictionary<int, List<Match>>();
        }
        public Dictionary<int, List<Match>> MatchesByRound
        {
            get { return this.matchesByRound; }
            set { this.matchesByRound = value; }
        }
        public List<Player> Participating
        {
            get { return this.participating; }
            set { this.participating = value;}
        }

    }
}
