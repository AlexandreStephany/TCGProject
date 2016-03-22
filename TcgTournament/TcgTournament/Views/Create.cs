using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcgTournament.Controlers;
using TcgTournament.EntityFramework;
using TcgTournament.Models;
using GUI;

namespace TcgTournament
{
    public partial class Create : Form
    {
        public CreationControler controler;
        public Players father;
        public Create(Models.Tournament tour, EFTournamentMapper mapp, Players pl)
        {
            controler = new CreationControler(tour, mapp);
            father = pl;
            InitializeComponent();
             
        }
        Models.AddData data = new Models.AddData();

     
        
        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCreatePlayer.Text))
            {
                MessageBox.Show("Player name is required!");
                
            } else if (controler.Mapper.GetAllPlayers().Contains(controler.Player))
            {
                MessageBox.Show("This player already exists");

                
            }
            else
            {
                controler.saveNewPlayer(txtCreatePlayer.Text);
                MessageBox.Show(data.AddUser(txtCreatePlayer));
                father.OnFocus();
                this.Close();

            }
      
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }

        
    }

