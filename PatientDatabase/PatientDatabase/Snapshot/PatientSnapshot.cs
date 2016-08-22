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
    public partial class PatientSnapshot : Form
    {
        PatientSnapshotLogic logic;

        public PatientSnapshot(Patient patient)
        {
            InitializeComponent();
            logic = new PatientSnapshotLogic(patient);
        }

        private void PatientSnapshot_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            logic.onFormLoad(panelGeneral);
        }

        private void PatientSnapshot_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GlobalFormManager.OpenNewForm(new MainMenu(), this);
            GlobalFormManager.CloseCurrentForm(this);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GlobalFormManager.Home(this);
        }
    }
}
