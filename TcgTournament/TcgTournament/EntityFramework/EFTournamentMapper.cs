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

        public void AddAllPlayerInTournament(List<Player> p)
        {
            foreach(Player pl in p)
            {
                AddTournamentParticipation(pl);
            }
        }

        public void AddTournamentParticipation(Player player)
        {
            if (player.Username != null)
            {
                DbPlayer addPlayer = contexte.Players.First<DbPlayer>(p => p.Pseudo == player.Username);
                List<DbTournament> tours = contexte.Tournaments.ToList();
                DbTournament actualTour = tours[tours.Count-1];
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
            contexte.SaveChanges();
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
            List<DbMatch> PlayerMatches = contexte.Matches.Where<DbMatch>(m => (m.Winner.Pseudo == player1.Pseudo || m.Loser.Pseudo == player1.Pseudo) && (m.Winner.Pseudo == player2.Pseudo || m.Loser.Pseudo == player2.Pseudo)).ToList();

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
                List<float> points = new List<float>();
                foreach (DbPlayer player in players)                    
                {
                    float currentPoints = 0;
                    foreach (DbMatch match in tourMatches)
                    {
                        if (match.Loser == player)
                            currentPoints += match.LosePoints / 10;
                        if (match.Winner == player)
                            currentPoints += match.WinPoints;
                    }
                    points.Add(currentPoints);
                }
                SortedDictionary<DbPlayer,float > classedPlayers = new SortedDictionary<DbPlayer, float>();
                var items = from pair in classedPlayers
                            orderby pair.Value ascending
                            select pair;
                int i = players.Count;
                foreach (KeyValuePair<DbPlayer,float> pair in items)
                {
                    if (pair.Key.Pseudo == player1.Pseudo) positions.Add(i);
                    i--;
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
            Player p1 = BothPlayers[0];
            Player p2 = BothPlayers[1];

            if (results[0] > 0 || results[1] > 0)
            {
                List<DbTournament> tours = contexte.Tournaments.ToList();
                DbTournament actualTour = tours[tours.Count - 1];

                DbPlayer player1 = contexte.Players.First<DbPlayer>(p => p.Pseudo.Equals( p1.Username));
                DbPlayer player2 = contexte.Players.First<DbPlayer>(p => p.Pseudo.Equals( p2.Username));
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
            List<DbMatch> PlayerMatches = contexte.Matches.Where(m => (m.Winner.Pseudo.Equals( currentP.Pseudo)) ||( m.Loser.Pseudo.Equals(currentP.Pseudo))).ToList();
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
        public void emptyDb()
        {
            contexte.Matches.RemoveRange(contexte.Matches.ToList());
            contexte.Tournaments.RemoveRange(contexte.Tournaments.ToList());
            contexte.Players.RemoveRange(contexte.Players.ToList());
            contexte.SaveChanges();
            
        }

    }
}
