using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcgTournament
{
    public partial class PlayerStatistics : Form
    {
        public PlayerStatistics()
        {
            InitializeComponent();
           
        }



        //show user data//
        public PlayerStatistics(string id,string player,int points)
        {
            InitializeComponent();
            lblId.Text = id;
            lblPlayer.Text = player;
            lblPoints.Text = points.ToString();
        }

        private void PlayerStatistics_Load(object sender, EventArgs e)
        {

        }
    }
}
