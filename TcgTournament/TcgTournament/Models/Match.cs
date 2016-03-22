using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TcgTournament.Models
{
    public class Match: IEquatable<Match>
    {
        private Dictionary<Player, int> result;

        
        public Match(Player first, Player second)
        {
            this.result = new Dictionary<Player, int>();
            this.result.Add(first, 0);
            this.result.Add(second, 0);
        }
        public int getPoints(Player p)
        {
            return result[p];
        }
        public Dictionary<Player,int> Result {
            get { return this.result; }
            set { this.result = value; }
        }
        public Player GetWinner()
        {          
            if(result.First().Value>result.Last().Value)
            {
                return result.First().Key;
            }
            else
            {
                return result.Last().Key;
            }
            
        }
        public bool Equals(Match other)
        {
            Player p1 = Player1;
            Player p2 = Player2;
            Player pe = other.Player1;
            Player peb = other.Player2;
            return (p1.Equals(pe) && p2.Equals(peb)) || (p2.Equals(pe) && p1.Equals(peb)); 
        }
        public Player Player1
        {
            get { return result.Keys.First<Player>(); }
        }
        public Player Player2
        {
            get { return result.Keys.Last<Player>(); }
        }
        public bool PlayerOnThisMatch(Player player)
        {
            if (this.Result.ContainsKey(player))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public Player GetLoser()
        {
            if (result.First().Value < result.Last().Value)
            {
                return result.First().Key;
            }
            else
            {
                return result.Last().Key;
            }

        }

        public bool isFreeMatch()
        {
            return result.ContainsKey(new Player(""));
        }

        public Player getFreePlayer()
        {
            if (this.isFreeMatch())
            {
                if (Player1.Username == "")
                {
                    return Player1;
                } else
                {
                    return Player2;
                }
            }
            return null;
        }

        internal int getPlayerIndex(Player player)
        {
            Player[] matchPlayers = new Player[2];
            this.Result.Keys.CopyTo(matchPlayers,0);
            if (player.Equals(matchPlayers[0]))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        internal void ChangePlayer(Player secondP, Player firstP)
        {
            this.Result.Remove(secondP);
            this.Result.Add(firstP,0);
        }
        public bool isComplete()
        {
            return result.Values.First<int>() > 0 || result.Values.Last<int>() > 0;
        }
    }


}
