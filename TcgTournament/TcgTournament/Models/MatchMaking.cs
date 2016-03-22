using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcgTournament.Models
{
    public static class MatchMaking
    {
        

        // Round Robin
        public static Dictionary<int, List<Match>> ListMatches(List<Player> ListPlayers)
        {
            Dictionary<int, List<Match>> rounds = new Dictionary<int, List<Match>>();

            if (ListPlayers.Count % 2 != 0)
            {
                ListPlayers.Add(new Player(""));
            }

            int numRounds = (ListPlayers.Count - 1);
            int halfSize = ListPlayers.Count / 2;

            List<Player> players = new List<Player>();

            players.AddRange(ListPlayers.Skip(halfSize).Take(halfSize));
            players.AddRange(ListPlayers.Skip(1).Take(halfSize - 1).ToArray().Reverse());

            int playersSize = players.Count;

            for (int round = 0; round < numRounds; round++)
            {
                List<Match> roundMatches = new List<Match>();

                int playerIndex = round % playersSize;

                roundMatches.Add(new Match(players[playerIndex], ListPlayers[0]));

                for (int idx = 1; idx < halfSize; idx++)
                {
                    int firstPlayer = (round + idx) % playersSize;
                    int secondPlayer = (round + playersSize - idx) % playersSize;
                    roundMatches.Add(new Match(players[firstPlayer], players[secondPlayer]));
                }

                rounds.Add(round, roundMatches);
            }
            return rounds;
        }
        //DutchPairing
        public static List<Match> generateNextRound(List<Player> ranking, List<Match> playedMatches)
        {
            List<Player> workRanking = new List<Player>(ranking);
            List<Match> matches = new List<Match>();
            Match freeMatch;
            if (ranking.Count % 2 == 1)
            {
                Random rand = new Random();
                int freePlayer;
                do
                {
                    freePlayer = rand.Next(workRanking.Count);
                    freeMatch = new Match(workRanking[freePlayer], new Player(""));
                } while (playedMatches.Contains(freeMatch));
                workRanking.Remove(workRanking[freePlayer]);
            } else { freeMatch = null; }
            bool[] playing = new bool[workRanking.Count];
            List<int[]> idPlayers = new List<int[]>();
            List<int> rewindValue = new List<int>();
            for (int i = 0; i < workRanking.Count; i++)
            {
                rewindValue.Add(i);
            }

            for (int i = 0; i < workRanking.Count - 1; i++)
            {
                if (!playing[i])
                {
                    Match m;
                    int j = rewindValue[i];
                    if (j < workRanking.Count - 1)
                    {

                        // Search for first unplayed match for player i
                        do
                        {
                            j++;
                            if (!playing[j])
                            {
                                m = new Match(workRanking[i], workRanking[j]);
                            }
                            else
                            {
                                m = null;
                            }
                        }
                        while ((m == null || playedMatches.Contains(m)) && j < workRanking.Count - 1);


                        if (playedMatches.Contains(m) || m == null) // if no new match for player i => change previous
                        {
                            // Remove match from match list
                            Match lastMatch = matches.Last<Match>();
                            matches.Remove(lastMatch);
                            // Set players from last match as free
                            int[] toRemove = idPlayers.Last<int[]>();
                            playing[toRemove[0]] = false;
                            playing[toRemove[1]] = false;
                            // Remove match from pairing list
                            idPlayers.Remove(idPlayers.Last<int[]>());
                            // Rollback to last player
                            i = toRemove[0] - 1;
                        }
                        else
                        {
                            // Add match to match list
                            matches.Add(m);
                            // Set players as not free
                            playing[i] = true;
                            playing[j] = true;
                            // Save match to pairing list
                            idPlayers.Add(new int[] { i, j });
                            // Set value from pair for future rollbacks
                            rewindValue[i] = j;
                            for (int k = i + 1; k < workRanking.Count; k++)
                            {
                                rewindValue[k] = k;
                            }
                        }
                    }
                    else
                    {
                        // Remove match from match list
                        Match lastMatch = matches.Last<Match>();
                        matches.Remove(lastMatch);
                        // Set players from last match as free
                        int[] toRemove = idPlayers.Last<int[]>();
                        playing[toRemove[0]] = false;
                        playing[toRemove[1]] = false;
                        // Remove match from pairing list
                        idPlayers.Remove(idPlayers.Last<int[]>());
                        // Rollback to last player
                        i = toRemove[0] - 1;
                    }
                }
            }


            if (ranking.Count % 2 == 1) matches.Add(freeMatch);
            return matches;
        }

    }
}
