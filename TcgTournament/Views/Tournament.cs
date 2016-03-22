using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace TcgTournament
{
    public partial class Tournament : Form
    {
        GUI.Settings settings = new GUI.Settings();
        GUI.Tournament tour = new GUI.Tournament();
        private string time;
        private DateTime t;
        private int hour;
        int minute,second;

        public Tournament()
        {
            InitializeComponent();
            time = txtModifyTimer.Text;
         

            settings.datagridsettings(DgvTournament,true,Color.White,1024);
            settings.datagridCollumnsAdd(DgvTournament,"Id_Player1","Player1","Player1 Points","Id_Player2","Player2","Player2 Points");

           t = Convert.ToDateTime("00:" + time);

            hour = t.Hour;
             minute = t.Minute;
            second = t.Second;
            TimerTournament.Start();
            TimerTournament.Interval = 1000;
        }

  
   
 
    
     

        //Timer//
        private void TimerTournament_Tick(object sender, EventArgs e)
        {
            try
            {
               
                second--;

            

                if (second < 1)
                {
                    minute--;
                    second = 59;
                    if (minute < 1)
                    {
                        lblTimer.Text = "00:00";
                        TimerTournament.Stop();
                        MessageBox.Show("tijd is op");
                       

                    }
                }

              
                    lblTimer.Text = minute + ":" + second;
                









            }

            catch (Exception ex)
            {

              
            }

        }

  


        //modify Timer input//
        private void modify_Timer_KeyUp(object sender, KeyEventArgs e)
        {
            string timerchange = "timer";


            
            tour.emptytext(lblModify);

            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
          (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
          e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Enter)
            {
 
            //Enter Key for safe//
            if (e.KeyCode == Keys.Enter)
            {

                time = txtModifyTimer.Text;


                    if (Convert.ToInt32(tour.timeControl(txtModifyTimer)[0]) < 6 ||
                        Convert.ToInt32(tour.timeControl(txtModifyTimer)[1]) < 6)
                    {

                        if (txtModifyTimer.Text.Length == 4 + 1)
                        {
                            //control time and safe the new time// 
                            if (txtModifyTimer.Text.IndexOf(":") == 2 && txtModifyTimer.Text.Length == 5)
                            {

                                tour.setTimer(txtModifyTimer);
                                tour.modifytext(lblModify, timerchange);



                                DateTime t = Convert.ToDateTime("00:" + txtModifyTimer.Text);
                                string uur = t.Hour.ToString();
                                string minuten = t.Minute.ToString();

                                hour = t.Hour;
                                minute = t.Minute;
                                second = t.Second;


                                {
                                }
                            }
                        }
                    
                }
                else
                {
                    MessageBox.Show(tour.getTimeError("InvalidTime"));
                }
            }
            }
            else
            {
                txtModifyTimer.Text = time;
                MessageBox.Show(tour.getTimeError("InvalidToken"));
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

        private void Focus_Enter_Time(object sender, EventArgs e)
        {
            txtModifyTimer.Text = "";
        }

        private void Click_Time(object sender, EventArgs e)
        {
  
            txtModifyTimer.Text = "";
    }

        private void txtModifyTimer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
