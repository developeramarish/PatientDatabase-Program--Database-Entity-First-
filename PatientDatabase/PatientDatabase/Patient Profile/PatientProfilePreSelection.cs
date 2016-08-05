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
    public partial class PatientProfilePreSelection : Form
    {
        DatabaseAccess database = new DatabaseAccess();
        List<Patient> patients;

        public PatientProfilePreSelection()
        {
            InitializeComponent();
        }

        private void PatientProfilePreSelection_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            cboUsing.SelectedIndex = 0;
            cboCriteria.SelectedIndex = 0;
            lblNumberOfRecords.Text = "* Total Number of Patient Records: " + database.getTableRecordCount("Patient").ToString();
        }

        private void PatientProfilePreSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void btnLoadPatientDatabase_Click(object sender, EventArgs e)
        {
            List<Query> queries = new List<Query> { new PatientQuery(cboUsing.Text, cboCriteria.Text, txtFilter.Text) };
            queries = formatQueriesList(queries);
            patients = database.loadPatientsFromQuery(queries);

            if (patients.Count == 0)
                MessageBox.Show("No results to show.", "Error");
            else
            {
                PatientProfileSelection pps = new PatientProfileSelection(patients);
                pps.Show();
                this.Close();
            }
        }

        // applies continue and standalone groups where needed to each query for structuring purposes
        private List<Query> formatQueriesList(List<Query> queries)
        {
            if (queries.Count > 0) queries[0].And = true; // first query MUST be AND otherwise it won't work
            for (int i = 0; i < queries.Count; i++)
            {
                if (queries[i].And && locationExistsInQueriesList(i + 1, queries))
                {
                    if (!queries[i + 1].Or) queries[i].StandAlone = true;
                    else if (queries[i + 1].Or) queries[i].StartGroup = true;
                }
                else if (queries[i].And && !locationExistsInQueriesList(i + 1, queries)) queries[i].StandAlone = true;
                else if (queries[i].Or && locationExistsInQueriesList(i + 1, queries))
                {
                    if (!queries[i + 1].Or) queries[i].EndGroup = true;
                    else if (queries[i + 1].Or) queries[i].ContinueGroup = true;
                }
                else if (queries[i].Or && !locationExistsInQueriesList(i + 1, queries)) queries[i].EndGroup = true;
            }
            return queries;
        }

        private bool locationExistsInQueriesList(int index, List<Query> queries)
        {
            return index >= 0 & index <= queries.Count - 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
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
