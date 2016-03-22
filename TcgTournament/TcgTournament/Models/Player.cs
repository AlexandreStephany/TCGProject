using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TcgTournament.Models
{
    
    public class Player: IComparable, IEquatable<Player>
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
        public Player()
        {
            this.username = "";
            this.resistancePoints = 0;
            this.victoryPoints = 0;
        }


        public int CompareTo(object player2)
        {
            if (player2 != null)
            {
                Player playerCompared = player2 as Player;
                if (playerCompared != null)
                {
                    if (playerCompared.VictoryPoints < this.VictoryPoints)
                    {
                        return -1;
                    } else if(playerCompared.VictoryPoints> this.VictoryPoints)
                    {
                        return 1;
                    }
                    else
                    {
                        if (playerCompared.ResistancePoints < this.ResistancePoints)
                        {
                            return -1; 
                        }else if(playerCompared.ResistancePoints> this.ResistancePoints){
                            return 1;
                        }else{
                            return 0;
                        }

                    }
                }
                else
                {
                    throw new ArgumentException("Object is not a Player");
                }
            }
            else
            {
                throw new ArgumentException("Object is null");
            } 
        }

        public bool Equals(Player other)
        {
            return other != null && other.Username.Trim() == Username.Trim();
        }
        public string ToString()
        {
            return this.Username + " : " + "Victory points " + this.victoryPoints + " / " + " Resistance points " + this.ResistancePoints;
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
