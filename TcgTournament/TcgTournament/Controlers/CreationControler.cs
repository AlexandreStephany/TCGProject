using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcgTournament.EntityFramework;
using TcgTournament.Models;

namespace TcgTournament.Controlers
{
    public class CreationControler: SuperControler
    {
        Player player;
        public CreationControler(Tournament tour , EFTournamentMapper mapp): base(tour, mapp)
        {
            Player = new Player();
        }

        public Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }

        public void saveNewPlayer(string name)
        {
            Player.Username = name;
            Mapper.CreatePlayer(Player);
        }
    }
}
