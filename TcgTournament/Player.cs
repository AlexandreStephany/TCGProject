using System;

public class Player
{
    private string username;
	public Player(string username)
	{
        this.username = username;
	}
    public string Username {
        get { return this.username; }
        set { this.username = value; }
    }
}
