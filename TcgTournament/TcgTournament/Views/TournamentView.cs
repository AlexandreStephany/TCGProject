using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace TcgTournament
{
    public partial class TournamentView : Form
    {
        GUI.Tournament tour = new GUI.Tournament();

        public TournamentView()
        {
            InitializeComponent();
            tour.datagridsettings(DgvTournament);
        }


     

        //Timer//
        private void TimerTournament_Tick(object sender, EventArgs e)
        {
      
            
    
          //  TimerTournament.Start();

         

         //   MessageBox.Show(tijd.ToShortTimeString());
        }


        //modify Timer input//
        private void modify_Timer_KeyUp(object sender, KeyEventArgs e)
        {
            string timerchange = "timer";
            
            tour.emptytext(lblModify);
            //Enter Key for safe//
            if (e.KeyCode == Keys.Enter)
            {
              
                if (txtModifyTimer.Text.Length == 4 + 1)
                {
                    //control time and safe the new time// 
                    if (txtModifyTimer.Text.IndexOf(":") == 2 && txtModifyTimer.Text.Length == 5)
                    {
                        tour.modifytext(lblModify, timerchange);
                    }
                }
            }

    
            //create tetbox time format//
            if (txtModifyTimer.Text.Length == 2)
            {
                if (txtModifyTimer.Text.IndexOf(":") == -1)
                {
                    txtModifyTimer.Text += ":";
                }
              
                txtModifyTimer.SelectionStart = txtModifyTimer.Text.Length;

            }
           
        }

        private void txtModifyTimer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
