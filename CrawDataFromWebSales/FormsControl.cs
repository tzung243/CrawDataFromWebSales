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
