using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcgTournament.Models
{
   public class AddData
    {

        //Add data to TournamentGrid
       public void AddDataToGrid(DataGridView data,Match m)
       {
           try
           {
                string p1 = m.Player1.Username.ToString();
                string p2 = m.Player2.Username.ToString();
                data.Rows.Add( p1, m.Result.Values.First(), p2, m.Result.Values.Last());
            }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
           
        }


        //Add data to PlayerGrid
       public void AddDataToGrid(DataGridView data,Player p)
       {
           try
           {
                data.Rows.Add(p.Username);
            }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       
       }


       public string AddUser(TextBox txt)
       {
          
            return txt.Text + " " + "has been successfully created";
        }
    }
}
