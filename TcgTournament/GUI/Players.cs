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
