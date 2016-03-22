using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcgTournament.Models;

namespace TcgTournament.EntityFramework.EfModels
{
    public interface TournamentMapper
    {
        void CreatePlayer(Player player);
        void CreateTournament();
        void AddTournamentParticipation(Player player);
        void AddAllPlayerInTournament(List<Player> p);
        void SaveMatch(Match match);
        List<Player> GetAllPlayers();
        int[] GetVictoriesDefeatVS1(Player p1, Player p2);
        int PossiblePosition(Player p, List<Player> other);
        int[] TotalVictoriesAndDefeat(Player player);
        int TournamentParticipated(Player player);
    }
}
