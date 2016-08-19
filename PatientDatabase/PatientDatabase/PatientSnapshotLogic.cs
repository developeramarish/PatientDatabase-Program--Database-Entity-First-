using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public class PatientSnapshotLogic
    {
        Patient patient;
        DatabaseAccess database;
        ChartData chartData;
        CommonUIMethodsAndFunctions commonUI;

        public PatientSnapshotLogic(Patient patient)
        {
            this.patient = patient;
            database = new DatabaseAccess();
            chartData = new ChartData();
            commonUI = new CommonUIMethodsAndFunctions();
        }

        public void onFormLoad()
        {

        }

        public void back(Form form)
        {

        }
    }
}
