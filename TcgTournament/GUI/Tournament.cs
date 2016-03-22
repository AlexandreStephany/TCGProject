using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
  public class Tournament
    {


        public string modifytext(Label txtinput,string modifytext)
        {
            return txtinput.Text = modifytext + " has been changed";
        }

      public string getTimeError(string Error)
      {
          string message = null;

          switch (Error)
          {
                case "InvalidTime":
                     message = "59 is the max value of time";
                  break;
                case "InvalidToken":
                     message = "You can only fill in numbers";             
                    break;
          }
          return message;
      }



        public string emptytext(Label txtinput)
        {
            return txtinput.Text = string.Empty;
        }


      public void setTimer(TextBox txt)
      {
          try
          {
                string hour = "00:";

                DateTime t = Convert.ToDateTime(hour + txt.Text);

                string minutes = t.Minute.ToString();
                string seconds = t.Second.ToString();
            }
          catch (Exception ex)
          {
              
         
          }
 
 
        }


        //control on time
        public string[] timeControl(TextBox txt)
        {
            string[] c = new string[2];       

            c[0] = txt.Text[0].ToString();
            c[1] = txt.Text[3].ToString();
        
            return c;

        }




  
    }
}
