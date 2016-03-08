using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcgTournament.Models;

namespace TcgTournament.Controlers
{
    public class TournamentControler: SuperControler
    {
        Dictionary<Player, List<Player>> playerFought;
        public TournamentControler(Tournament tournament):base(tournament)
        {
            playerFought = new Dictionary<Player, List<Player>>();
            for(int i = 0; i < Tournament.NumberOfPlayer(); i++)
            {
                playerFought.Add(Tournament.Participating[i], new List<Player>());
            }
        }
        public void GenerateNextMatches()
        {
            Random RandNumber = new Random();
            int roundNumber = Tournament.MatchesByRound.Count;
            List<Player> playersByRanking = Tournament.SortedPlayers();
            List<Match> CurrentMatches = new List<Match>();
            Player tempPlayer;
            Dictionary<Player, List<Player>>tempPlayerFought=playerFought;
            if (Tournament.NumberOfPlayer() % 2 == 1)
            {
                do
                {
                    tempPlayer = playersByRanking[RandNumber.Next(Tournament.NumberOfPlayer() - 1)];
                } while (playerFought[tempPlayer].Contains(null));
                CurrentMatches.Add(new Match(tempPlayer, null));
                tempPlayerFought[tempPlayer].Add(null);
                playersByRanking.Remove(tempPlayer);
            }
            bool oneMatchIsNotValid = false;
            List<Match> tempCurrentMatches = new List<Match>();
            do
            {
                tempCurrentMatches = CurrentMatches;
                List<Player> tempPlayersByRanking = playersByRanking;   
                while (tempPlayersByRanking.Count != 0)
                {
                    tempPlayer = GetNextPlayer(tempPlayersByRanking[0], tempPlayersByRanking);
                    if (tempPlayer == null) oneMatchIsNotValid = true;
                    tempCurrentMatches.Add(new Match(tempPlayersByRanking[0], tempPlayer));
                    tempPlayerFought[tempPlayer].Add(tempPlayersByRanking[0]);
                    tempPlayerFought[tempPlayersByRanking[0]].Add(tempPlayer);
                    tempPlayersByRanking.Remove(tempPlayer);
                    tempPlayersByRanking.Remove(tempPlayersByRanking[0]);
                }

            }while(oneMatchIsNotValid);
            this.playerFought = tempPlayerFought;
            this.Tournament.MatchesByRound.Add(this.Tournament.NumberOfMatches(), tempCurrentMatches);
        }

        private Player GetNextPlayer(Player player, List<Player> playersByRanking)
        {
            foreach(Player p in playersByRanking){
                if(!p.Equals(player) && !playerFought[player].Contains(p))
                {
                    return p;
                }

            }
            return null;
        }

        public void CompleteMatches()
        {
            
        }
        public void LaunchRound()
        {
            this.Tournament.StartCountdown();
        }
    }
}
