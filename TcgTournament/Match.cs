using System;
using System.Collections.Generic;
using TcgTournament.Models;
public class Match
{
    private Dictionary<Player, int> result;
	public Match(Player first,Player second)
	{
        this.result = new Dictionary<Player, int>();
        this.result.Add(first,0);
        this.result.Add(second,0);
	}
}
