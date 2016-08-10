using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public partial class QueryResultStatistics : Form
    {
        List<Patient> patients;

        public QueryResultStatistics(List<Patient> patients)
        {
            InitializeComponent();
            this.patients = patients;
        }

        private void QueryResultStatistics_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
        }

        private void QueryResultStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }
    }
}
