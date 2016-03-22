using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcgTournament.Controlers;
using TcgTournament.Models;
using TcgTournament.EntityFramework;

namespace TcgTournament.Views
{
    public partial class ResultsView : Form
    {
        Tournament tournament;
        public ResultsView(Tournament tour)
        {
            InitializeComponent();
            tournament = tour;
            tournament.Participating.Sort();
            List<Player> players = tournament.Participating;
            for(int i=0;i<players.Count;i++)
            {
                string place;
                if (i % 10 == 0 && i != 10)
                {
                    place = "" + i+1 + "st";
                } else if (i % 10 == 1 && i != 11)
                {
                    place = "" + i + 1 + "nd";
                }
                if (i % 10 == 2 && i != 12)
                {
                    place = "" + i + 1 + "rd";
                }
                else
                {
                    place = "" + i + 1 + "th";
                }
                PlayerList.Items.Add(players[i].ToString()+" at "+ place + "place");
            }
        }

        private void ResultsView_Load(object sender, EventArgs e)
        {

        }
    }
}
