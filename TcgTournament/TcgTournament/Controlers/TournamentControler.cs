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
            if (Tournament.NumberOfPlayer() % 2 == 1)
            {
                do
                {
                    tempPlayer = playersByRanking[RandNumber.Next(Tournament.NumberOfPlayer() - 1)];
                } while (playerFought[tempPlayer].Contains(null));
                CurrentMatches.Add(new Match(tempPlayer, null));
                playerFought[tempPlayer].Add(null);
                playersByRanking.Remove(tempPlayer);
            }
            while (playersByRanking.Count != 0)
            {
                tempPlayer = GetNextPlayer(playersByRanking[0], playersByRanking);
                CurrentMatches.Add(new Match(playersByRanking[0],tempPlayer));
                playerFought[tempPlayer].Add(playersByRanking[0]);
                playerFought[playersByRanking[0]].Add(tempPlayer);
                playersByRanking.Remove(tempPlayer);
                playersByRanking.Remove(playersByRanking[0]);
            }
            //If you finished it Miwaku here's were you could do it ;)
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
