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
            logic.onFormLoad(panelGeneral, panelChart);
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

        private void dgvPatientGeneralInfo_SelectionChanged(object sender, EventArgs e)
        {
            dgvPatientGeneralInfo.ClearSelection();
        }

        private void cboProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.ProtocolComboBoxIndexChanged(cboProtocol, cboOutcome, cboEndInterval, chartOutcomeData);
        }

        private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.OutcomeComboBoxIndexChanged(cboOutcome, chartOutcomeData);
        }

        private void cboStartInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.StartIntervalComboBoxIndexChanged(cboStartInterval, chartOutcomeData);
        }

        private void cboEndInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.EndIntervalComboBoxIndexChanged(cboEndInterval, cboStartInterval, chartOutcomeData);
        }
    }
}
