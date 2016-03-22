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
using System.Windows.Forms.VisualStyles;
using Microsoft.SqlServer.Server;
using TcgTournament.EntityFramework;
using TcgTournament.Models;
using TcgTournament.Controlers;
using TcgTournament.Views;


namespace TcgTournament
{
    public partial class TournamentView : Form
    {
        GUI.Settings settings = new GUI.Settings();
        GUI.Tournament tour = new GUI.Tournament();
        AddData add = new AddData();
        private string time;
        private DateTime t;
        private int hour;
        int minute,second ;
        int? secondsecond;
        TournamentControler controler;

        public TournamentView()
        {
            InitializeComponent();
            time = txtModifyTimer.Text;
         

            settings.datagridsettings(DgvTournament,false,Color.White,1024);
            settings.datagridCollumnsAdd(DgvTournament,"Player1","Player1 Points","Player2","Player2 Points");
            
           t = Convert.ToDateTime("00:" + time);

          
            minute = t.Minute;
            second = t.Second;
            TimerTournament.Interval = 1000;
        }

        public TournamentView(Tournament actualTournament, EFTournamentMapper mapper, List<Player> players)
        {
            InitializeComponent();
            time = txtModifyTimer.Text;


            settings.datagridsettings(DgvTournament, false, Color.White, 1024);
            settings.datagridCollumnsAdd(DgvTournament, "Player1", "Player1 Points", "Player2", "Player2 Points");
            DgvTournament.Columns["Player1"].ReadOnly = true;
            DgvTournament.Columns["Player2"].ReadOnly = true;

            t = Convert.ToDateTime("00:" + time);


            minute = t.Minute;
            second = t.Second;
            TimerTournament.Interval = 1000;
            DgvTournament.AllowUserToAddRows = false;
            TimerTournament.Stop();
            this.controler = new TournamentControler(actualTournament,mapper,players);
            foreach(Match m in controler.Round)
            {
                add.AddDataToGrid(DgvTournament, m);
            }
           
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
                        
                        TimerTournament.Stop();
                        minute = 0;
                        second = 0;
                        MessageBox.Show("Time is up");
                       

                    }
                }

                if (second < 10)
                {
                    secondsecond = 0;
                }
                else
                {
                    secondsecond = null;
                }

             

              
         
                lblTimer.Text = String.Format("{0}:{1}{2}", minute, secondsecond,second);


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

        private void Regen_Click(object sender, EventArgs e)
        {
            this.controler.ChangeMatches();
            this.DgvTournament.Rows.Clear();
            foreach(Match m in controler.Round)
            {
                add.AddDataToGrid(DgvTournament, m);
            }
        }
        public bool CoherentValues()
        {
            try
            {
                DataGridViewRowCollection rows = DgvTournament.Rows;
                foreach (DataGridViewRow row in rows)
                {
                    DataGridViewCellCollection cells = row.Cells;
                    int res1 = Int32.Parse(cells[1].Value.ToString().Trim());
                    int res2 = Int32.Parse(cells[3].Value.ToString().Trim());
                    if (res1 == res2)
                    {
                        MessageBox.Show("There are rounds not completed!");
                        return false;
                    }
                }
            } catch (Exception e)
            {
                MessageBox.Show("Scores should be numbers.");
                return false;
            }

            return true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (CoherentValues())
            
            {
                
                MessageBox.Show("Round complete!");
               
                    DataGridViewRowCollection rows = DgvTournament.Rows;

                    List<Dictionary<Player, int>> results = new List<Dictionary<Player, int>>();
                    foreach (DataGridViewRow row in rows)
                    {
                        DataGridViewCellCollection cells = row.Cells;
                        Dictionary<Player, int> result = new Dictionary<Player, int>();
                        Player p1 = new Player(cells[0].Value.ToString().Trim());
                        int res1 = Int32.Parse(cells[1].Value.ToString().Trim());
                        Player p2 = new Player(cells[2].Value.ToString().Trim());
                        int res2 = Int32.Parse(cells[3].Value.ToString().Trim());
                        result.Add(p1, res1);
                        result.Add(p2, res2);
                        results.Add(result);
                    }
                    controler.SaveResult(results);
                    controler.CompleteMatches();
                if (controler.ActualTournament.Participating.Count - 1 >= controler.ActualTournament.MatchesByRound.Count)
                {
                    DgvTournament.Rows.Clear();
                    foreach (Match m in controler.Round)
                    {
                        add.AddDataToGrid(DgvTournament, m);
                    }
                    TimerTournament.Stop();
                }
                else
                {
                    TimerTournament.Stop();
                    new ResultsView(controler.ActualTournament).Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimerTournament.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new ResultsView(controler.ActualTournament).Show();
        }

        private void txtModifyTimer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
