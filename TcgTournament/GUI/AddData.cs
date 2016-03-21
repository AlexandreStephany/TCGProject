using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
   public class AddData
    {

        //Add data to TournamentGrid
       public void AddDataToGrid(DataGridView data,int id_player1,string player1,int player1_points,int id_player2,string player2,int player2_points)
       {
            data.Rows.Add(id_player1, player1, player1_points, id_player2, player2, player2_points);
        }


        //Add data to PlayerGrid
       public void AddDataToGrid(DataGridView data,int id,string player,int points)
       {
            data.Rows.Add(id, player, points);
       }


       public void AddUser()
       {
           MessageBox.Show("user created");
       }
    }
}
