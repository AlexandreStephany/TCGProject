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
                    
                    for (int j = 0; j < CurrentMatches.Count && !permutationMade; j++)
                    {
                        Match secondMatch = CurrentMatches[j];
                        if (secondMatch.PlayerOnThisMatch(secondP))
                        {

                            firstMatch.ChangePlayer(firstP, secondP);
                            secondMatch.ChangePlayer(secondP,firstP);
                        }

                    }

                    }else if(firstMatch.PlayerOnThisMatch(secondP)){

                }
            }
            
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
