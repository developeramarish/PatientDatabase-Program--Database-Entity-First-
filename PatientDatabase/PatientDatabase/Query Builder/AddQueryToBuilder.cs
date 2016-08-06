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
    // Look in AddQueryToBuilderMethodsAndFunctions for all non control methods and functions called
    public partial class AddQueryToBuilder : Form
    {
        CommandCenter queryCommands;
        List<Query> queries;
        DataGridView dgvCurrentQuery;
        Query query;
        int selectedIndex;

        public AddQueryToBuilder(List<Query> queries, DataGridView dgvCurrentQuery, int selectedIndex, CommandCenter queryCommands)
        {
            InitializeComponent();
            this.queries = queries;
            this.dgvCurrentQuery = dgvCurrentQuery;

            if (selectedIndex == -1)
                query = new PatientQuery("", "", "");
            else
                query = queries[selectedIndex];

            this.selectedIndex = selectedIndex;
            this.queryCommands = queryCommands;
        }

        private void AddQueryToBuilder_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            setUpProperty();
            setUpCriteria();
            setUpFilter();
        }

        private void AddQueryToBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void txtPropertyFilter_TextChanged(object sender, EventArgs e)
        {
            lstProperty.Items.Clear();
            lstProperty.Items.AddRange(queryCommands.getProperties(txtPropertyFilter.Text, chkPropertyDevMode.Checked));
            setListBoxSelectedIndex(lstProperty, 0);
        }

        private void chkPropertyDevMode_CheckedChanged(object sender, EventArgs e)
        {
            lstProperty.Items.Clear();
            lstProperty.Items.AddRange(queryCommands.getProperties(txtPropertyFilter.Text, chkPropertyDevMode.Checked));
            setListBoxSelectedIndex(lstProperty, 0);
        }

        private void btnSelectProperty_Click(object sender, EventArgs e)
        {
            commitPropertyChoice();
        }

        private void lstProperty_DoubleClick(object sender, EventArgs e)
        {
            commitPropertyChoice();
        }

        private void btnClearProperty_Click(object sender, EventArgs e)
        {
            clearProperty();
        }

        private void txtCriteriaFilter_TextChanged(object sender, EventArgs e)
        {
            lstCriteria.Items.Clear();
            lstCriteria.Items.AddRange(queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions(txtCriteriaFilter.Text, chkCriteriaDevMode.Checked, chkNot.Checked));
            setListBoxSelectedIndex(lstCriteria, 0);
        }

        private void chkCriteriaDevMode_CheckedChanged(object sender, EventArgs e)
        {
            lstCriteria.Items.Clear();
            lstCriteria.Items.AddRange(queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions(txtCriteriaFilter.Text, chkCriteriaDevMode.Checked, chkNot.Checked));
            setListBoxSelectedIndex(lstCriteria, 0);
        }

        private void chkNot_CheckedChanged(object sender, EventArgs e)
        {
            int currentIndex = lstCriteria.SelectedIndex;
            lstCriteria.Items.Clear();
            lstCriteria.Items.AddRange(queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions(txtCriteriaFilter.Text, chkCriteriaDevMode.Checked, chkNot.Checked));
            setListBoxSelectedIndex(lstCriteria, currentIndex);
        }

        private void btnSelectCriteria_Click(object sender, EventArgs e)
        {
            commitCriteriaChoice();
        }

        private void lstCriteria_DoubleClick(object sender, EventArgs e)
        {
            commitCriteriaChoice();
        }

        private void btnClearCriteria_Click(object sender, EventArgs e)
        {
            clearCriteria();
        }

        private void btnIdHelper_Click(object sender, EventArgs e)
        {
            IDHelper idHelper = new IDHelper(queryCommands.getProperty(query.Property).Entity, txtReq1);
            idHelper.ShowDialog();
        }

        private void btnSelectFilter_Click(object sender, EventArgs e)
        {
            commitFilterChoice();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            clearFilter();
        }
  
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submitQuery();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
