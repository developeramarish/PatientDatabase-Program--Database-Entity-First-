using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public class GlobalFormManager
    {
        // Keeps tracks of forms open. When ScreenCount is 0, Application exits
        static int ScreenCount = 0;
        // Called in all FormLoad methods
        public static void FormOpen()
        {
            ScreenCount++;
        }
        // Called in all FormClosing methods
        public static void FormClose()
        {
            ScreenCount--;
            if (ScreenCount == 0) { Environment.Exit(0); }
        }

        public static void Home(Form form)
        {
            MainMenu mm = new MainMenu();
            mm.Show();

            // Close all forms besides Main Menu
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name != "MainMenu") Application.OpenForms[i].Close();
            }
            form.Close();
        }
    }
}
