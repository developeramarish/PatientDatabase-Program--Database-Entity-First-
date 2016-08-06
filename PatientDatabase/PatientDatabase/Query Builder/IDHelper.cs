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
    public partial class IDHelper : Form
    {
        DatabaseAccess database = new DatabaseAccess();
        string helper;
        TextBox txtReqEntity;
        int selectedRow;

        public IDHelper(string helper, TextBox txtReqEntity)
        {
            InitializeComponent();
            this.helper = helper;
            this.txtReqEntity = txtReqEntity;
        }

        private void IDHelper_Load(object sender, EventArgs e)
        {
            dgvIdHelper.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            lblHelper.Text = getLabelText();
            lblHelper.Left = (this.ClientSize.Width - lblHelper.Width) / 2;
            loadDataGridViewColumns();
        }

        private string getLabelText()
        {
            switch (helper)
            {
                case "Medication": return "Medication ID Helper";
                case "Past Medical History": return "Past Medical History ID Helper";
                case "Pathology": return "Pathology ID Helper";
                case "Problem": return "Problem ID Helper";
                case "Surgery": return "Surgery ID Helper";
                case "Trauma": return "Trauma ID Helper";
                case "Treatment": return "Treatment ID Helper";
                default: return "ID Helper";
            }
        }

        public void loadDataGridViewColumns()
        {
            switch (helper)
            {
                case "Medication": LoadMedicationColumns(); break;
                case "Past Medical History": LoadPastMedicalHistoryColumns(); break;
                case "Pathology": LoadPathologyColumns(); break;
                case "Problem": LoadProblemColumns(); break;
                case "Surgery": LoadSurgeryColumns(); break;
                case "Trauma": LoadTraumaColumns(); break;
                case "Treatment": LoadTreatmentColumns(); break;
                default: break;
            }        
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            dgvIdHelper.Rows.Clear();
            switch (helper)
            {
                case "Medication": LoadMedicationData(); break;
                case "Past Medical History": LoadPastMedicalHistoryData(); break;
                case "Pathology": LoadPathologyData(); break;
                case "Problem": LoadProblemData(); break;
                case "Surgery": LoadSurgeryData(); break;
                case "Trauma": LoadTraumaData(); break;
                case "Treatment": LoadTreatmentData(); break;
                default: break;
            }
            foreach (DataGridViewColumn column in dgvIdHelper.Columns) { column.SortMode = DataGridViewColumnSortMode.NotSortable; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadMedicationColumns()
        {
            dgvIdHelper.Columns.Add("cID", "ID");
            dgvIdHelper.Columns.Add("cName", "Name");
            dgvIdHelper.Columns.Add("cType", "Type");
            dgvIdHelper.Columns.Add("cGenericName", "Generic Name");
            dgvIdHelper.Columns.Add("cMorphineEquivalent", "Morphine Equivalent (Mg)");
            dgvIdHelper.Columns.Add("cSustainedRelease", "Sustained Release?");
            dgvIdHelper.Columns.Add("cShortActing", "Short Acting?");
        }

        private void LoadMedicationData()
        {
            List<Medication> medication = database.loadMedicationTable(txtFilter.Text);
            medication.ForEach(m => dgvIdHelper.Rows.Add(m.Id, m.Name, m.Type, m.Generic_Name, m.Morphine_Equivalent__mg_, m.Sustained_Release, m.Short_Acting));
        }

        private void LoadPastMedicalHistoryColumns()
        {
            dgvIdHelper.Columns.Add("cID", "ID");
            dgvIdHelper.Columns.Add("cName", "Name");
        }

        private void LoadPastMedicalHistoryData()
        {
            List<Past_Medical_History> pastMedicalHistory = database.loadPastMedicalHistoryTable(txtFilter.Text);
            pastMedicalHistory.ForEach(pmh => dgvIdHelper.Rows.Add(pmh.Id, pmh.Name));
        }

        private void LoadPathologyColumns()
        {
            dgvIdHelper.Columns.Add("cID", "ID");
            dgvIdHelper.Columns.Add("cName", "Name");
        }

        private void LoadPathologyData()
        {
            List<Pathology> pathology = database.loadPathologyTable(txtFilter.Text);
            pathology.ForEach(p => dgvIdHelper.Rows.Add(p.Id, p.Name));
        }

        private void LoadProblemColumns()
        {
            dgvIdHelper.Columns.Add("cID", "ID");
            dgvIdHelper.Columns.Add("cName", "Name");
        }

        private void LoadProblemData()
        {
            List<Problem> problem = database.loadProblemTable(txtFilter.Text);
            problem.ForEach(p => dgvIdHelper.Rows.Add(p.Id, p.Name));
        }

        private void LoadSurgeryColumns()
        {
            dgvIdHelper.Columns.Add("cID", "ID");
            dgvIdHelper.Columns.Add("cName", "Name");
        }

        private void LoadSurgeryData()
        {
            List<Surgery> surgery = database.loadSurgeryTable(txtFilter.Text);
            surgery.ForEach(s => dgvIdHelper.Rows.Add(s.Id, s.Name));
        }

        private void LoadTraumaColumns()
        {
            dgvIdHelper.Columns.Add("cID", "ID");
            dgvIdHelper.Columns.Add("cName", "Name");
        }

        private void LoadTraumaData()
        {
            List<Trauma> trauma = database.loadTraumaTable(txtFilter.Text);
            trauma.ForEach(t => dgvIdHelper.Rows.Add(t.Id, t.Name));
        }

        private void LoadTreatmentColumns()
        {
            dgvIdHelper.Columns.Add("cID", "ID");
            dgvIdHelper.Columns.Add("cName", "Name");
        }

        private void LoadTreatmentData()
        {
            List<Treatment> treatment = database.loadTreatmentTable(txtFilter.Text);
            treatment.ForEach(t => dgvIdHelper.Rows.Add(t.Id, t.Name));
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            commitEntitySelection();
        }

        private void dgvIdHelper_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            commitEntitySelection();
        }

        private void commitEntitySelection()
        {
            selectedRow = dgvIdHelper.CurrentRow.Index;
            txtReqEntity.Text = dgvIdHelper.Rows[selectedRow].Cells[0].Value 
                + ":" + dgvIdHelper.Rows[selectedRow].Cells[1].Value;

            this.Close();
        }
    }
}
