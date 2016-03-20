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

namespace TcgTournament
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
             
        }

     
        
        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCreatePlayer.Text))
            {
                MessageBox.Show("Player name is required!");
                
            }
            else
            {
                MessageBox.Show(txtCreatePlayer.Text + " " + "has been successfully created");
                this.Close();
            }
      
        }

     
        }

        
    }

