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
    public partial class PatientProfile : Form
    {
        DatabaseAccess database = new DatabaseAccess();
        Patient patient;
        List<PatientMedication> patientMedication;
        List<PatientPast_Medical_History> patientPastMedicalHistory;
        List<PatientPathology> patientPathology;
        List<PatientProblem> patientProblem;
        List<PatientSurgery> patientSurgery;
        List<PatientTrauma> patientTrauma;
        List<PatientTreatment> patientTreatment;

        public PatientProfile(Patient patient)
        {
            this.patient = patient;
            InitializeComponent(); 
        }

        private void PatientProfile_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            LoadDataGridViewPatientProfile();
            LoadDataGridViewDefaultPatientProperties();
        }

        private void LoadDataGridViewPatientProfile()
        {
            dgvPatientInformation.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPatientProperties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvPatientInformation.Rows.Add("Last Name", patient.Last_Name);
            dgvPatientInformation.Rows.Add("First Name", patient.First_Name);
            dgvPatientInformation.Rows.Add("Sex", patient.Sex);
            dgvPatientInformation.Rows.Add("Date of Birth", patient.Date_of_Birth.ToShortDateString());
            dgvPatientInformation.Rows.Add("First Visit", patient.First_Visit.ToShortDateString());
            dgvPatientInformation.Rows.Add("Last Visit", patient.Last_Visit.ToShortDateString());
            dgvPatientInformation.Rows.Add("Address", patient.Address);
            dgvPatientInformation.Rows.Add("City", patient.City);
            dgvPatientInformation.Rows.Add("Zip Code", patient.Zip_Code);
            dgvPatientInformation.Rows.Add("State", patient.State);
            dgvPatientInformation.Rows.Add("Country", patient.Country);
        }

        private void LoadDataGridViewDefaultPatientProperties()
        {
            cboViewSelection.SelectedIndex = 0;
        }

        private void PatientProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void cboViewSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPatientProperties.Columns.Clear();
            dgvPatientProperties.Rows.Clear();
            dgvPatientProperties.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            if (cboViewSelection.Text == "Medication") DisplayMedication();
            else if (cboViewSelection.Text == "Past Medical History") DisplayPastMedicalHistory();
            else if (cboViewSelection.Text == "Pathology") DisplayPathology();
            else if (cboViewSelection.Text == "Problem") DisplayProblem();
            else if (cboViewSelection.Text == "Surgery") DisplaySurgery();
            else if (cboViewSelection.Text == "Trauma") DisplayTrauma();
            else if (cboViewSelection.Text == "Treatment") DisplayTreatment();
            foreach (DataGridViewColumn dgvtbc in dgvPatientProperties.Columns) { dgvtbc.SortMode = DataGridViewColumnSortMode.NotSortable; }
        }

        private void DisplayMedication()
        {
            dgvPatientProperties.Columns.Add("cName", "Name");
            dgvPatientProperties.Columns.Add("cMg", "Mg");
            dgvPatientProperties.Columns.Add("cStartDate", "Start Date");
            dgvPatientProperties.Columns.Add("cEndDate", "End Date");
            patientMedication = database.getPatientMedications(patient);
            patientMedication.ForEach(pm => dgvPatientProperties.Rows.Add(pm.Medication.Name, pm.Mg, pm.Start_Date.ToShortDateString(), getEndDateDisplay(pm.End_Date)));
            btnViewDetails.Text = "View Medication Details";
        }

        private void DisplayPastMedicalHistory()
        {
            dgvPatientProperties.Columns.Add("cName", "Name");
            patientPastMedicalHistory = database.getPatientPastMedicalHistory(patient);
            patientPastMedicalHistory.ForEach(ppmh => dgvPatientProperties.Rows.Add(ppmh.Past_Medical_History.Name));
            btnViewDetails.Text = "View Past Medical History Details";
        }

        private void DisplayPathology()
        {
            dgvPatientProperties.Columns.Add("cName", "Name");
            patientPathology = database.getPatientPathology(patient);
            patientPathology.ForEach(pp => dgvPatientProperties.Rows.Add(pp.Pathology.Name));
            btnViewDetails.Text = "View Pathology Details";
        }

        private void DisplayProblem()
        {
            dgvPatientProperties.Columns.Add("cName", "Name");
            dgvPatientProperties.Columns.Add("cPrimary", "Primary?");
            patientProblem = database.getPatientProblem(patient);
            patientProblem.ForEach(pp => dgvPatientProperties.Rows.Add(pp.Problem.Name, getQuestionDisplay(pp.Primary)));
            btnViewDetails.Text = "View Problem Details";
        }

        private void DisplaySurgery()
        {
            dgvPatientProperties.Columns.Add("cName", "Name");
            dgvPatientProperties.Columns.Add("cDateReceived", "Date Received");
            patientSurgery = database.getPatientSurgery(patient);
            patientSurgery.ForEach(ps => dgvPatientProperties.Rows.Add(ps.Surgery.Name, ps.Date_Received.ToShortDateString()));
            btnViewDetails.Text = "View Surgery Details";
        }

        private void DisplayTrauma()
        {
            dgvPatientProperties.Columns.Add("cName", "Name");
            patientTrauma = database.getPatientTrauma(patient);
            patientTrauma.ForEach(pt => dgvPatientProperties.Rows.Add(pt.Trauma.Name));
            btnViewDetails.Text = "View Trauma Details";
        }

        private void DisplayTreatment()
        {
            dgvPatientProperties.Columns.Add("cName", "Name");
            dgvPatientProperties.Columns.Add("cDateStarted", "Date Started");
            dgvPatientProperties.Columns.Add("cDateEnded", "Date Ended");
            patientTreatment = database.getPatientTreatment(patient);
            patientTreatment.ForEach(pt => dgvPatientProperties.Rows.Add(pt.Treatment.Name, pt.Start_Date.ToShortDateString(), getEndDateDisplay(pt.End_Date)));
            btnViewDetails.Text = "View Treatment Details";
        }

        // for boolean in database, it is represented as 'y' or 'n'
        // this method converts that into "Yes" or "No" for display purposes
        private string getQuestionDisplay(string answer)
        {
            if (answer == "Y") return "Yes";
            else return "No";
        }

        // checks end date -- if it's 12/31/9999, it means there is no end date because it's currently ongoing
        private string getEndDateDisplay(DateTime endDate)
        {
            string _endDate = endDate.ToShortDateString();
            if (_endDate == "12/31/9999")
            {
                return "None";
            }
            return _endDate;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // return back to PatientProfileSelection form
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            ViewPropertyDetails vpd = new ViewPropertyDetails();

            if (cboViewSelection.Text == "Medication")
                vpd.DisplayMedication(patientMedication[dgvPatientProperties.CurrentRow.Index].Medication);
            else if (cboViewSelection.Text == "Past Medical History")
                vpd.DisplayPastMedicalHistory(patientPastMedicalHistory[dgvPatientProperties.CurrentRow.Index].Past_Medical_History);
            else if (cboViewSelection.Text == "Pathology")
                vpd.DisplayPathology(patientPathology[dgvPatientProperties.CurrentRow.Index].Pathology);
            else if (cboViewSelection.Text == "Problem")
                vpd.DisplayProblem(patientProblem[dgvPatientProperties.CurrentRow.Index].Problem);
            else if (cboViewSelection.Text == "Surgery")
                vpd.DisplaySurgery(patientSurgery[dgvPatientProperties.CurrentRow.Index].Surgery);
            else if (cboViewSelection.Text == "Trauma")
                vpd.DisplayTrauma(patientTrauma[dgvPatientProperties.CurrentRow.Index].Trauma);
            else if (cboViewSelection.Text == "Treatment")
                vpd.DisplayTreatment(patientTreatment[dgvPatientProperties.CurrentRow.Index].Treatment);

            vpd.ShowDialog();
        }
    }
}
