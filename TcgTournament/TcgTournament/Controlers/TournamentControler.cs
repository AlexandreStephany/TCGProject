using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcgTournament.Models;
using TcgTournament.EntityFramework;

namespace TcgTournament.Controlers
{
    public class TournamentControler: SuperControler
    {
        List<Match> playedMatches;
        List<Match> round;

        

        public TournamentControler(Tournament tournament, EFTournamentMapper mapp, List<Player> players) : base(tournament, mapp)
        {
            PlayedMatches = new List<Match>();
            this.ActualTournament.Participating = players;
            Mapper.CreateTournament();
            List<Match> round = MatchMaking.generateNextRound(players, PlayedMatches);
            this.ActualTournament.MatchesByRound.Add(0, round);
            this.Round = round;
        }

        public List<Match> PlayedMatches
        {
            get
            {
                return playedMatches;
            }

            set
            {
                playedMatches = value;
            }
        }

        public List<Match> Round
        {
            get
            {
                return round;
            }

            set
            {
                round = value;
            }
        }

        public void ChangeMatches()
        {
            Random rand = new Random();
            List<Player> players = this.ActualTournament.Participating;
            int n = players.Count ;

            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Player temp = players[k];
                players[k] = players[n];
                players[n] = temp;
            }
            this.Round = MatchMaking.generateNextRound(players, PlayedMatches);
        }
        public void CompleteMatches()
        {
            playedMatches.AddRange(round);
           foreach(Match m in round)
            {
                Mapper.SaveMatch(m);
            }

            this.ActualTournament.Participating.Sort();
            List<Player> players = this.ActualTournament.Participating;
            round = MatchMaking.generateNextRound(players,PlayedMatches);
        }
        public bool allMatchesFinsihed()
        {
            
            foreach(Match m in round)
            {
                if (!m.isComplete())
                    return false;
            }
            return true;
        }
        public void SaveResult(List<Dictionary<Player,int>> results)
        {
            for(int i=0; i< round.Count; i++)
            {
                if (round[i].isFreeMatch())
                {
                    Player pl = round[i].getFreePlayer();
                    pl.ResistancePoints += 2;
                }
                else {
                    round[i].Result = results[i];
                    Player winner = round[i].GetWinner();
                    Player loser = round[i].GetLoser();
                    foreach (Player p in ActualTournament.Participating)
                    {
                        if (p.Equals(winner)) p.VictoryPoints += round[i].getPoints(winner);
                        else if (p.Equals(loser)) p.ResistancePoints += round[i].getPoints(loser);
                    }
                }
            }

        }
        /*public void LaunchRound()
        {
            this.ActualTournament.StartCountdown();
        }*/
    }
}
