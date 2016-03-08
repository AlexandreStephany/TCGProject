using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Media;

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
            this.Chrono = new Timer();
            this.Chrono.Elapsed += ActivateAlarm;
        }
        public Tournament(List<Player> players, int timeLaps)
        {
            participating = players;
            matchesByRound = new Dictionary<int, List<Match>>();
            chrono = new Timer(timeLaps);
            this.Chrono.Elapsed += ActivateAlarm;

        }

        internal void PermutatePlayers(Player firstP, Player secondP)
        {
            List<Match> CurrentMatches = new List<Match>();
            this.matchesByRound.TryGetValue(this.matchesByRound.Count - 1, out CurrentMatches);
            bool permutationMade = false;
            for(int i = 0; i < CurrentMatches.Count && !permutationMade ; i++)
            {
                Match firstMatch = CurrentMatches[i];
                if(firstMatch.PlayerOnThisMatch(firstP))
                {
                    permutationMade = DoPermutation(CurrentMatches, firstMatch, firstP, secondP);
                }
                else if(firstMatch.PlayerOnThisMatch(secondP)){
                    permutationMade = DoPermutation(CurrentMatches, firstMatch, secondP, firstP);                     
                }
            }            
        }

        public bool DoPermutation(List<Match> currentMatches, Match firstMatch, Player firstP, Player secondP)
        {
            bool permutationMade = false;
            for (int j = 0; j < currentMatches.Count && !permutationMade; j++)
            {
                Match secondMatch = currentMatches[j];
                if (secondMatch.PlayerOnThisMatch(firstP))
                {
                    secondMatch.ChangePlayer(firstP, secondP);
                    firstMatch.ChangePlayer(secondP, firstP);
                    permutationMade = true;
                }

            }
            return permutationMade;
        }

        internal void StartCountdown()
        {
            
            this.chrono.Start();
        }

        private static void ActivateAlarm(Object source, ElapsedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"..\Alarm.wav");
            player.Play();
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
