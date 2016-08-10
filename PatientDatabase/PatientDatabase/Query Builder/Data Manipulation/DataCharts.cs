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
    public partial class DataCharts : Form
    {
        List<Patient> patients;

        public DataCharts(List<Patient> patients)
        {
            InitializeComponent();
            this.patients = patients;
        }

        private void DataCharts_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();



        }

        private void DataCharts_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }
    }
}
