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
        public void datagridCollumnsAdd(DataGridView data, string player)
        {
            try
            {
      
                data.Columns.Add(player, player);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Add collumn 6 parameters
        public void datagridCollumnsAdd(DataGridView data,string player1, string Player1_Points, string Player2,string Player2_Points )
        {
            try
            {
               
                data.Columns.Add(player1, player1);
                data.Columns.Add(Player1_Points, Player1_Points);
                data.Columns.Add(Player2, Player2);
                data.Columns.Add(Player2_Points, Player2_Points);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


     

        //this method is for fill the datagrid with testdata        later on  this will be changed in database data//
        
    }
}
