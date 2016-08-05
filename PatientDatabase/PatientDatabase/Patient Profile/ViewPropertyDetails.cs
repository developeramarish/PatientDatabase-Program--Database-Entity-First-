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
    public partial class ViewPropertyDetails : Form
    {
        public ViewPropertyDetails()
        {
            InitializeComponent();
        }

        private void ViewPropertyDetails_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();    
            dgvViewPropertyDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void FormatDataGridView()
        {
            foreach (DataGridViewColumn dgvtbc in dgvViewPropertyDetails.Columns) { dgvtbc.SortMode = DataGridViewColumnSortMode.NotSortable; }
            dgvViewPropertyDetails.ClearSelection();
        }

        public void DisplayMedication(Medication medication)
        {
            dgvViewPropertyDetails.Columns.Add("cMedicationInfo", "Medication Info");
            dgvViewPropertyDetails.Columns.Add("cColumnBlank", "");

            dgvViewPropertyDetails.Rows.Add("Name", medication.Name);
            dgvViewPropertyDetails.Rows.Add("Type", medication.Type);
            dgvViewPropertyDetails.Rows.Add("Morphine Equivalent", medication.Morphine_Equivalent__mg_);
            dgvViewPropertyDetails.Rows.Add("Generic Name", medication.Generic_Name);
            dgvViewPropertyDetails.Rows.Add("Sustained Release?", getQuestionDisplay(medication.Sustained_Release));
            dgvViewPropertyDetails.Rows.Add("Short Acting?", getQuestionDisplay(medication.Short_Acting));
            lblTitle.Text = "Medication Details";
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            FormatDataGridView();
        }

        public void DisplayPastMedicalHistory(Past_Medical_History pastMedicalHistory)
        {
            dgvViewPropertyDetails.Columns.Add("cPastMedicalHistoryInfo", "Past Medical History Info");
            dgvViewPropertyDetails.Columns.Add("cColumnBlank", "");

            dgvViewPropertyDetails.Rows.Add("Name", pastMedicalHistory.Name);
            lblTitle.Text = "Past Medical History Details";
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            FormatDataGridView();
        }

        public void DisplayPathology(Pathology pathology)
        {
            dgvViewPropertyDetails.Columns.Add("cPathology Info", "Pathology Info");
            dgvViewPropertyDetails.Columns.Add("cColumnBlank", "");

            dgvViewPropertyDetails.Rows.Add("Name", pathology.Name);
            lblTitle.Text = "Pathology Details";
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            FormatDataGridView();
        }

        public void DisplayProblem(Problem problem)
        {
            dgvViewPropertyDetails.Columns.Add("cProblem", "Problem Info");
            dgvViewPropertyDetails.Columns.Add("cColumnBlank", "");

            dgvViewPropertyDetails.Rows.Add("Name", problem.Name);
            lblTitle.Text = "Problem Details";
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            FormatDataGridView();
        }

        public void DisplaySurgery(Surgery surgery)
        {
            dgvViewPropertyDetails.Columns.Add("cSurgeryInfo", "Surgery Info");
            dgvViewPropertyDetails.Columns.Add("cColumnBlank", "");

            dgvViewPropertyDetails.Rows.Add("Name", surgery.Name);
            lblTitle.Text = "Surgery Details";
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            FormatDataGridView();
        }

        public void DisplayTrauma(Trauma trauma)
        {
            dgvViewPropertyDetails.Columns.Add("cTraumaInfo", "Trauma Info");
            dgvViewPropertyDetails.Columns.Add("cColumnBlank", "");

            dgvViewPropertyDetails.Rows.Add("Name", trauma.Name);
            lblTitle.Text = "Trauma Details";
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            FormatDataGridView();
        }

        public void DisplayTreatment(Treatment treatment)
        {
            dgvViewPropertyDetails.Columns.Add("cTreatmentInfo", "Treatment Info");
            dgvViewPropertyDetails.Columns.Add("cColumnBlank", "");

            dgvViewPropertyDetails.Rows.Add("Name", treatment.Name);
            lblTitle.Text = "Treatment Details";
            lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
            FormatDataGridView();
        }

        // for boolean in database, it is represented as 'y' or 'n'
        // this method converts that into "Yes" or "No" for display purposes
        private string getQuestionDisplay(string answer)
        {
            if (answer == "Y") return "Yes";
            else return "No";
        }

        private void ViewPropertyDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }
    }
}
