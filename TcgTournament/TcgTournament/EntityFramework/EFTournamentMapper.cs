using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using TcgTournament.EntityFramework.EfModels;
using TcgTournament.Models; 
using System.Threading.Tasks;

namespace TcgTournament.EntityFramework
{
    public class EFTournamentMapper: TournamentMapper
    {
        EFDataContext contexte;

        public EFTournamentMapper(string connectionString)
        {
            this.contexte = new EFDataContext(connectionString);
        }

        public void AddTournamentParticipation(Player player)
        {
            if (player.Username != null)
            {
                DbPlayer addPlayer = contexte.Players.First<DbPlayer>(p => p.Pseudo == player.Username);
                DbTournament actualTour = contexte.Tournaments.Last<DbTournament>();
                actualTour.Players.Add(addPlayer);
                addPlayer.Tournaments.Add(actualTour); 
            }
        }

        public void CreatePlayer(Player player)
        {
            if (player.Username != null)
            {
                DbPlayer newPlayer = new DbPlayer(player.Username);
                contexte.Players.Add(newPlayer);
                contexte.SaveChanges();
            }
        }

        public void CreateTournament()
        {
            contexte.Tournaments.Add(new DbTournament());
        }

        public List<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public int[] GetVictoriesDefeatVS1(Player p1, Player p2)
        {
            throw new NotImplementedException();
        }

        public int PossiblePosition(Player p, List<Player> other)
        {
            throw new NotImplementedException();
        }

        public void SaveMatch(Match match)
        {
            var players = match.Result.Keys;
            List<Player> BothPlayers = new List<Player>();
            int[] results= new int[2];
            int count=0;
           foreach(Player player in players)
            {
                BothPlayers.Add(player);
                match.Result.TryGetValue(player, out results[count]);
                count++;
            }

            if (results[0] > 0 || results[1] > 0)
            {
                DbTournament actualTour = contexte.Tournaments.Last<DbTournament>();
                DbPlayer player1 = contexte.Players.First<DbPlayer>(p => p.Pseudo == BothPlayers[0].Username);
                DbPlayer player2 = contexte.Players.First<DbPlayer>(p => p.Pseudo == BothPlayers[1].Username);
                if (results[0] > results[1])
                {
                    contexte.Matches.Add(new DbMatch(actualTour, player1, player2,results[0],results[1]));
                }else
                {
                    contexte.Matches.Add(new DbMatch(actualTour, player2, player1, results[1], results[0]));
                }
                contexte.SaveChanges();
            }
        }

        public int[] TotalVictoriesAndDefeat(Player player)
        {
            throw new NotImplementedException();
        }

        public int TournamentParticipated(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
