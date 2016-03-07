using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TcgTournament.Models
{
    public class Tournament
    {
        private Dictionary<int, List<Match>> matchesByRound;
        private List<Player> participating;
        private Timer chrono;
        public Tournament()
        {
            participating = new List<Player>();
            matchesByRound = new Dictionary<int, List<Match>>();
        }

        internal void PermutatePlayers(Player firstP, Player secondP)
        {
            List<Match> CurrentMatches = new List<Match>();
            this.matchesByRound.TryGetValue(this.matchesByRound.Count - 1, out CurrentMatches);
            
        }

        internal void StartCountdown()
        {
            this.chrono.Start();
        }

        public Tournament(List<Player> players,Timer timer)
        {
            participating = players;
            matchesByRound = new Dictionary<int, List<Match>>();
            chrono = timer;
            
        }
        public Timer Chrono
        {
            get { return this.chrono; }
            set { this.chrono = value; }
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
