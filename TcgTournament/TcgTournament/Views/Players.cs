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
    public partial class Players : Form
    {

        //class libary call//
         GUI.Players settings = new GUI.Players();

        //variables//
        private DataGridViewRow row;
        private int howmanyplayersleftcounter = 0;
       

        public Players()
        {
            InitializeComponent();
            settings.datagridsettings(DgvPlayers);
            settings.datagridsettings(DgvPlayersTo);
            settings.testdata(DgvPlayers);
            labeldata();
        }


      

        //button create player//
        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            new Create().Show();
        }


        //button add player to datagrid//
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                row = this.DgvPlayers.Rows[DgvPlayers.SelectedRows[0].Index];

                DgvPlayers.Rows.Remove(row);


                DgvPlayersTo.Rows.Add(row);

                howmanyplayersleftcounter++;
                labeldata();

                controls();
            }
            catch (NullReferenceException)
            {
                settings.PleaseSelectPlayerMessage();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (InvalidOperationException)
            {
                settings.PleaseSelectPlayerMessage();
            }
        }

   
        //button remove player from datagrid//
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                row = this.DgvPlayersTo.Rows[DgvPlayersTo.SelectedRows[0].Index];

                DgvPlayersTo.Rows.Remove(row);


                DgvPlayers.Rows.Add(row);

                howmanyplayersleftcounter--;
                labeldata();

                controls();
            }
            catch (NullReferenceException)
            {
                settings.PleaseSelectPlayerMessage();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (InvalidOperationException)
            {
              settings.PleaseSelectPlayerMessage();
            }

        }


        //button start tournament//
        private void btnStart_Click(object sender, EventArgs e)
        {
            new Tournament().Show();
        }


        //double click datagrid left open player statics//
        private void Dgv_Players_doubleclick(object sender, DataGridViewCellEventArgs e)
        {
            row = this.DgvPlayers.Rows[DgvPlayers.SelectedRows[0].Index];
            DataForPlayerStaticsForm(row);
        }


        //double click datagrid right side open player statics//
        private void Dgv_PlayersTo_doubleclick(object sender, DataGridViewCellEventArgs e)
        {
            row = this.DgvPlayersTo.Rows[DgvPlayersTo.SelectedRows[0].Index];

            DataForPlayerStaticsForm(row);
        }






        //internal methods//


            //show labels above datagrids//
        private void labeldata()
        {
            int datagridcount = DgvPlayers.Rows.Count - 1;
            lblPlayerCount.Text = datagridcount.ToString();
            lblPlayersLeft.Text = howmanyplayersleftcounter + "/" + 12;
        }


        //method for open player static window//
        private void DataForPlayerStaticsForm(DataGridViewRow row)
        {
            try
            {
                string id = row.Cells[0].Value.ToString();
                string player = row.Cells[1].Value.ToString();
                int points = Convert.ToInt32(row.Cells[2].Value);

                new PlayerStatistics(id, player, points).Show();
            }
            catch (NullReferenceException)
            {
                settings.PleaseSelectPlayerMessage();
            }
        }



        //control on add / remove and start button when they are active or not//
        public void controls()
        {
            if (DgvPlayersTo.Rows.Count == 0 + 1)
            {
                btnAdd.Enabled = true;
                btnRemove.Enabled = false;
                btnStart.Enabled = false;
            }
            else if (DgvPlayersTo.Rows.Count >= 12 + 1)
            {
                btnAdd.Enabled = true;
                btnAdd.Enabled = false;
                btnRemove.Enabled = true;
            }
            else if (DgvPlayersTo.Rows.Count >= 5 + 1)
            {
                btnAdd.Enabled = true;
                btnStart.Enabled = true;
            }
            else if (DgvPlayersTo.Rows.Count >= 2 + 1)
            {
                btnStart.Enabled = false;
                btnRemove.Enabled = true;
                btnAdd.Enabled = true;
            }

            else if (DgvPlayers.Rows.Count != 0 + 1)
            {
                btnAdd.Enabled = true;
                btnRemove.Enabled = true;
                btnStart.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnStart.Enabled = false;
                btnRemove.Enabled = true;
            }
        }
    }
}
