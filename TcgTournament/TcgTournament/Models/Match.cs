using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TcgTournament.Models
{
    public class Match
    {
        private Dictionary<Player, int> result;
        public Match(Player first, Player second)
        {
            this.result = new Dictionary<Player, int>();
            this.result.Add(first, 0);
            this.result.Add(second, 0);
        }
        public Dictionary<Player,int> Result {
            get { return this.result; }
            set { this.result = value; }
        }
        public Player GetWinner()
        {
            var enumerator= result.GetEnumerator();
            var firstPlayer = enumerator.Current;
            enumerator.MoveNext();
            var secondPlayer = enumerator.Current;            
            if(firstPlayer.Value>secondPlayer.Value)
            {
                return firstPlayer.Key;
            }
            else
            {
                return secondPlayer.Key;
            }
            
        }

        public Player GetLoser()
        {
            var enumerator = result.GetEnumerator();
            var firstPlayer = enumerator.Current;
            enumerator.MoveNext();
            var secondPlayer = enumerator.Current;
            if (firstPlayer.Value < secondPlayer.Value)
            {
                return firstPlayer.Key;
            }
            else
            {
                return secondPlayer.Key;
            }

        }
    }


}
