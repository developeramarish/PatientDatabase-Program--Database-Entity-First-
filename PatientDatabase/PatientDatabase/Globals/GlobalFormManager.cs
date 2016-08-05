using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
