using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcgTournament.Models;
using TcgTournament.EntityFramework;
namespace TcgTournament.Controlers
{
    public class PlayersController: SuperControler
    {
        private List<Player> players;
        public PlayersController(Tournament tournament,EFTournamentMapper mapp ):base(tournament,mapp)
        {
            Players = mapp.GetAllPlayers();
        }

        public List<Player> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
            }
        }
    }
}
