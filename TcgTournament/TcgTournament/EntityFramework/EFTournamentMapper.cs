using System;

using System.Collections.Generic;
using System.Linq;
using System.Data;
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
            List<Player> allPlayers = new List<Player>();
            List<DbPlayer> allInDb = contexte.Players.ToList();
            foreach(DbPlayer player in allInDb)
            {
                allPlayers.Add(new Player(player.Pseudo));
            }
            return allPlayers;
        }

        public int[] GetVictoriesDefeatVS1(Player p1, Player p2)
        {
            int[] vAndD = new int[2];
            DbPlayer player1 = contexte.Players.First<DbPlayer>(p => p.Pseudo == p1.Username);
            DbPlayer player2 = contexte.Players.First<DbPlayer>(p => p.Pseudo == p2.Username);
            List<DbMatch> PlayerMatches = contexte.Matches.Where<DbMatch>(m => (m.Winner == player1 || m.Loser == player1) && (m.Winner == player2 || m.Loser == player2)).ToList();

            foreach (DbMatch match in PlayerMatches)
            {
                if (match.Winner == player1)
                {
                    vAndD[0]++;
                }
                else
                if (match.Loser == player1)
                {
                    vAndD[1]++;
                }
            }
            return vAndD;
        }
        
        public int PossiblePosition(Player p, List<Player> other)
        {
            List<DbPlayer> players = new List<DbPlayer>();
            players.Add(contexte.Players.First<DbPlayer>(p1 => p1.Pseudo == p.Username));
            DbPlayer player1 = contexte.Players.First<DbPlayer>(p1 => p1.Pseudo == p.Username);
            foreach (Player player in other)
            {
                players.Add(contexte.Players.First<DbPlayer>(p1 => p1.Pseudo == player.Username));
            }
            List<DbTournament> allTournament = contexte.Tournaments.ToList();
            List<DbTournament> correctTournament = new List<DbTournament>();
            foreach(DbTournament tour in allTournament)
            {
                if (tour.Players.Intersect(players).Count() == players.Count)
                    correctTournament.Add(tour);
            }
            List<DbMatch> allMatches = contexte.Matches.ToList();
            List<DbMatch> correctMatches = new List<DbMatch>();
            foreach (DbMatch match in allMatches)
            {
                if (correctTournament.Contains(match.Tournament))
                    correctMatches.Add(match);
            }
            List<int> positions = new List<int>();
            foreach(DbTournament tour in correctTournament)
            {

                List<DbMatch> tourMatches = correctMatches.Where(m => m.Tournament == tour).ToList();
                List<int> points = new List<int>();
                foreach (DbPlayer player in players)                    
                {
                    int currentPoints = 0;
                    foreach (DbMatch match in tourMatches)
                    {
                        if (match.Loser == player)
                            currentPoints += match.LosePoints / 10;
                        if (match.Winner == player)
                            currentPoints += match.WinPoints;
                    }
                    points.Add(currentPoints);
                }
                SortedDictionary<int, DbPlayer> classedPlayers = new SortedDictionary<int, DbPlayer>();
                for(int i = 0; i < players.Count; i++)
                {
                    classedPlayers.Add(points[i], players[i]);
                }
                DbPlayer[] classed = new DbPlayer[players.Count];
                classedPlayers.Values.CopyTo(classed,0);
                for(int i=0; i< players.Count; i++)
                {
                    if (classed[i] == player1) positions.Add(i + 1);
                }
            }
            int result = 0;
            foreach(int pos in positions)
            {
                result += pos;
            }
            return result / correctTournament.Count;

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
            int[] vAndD = new int[2];
            DbPlayer currentP = contexte.Players.First<DbPlayer>(p => p.Pseudo == player.Username);
            List<DbMatch> PlayerMatches = contexte.Matches.Where<DbMatch>(m => m.Winner == currentP || m.Loser == currentP).ToList();
            foreach(DbMatch match in PlayerMatches)
            {
                if (match.Winner == currentP)
                {
                    vAndD[0]++; 
                }else
                if (match.Loser == currentP)
                {
                    vAndD[1]++;
                }
            }
            return vAndD;
        }

        public int TournamentParticipated(Player player)
        {
            return contexte.Players.First<DbPlayer>(p=>p.Pseudo==player.Username).Tournaments.Count;
        }
    }
}
