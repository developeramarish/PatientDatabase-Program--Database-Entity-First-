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
    public partial class PatientProfileSelection : Form
    {
        DatabaseAccess database = new DatabaseAccess();
        List<Patient> patients;
        List<Patient> filteredPatients;

        public PatientProfileSelection(List<Patient> patients)
        {
            InitializeComponent();
            this.patients = patients;
        }

        private void PatientProfileSelection_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            LoadDataGridView();
            dgvPatientInfoDisplay.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            cboUsing.SelectedIndex = 0;
            cboCriteria.SelectedIndex = 0;
        }

        // Populates DataGridView with Patient Information
        private void LoadDataGridView()
        {
            patients.ForEach(p => dgvPatientInfoDisplay.Rows.Add(p.Last_Name, p.First_Name, p.Sex, p.Date_of_Birth.ToShortDateString()));
            lblNumberOfRecords.Text = "* Number of Records Shown: " + patients.Count;
        }

        private void PatientProfileSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            dgvPatientInfoDisplay.Rows.Clear();
            if (txtFilter.Text == "") { LoadDataGridView(); }
            else
            {
                filteredPatients = database.loadPatientsFromQuery(new List<Query> { new PatientQuery(cboUsing.Text, cboCriteria.Text, txtFilter.Text) });
                filteredPatients.ForEach(p => dgvPatientInfoDisplay.Rows.Add(p.Last_Name, p.First_Name, p.Sex, p.Date_of_Birth.ToShortDateString()));
                lblNumberOfRecords.Text = "* Number of Records Shown: " + filteredPatients.Count;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenSelectedPatientProfile();
        }

        private void dgvPatientInfoDisplay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenSelectedPatientProfile();
        }

        private void OpenSelectedPatientProfile()
        {
            int id;
            if (txtFilter.Text == "")
                id = patients[dgvPatientInfoDisplay.CurrentRow.Index].Id;
            else
                id = filteredPatients[dgvPatientInfoDisplay.CurrentRow.Index].Id;

            Patient patient = database.loadPatient(id);
            PatientProfile pp = new PatientProfile(patient);
            pp.ShowDialog();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PatientProfilePreSelection ppps = new PatientProfilePreSelection();
            ppps.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();

            // Close all forms besides Main Menu
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name != "MainMenu") Application.OpenForms[i].Close();
            }
            this.Close();
        }
    }
}
