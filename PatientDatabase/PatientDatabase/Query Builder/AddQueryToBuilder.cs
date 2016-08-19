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
        AddQueryToBuilderLogic logic;

        public AddQueryToBuilder(List<Query> queries, DataGridView dgvCurrentQuery, int selectedIndex, CommandCenter queryCommands)
        {
            InitializeComponent();
            logic = new AddQueryToBuilderLogic(queries, dgvCurrentQuery, selectedIndex, queryCommands);          
        }

        private void AddQueryToBuilder_Load(object sender, EventArgs e)
        {            
            GlobalFormManager.FormOpen();
            logic.onFormLoad(txtSelectedProperty, panelProperty,
                txtSelectedCriteria, panelCriteria, txtSelectedFilter, panelFilter, btnSubmit);
        }

        private void AddQueryToBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void txtPropertyFilter_TextChanged(object sender, EventArgs e)
        {
            logic.reloadPropertyListBox(lstProperty, txtPropertyFilter, chkPropertyDevMode);
        }

        private void chkPropertyDevMode_CheckedChanged(object sender, EventArgs e)
        {
            logic.reloadPropertyListBox(lstProperty, txtPropertyFilter, chkPropertyDevMode);
        }

        private void btnSelectProperty_Click(object sender, EventArgs e)
        {
            logic.commitPropertyChoice(lstProperty, txtSelectedProperty, txtSelectedCriteria,
                panelCriteria, txtSelectedFilter,  panelFilter, btnSubmit);
        }

        private void lstProperty_DoubleClick(object sender, EventArgs e)
        {
            logic.commitPropertyChoice(lstProperty, txtSelectedProperty, txtSelectedCriteria,
                 panelCriteria, txtSelectedFilter, panelFilter, btnSubmit);
        }

        private void btnClearProperty_Click(object sender, EventArgs e)
        {
            logic.clearProperty(txtSelectedProperty, txtSelectedCriteria,
                panelCriteria, txtSelectedFilter,panelFilter, btnSubmit);
        }

        private void txtCriteriaFilter_TextChanged(object sender, EventArgs e)
        {
            logic.reloadCriteriaListBox(lstCriteria, txtCriteriaFilter, chkCriteriaDevMode, chkNot);
        }

        private void chkCriteriaDevMode_CheckedChanged(object sender, EventArgs e)
        {
            logic.reloadCriteriaListBox(lstCriteria, txtCriteriaFilter, chkCriteriaDevMode, chkNot);
        }

        private void chkNot_CheckedChanged(object sender, EventArgs e)
        {
            logic.CheckBoxNotCheckChange(lstCriteria, txtCriteriaFilter, chkCriteriaDevMode, chkNot);
        }

        private void btnSelectCriteria_Click(object sender, EventArgs e)
        {
            logic.commitCriteriaChoice(lstCriteria, txtSelectedCriteria, txtSelectedFilter, 
                panelFilter, btnSubmit);
        }

        private void lstCriteria_DoubleClick(object sender, EventArgs e)
        {
            logic.commitCriteriaChoice(lstCriteria, txtSelectedCriteria, txtSelectedFilter,
                panelFilter, btnSubmit);
        }

        private void btnClearCriteria_Click(object sender, EventArgs e)
        {
            logic.clearCriteria(txtSelectedCriteria, txtSelectedFilter,  panelFilter, btnSubmit);
        }

        private void btnIdHelper_Click(object sender, EventArgs e)
        {
            logic.loadIdHelperForm(txtReq1);
        }

        private void btnSelectFilter_Click(object sender, EventArgs e)
        {
            logic.commitFilterChoice(txtSelectedFilter, panelFilter, btnSubmit);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            logic.clearFilter(txtSelectedFilter, panelFilter, btnSubmit);
        }
  
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            logic.submitQuery();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
