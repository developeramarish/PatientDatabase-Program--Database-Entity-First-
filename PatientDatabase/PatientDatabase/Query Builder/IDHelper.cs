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
                default: return "ID Helper";
            }
        }

        public void loadDataGridViewColumns()
        {
            dgvIdHelper.Columns.Add("cID", "ID");
            dgvIdHelper.Columns.Add("cName", "Name");
            dgvIdHelper.Columns.Add("cType", "Type");
            dgvIdHelper.Columns.Add("cGenericName", "Generic Name");
            dgvIdHelper.Columns.Add("cMorphineEquivalent", "Morphine Equivalent (Mg)");
            dgvIdHelper.Columns.Add("cSustainedRelease", "Sustained Release?");
            dgvIdHelper.Columns.Add("cShortActing", "Short Acting?");
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            switch (helper)
            {
                case "Medication": LoadMedication(); break;
                default: break;
            }
        }

        private void LoadMedication()
        {
            dgvIdHelper.Rows.Clear();
            List<Medication> medication = database.loadMedicationTable(txtFilter.Text);
            foreach (DataGridViewColumn column in dgvIdHelper.Columns) { column.SortMode = DataGridViewColumnSortMode.NotSortable; }
            medication.ForEach(m => dgvIdHelper.Rows.Add(m.Id, m.Name, m.Type, m.Generic_Name, m.Morphine_Equivalent__mg_, m.Sustained_Release, m.Short_Acting));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
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

        private void dgvIdHelper_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            commitEntitySelection();
        }
    }
}
