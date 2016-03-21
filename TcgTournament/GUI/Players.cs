using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class Players
    {

        //datagrid settings player window//
        public void datagridsettings(DataGridView data)
        {
            data.Columns.Add("Id", "Id");
            data.Columns.Add("Player", "Player");
            data.Columns.Add("points", "points");
            data.ReadOnly = true;
            data.BackgroundColor = Color.White;
            data.Width = 243;
        }

        //this method is for fill the datagrid with testdata        later on change this will be changed in database data//
        public void testdata(DataGridView data)
        {
            data.Rows.Add(1, "player1",10);
            data.Rows.Add(2, "player2",20);
            data.Rows.Add(3, "player3",20);
            data.Rows.Add(4, "player4",21);
            data.Rows.Add(5, "player5",5);
            data.Rows.Add(6, "player6", 10);
            data.Rows.Add(7, "player7", 20);
            data.Rows.Add(8, "player8", 20);
            data.Rows.Add(9, "player9", 21);
            data.Rows.Add(10, "player10", 5);
            data.Rows.Add(11, "player11", 10);
            data.Rows.Add(12, "player12", 20);
            data.Rows.Add(13, "player13", 20);
            data.Rows.Add(14, "player14", 21);
            data.Rows.Add(15, "player15", 5);
        }


        //alert for select player//
        public void PleaseSelectPlayerMessage()
        {
            MessageBox.Show("Please select a player","Error");
        }



        public void DataForPlayerStaticsForm(DataGridViewRow row)
        {
            try
            {
                string id = row.Cells[0].Value.ToString();
                string player = row.Cells[1].Value.ToString();
                int points = Convert.ToInt32(row.Cells[2].Value);

               
            }
            catch (NullReferenceException)
            {
                PleaseSelectPlayerMessage();
            }
        }

    }
}
