using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TcgTournament.Models
{
    public class Player
    {
        private string username;
        private int victoryPoints;
        private int resistancePoints;
        public Player(string username)
        {
            this.username = username;
            this.resistancePoints = 0;
            this.victoryPoints = 0;
        }
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public int VictoryPoints
        {
            get { return this.victoryPoints; }
            set { this.victoryPoints = value; }
        }
        public int ResistancePoints
        {
            get { return this.resistancePoints; }
            set { this.resistancePoints = value; }
        }
    }
}
