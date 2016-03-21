using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
  public class Tournament
    {

        public void datagridsettings(DataGridView data)
        {
            data.Columns.Add("Id_Player1", "Id_Player1");
            data.Columns.Add("Player1", "Player1");
            data.Columns.Add("Player1 Points", "Player1 Points");
            data.Columns.Add("Id_Player2", "Id_Player2");
            data.Columns.Add("Player2", "Player2");
            data.Columns.Add("Player2 Points", "Player2 Points");
            data.ReadOnly = true;
            data.BackgroundColor = Color.White;
            data.Width = 1024;


            //test data later on this will be changed in          database data//
            data.Rows.Add(1, "player1",1024,2,"Player2",2048);
            data.Rows.Add(4, "player4", 1024, 3, "Player3", 2048);
            /////////////////////////////////////////////////////
        }




        public string modifytext(Label txtinput,string modifytext)
        {
            return txtinput.Text = modifytext + " has been changed";
        }

      public string getTimeError(string Error)
      {
          switch (Error)
          {
                case "InvalidTime":
                  return "59 is the max value of time";
                    break;

                case "InvalidToken":
                  return "You can only fill in numbers";
                  break;
          }
          return null;
      }



        public string emptytext(Label txtinput)
        {
            return txtinput.Text = string.Empty;
        }


      public void setTimer(TextBox txt)
      {
          string hour = "00:";

            DateTime t = Convert.ToDateTime(hour + txt.Text);

            string minutes = t.Minute.ToString();
            string seconds = t.Second.ToString();
 
        }

        public string[] timeControl(TextBox txt)
        {
            string[] c = new string[2];
            

            c[0] = txt.Text[0].ToString();
            c[1] = txt.Text[3].ToString();

              
           
            return c;

        }




  
    }
}
