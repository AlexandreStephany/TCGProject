using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
   public class Settings
    {
        public void datagridsettings(DataGridView data, bool readOnly, Color color, int width)
        {
            try
            {
                data.ReadOnly = readOnly;
                data.BackgroundColor = color;
                data.Width = width;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
         
        }

        //Add Collumn 3 parameters
        public void datagridCollumnsAdd(DataGridView data, string id, string player, string points)
        {
            try
            {
                data.Columns.Add(id, id);
                data.Columns.Add(player, player);
                data.Columns.Add(points, points);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Add collumn 6 parameters
        public void datagridCollumnsAdd(DataGridView data, string id_Player1, string player1, string Player1_Points,string Id_Player2, string Player2,string Player2_Points )
        {
            try
            {
                data.Columns.Add(id_Player1, id_Player1);
                data.Columns.Add(player1, player1);
                data.Columns.Add(Player1_Points, Player1_Points);
                data.Columns.Add(Id_Player2, Id_Player2);
                data.Columns.Add(Player2, Player2);
                data.Columns.Add(Player2_Points, Player2_Points);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


     

        //this method is for fill the datagrid with testdata        later on  this will be changed in database data//
        public void testdata(DataGridView data)
        {
            data.Rows.Add(1, "player1", 10);
            data.Rows.Add(2, "player2", 20);
            data.Rows.Add(3, "player3", 20);
            data.Rows.Add(4, "player4", 21);
            data.Rows.Add(5, "player5", 5);
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
    }
}
