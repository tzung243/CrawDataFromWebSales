using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawDataFromWebSales
{
    public class FormsControl
    {
        public static void switchMainForm(Form oldForm, Form newForm)
        {
            oldForm.Hide();
            newForm.ShowDialog();
            oldForm.Close();
        }
    }
}
