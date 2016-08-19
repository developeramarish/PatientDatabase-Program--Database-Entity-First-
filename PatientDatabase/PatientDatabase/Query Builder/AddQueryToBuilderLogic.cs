using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    // All logic for AddQueryToBuilder controls here
    public class AddQueryToBuilderLogic
    {
        CommandCenter queryCommands;
        List<Query> queries;
        DataGridView dgvCurrentQuery;
        Query query;
        int selectedIndex;
        CommonUIMethodsAndFunctions commonUI;

        public AddQueryToBuilderLogic(List<Query> queries, DataGridView dgvCurrentQuery, int selectedIndex, CommandCenter queryCommands)
        {
            this.queries = queries;
            this.dgvCurrentQuery = dgvCurrentQuery;

            if (selectedIndex == -1)
                query = new PatientQuery("", "", "");
            else
                query = queries[selectedIndex];

            this.selectedIndex = selectedIndex;
            this.queryCommands = queryCommands;
            commonUI = new CommonUIMethodsAndFunctions();
        }

        public void onFormLoad(TextBox txtSelectedProperty, Panel panelProperty, TextBox txtSelectedCriteria, 
            Panel panelCriteria, TextBox txtSelectedFilter, Panel panelFilter, Button btnSubmit)
        {
            setUpProperty(txtSelectedProperty, panelProperty);
            setUpCriteria(txtSelectedCriteria, panelCriteria);
            setUpFilter(txtSelectedFilter, panelFilter, btnSubmit);
        }

        private void setUpProperty(TextBox txtSelectedProperty, Panel panelProperty)
        {
            ListBox lstProperty = (ListBox)commonUI.getControlFromPanel(panelProperty, "lstProperty");
            TextBox txtPropertyFilter = (TextBox)commonUI.getControlFromPanel(panelProperty, "txtPropertyFilter");
            CheckBox chkPropertyDevMode = (CheckBox)commonUI.getControlFromPanel(panelProperty, "chkPropertyDevMode");

            txtSelectedProperty.Text = query.Property;
            lstProperty.Items.AddRange(queryCommands.getProperties(txtPropertyFilter.Text, chkPropertyDevMode.Checked));
            if (query.Property != "") setListBoxSelectedIndex(lstProperty, FindPropertyCommand(chkPropertyDevMode));
            else setListBoxSelectedIndex(lstProperty, 0);
        }

        private void setUpCriteria(TextBox txtSelectedCriteria, Panel panelCriteria)
        {
            ListBox lstCriteria = (ListBox)commonUI.getControlFromPanel(panelCriteria, "lstCriteria");
            TextBox txtCriteriaFilter = (TextBox)commonUI.getControlFromPanel(panelCriteria, "txtCriteriaFilter");
            CheckBox chkCriteriaDevMode = (CheckBox)commonUI.getControlFromPanel(panelCriteria, "chkCriteriaDevMode");
            CheckBox chkNot = (CheckBox)commonUI.getControlFromPanel(panelCriteria, "chkNot");

            if (query.Property != "")
            {
                txtSelectedCriteria.Text = query.Criteria;
                lstCriteria.Items.Clear();
                lstCriteria.Items.AddRange(queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions(txtCriteriaFilter.Text, chkCriteriaDevMode.Checked, chkNot.Checked));

                panelCriteria.Enabled = true;
                chkNot.Checked = false;
                chkCriteriaDevMode.Checked = false;

                if (query.Criteria != "") setListBoxSelectedIndex(lstCriteria, FindCriteriaCommand(chkCriteriaDevMode, chkNot));
                else setListBoxSelectedIndex(lstCriteria, 0);
            }
            else
            {
                panelCriteria.Enabled = false;
                txtCriteriaFilter.Text = "";
                lstCriteria.Items.Clear();
                chkNot.Checked = false;
                chkCriteriaDevMode.Checked = false;
                txtSelectedCriteria.Text = "";
            }
        }

        private void setUpFilter(TextBox txtSelectedFilter, Panel panelFilter, Button btnSubmit)
        {
            TextBox txtReq1 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq1");
            TextBox txtReq2 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq2");
            TextBox txtReq3 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq3");
            Button btnIdHelper = (Button)commonUI.getControlFromPanel(panelFilter, "btnIdHelper");
            RichTextBox rtxtInstructions = (RichTextBox)commonUI.getControlFromPanel(panelFilter, "rtxtInstructions");

            if (query.Criteria != "")
            {
                txtSelectedFilter.Text = query.Filter;
                setUpReqs(query.Filter, txtReq1, txtReq2, txtReq3);
                enableIdHelper(btnIdHelper, txtReq1);
                rtxtInstructions.Text = queryCommands.getProperty(query.Property).getCriteria().getFilterInstructions(query.Criteria);
                panelFilter.Enabled = true;

                if (query.Filter == "")
                {
                    txtReq1.Text = "";
                    txtReq2.Text = "";
                    txtReq3.Text = "";
                    txtSelectedFilter.Text = "";
                }

                if (isFilterValid(txtReq1, txtReq2, txtReq3)) btnSubmit.Enabled = true;
            }
            else
            {
                txtReq1.Text = "";
                txtReq2.Text = "";
                txtReq3.Text = "";
                rtxtInstructions.Text = "";
                txtSelectedFilter.Text = "";
                panelFilter.Enabled = false;
            }
        }

        public void reloadPropertyListBox(ListBox lstProperty, TextBox txtPropertyFilter, CheckBox chkPropertyDevMode)
        {
            lstProperty.Items.Clear();
            lstProperty.Items.AddRange(queryCommands.getProperties(txtPropertyFilter.Text, chkPropertyDevMode.Checked));
            setListBoxSelectedIndex(lstProperty, 0);
        }

        public void reloadCriteriaListBox(ListBox lstCriteria, TextBox txtCriteriaFilter, CheckBox chkCriteriaDevMode, CheckBox chkNot)
        {
            lstCriteria.Items.Clear();
            lstCriteria.Items.AddRange(queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions(txtCriteriaFilter.Text, chkCriteriaDevMode.Checked, chkNot.Checked));
            setListBoxSelectedIndex(lstCriteria, 0);
        }

        public void CheckBoxNotCheckChange(ListBox lstCriteria, TextBox txtCriteriaFilter, CheckBox chkCriteriaDevMode, CheckBox chkNot)
        {
            int currentIndex = lstCriteria.SelectedIndex;
            lstCriteria.Items.Clear();
            lstCriteria.Items.AddRange(queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions(txtCriteriaFilter.Text, chkCriteriaDevMode.Checked, chkNot.Checked));
            setListBoxSelectedIndex(lstCriteria, currentIndex);
        }

        private int FindPropertyCommand(CheckBox chkPropertyDevMode)
        {
            int index = queryCommands.getProperties("", false).ToList().FindIndex(p => p == query.Property);
            if (index == -1)
            {
                chkPropertyDevMode.Checked = true;
                index = queryCommands.getProperties("", true).ToList().FindIndex(p => p == query.Property);
            }
            return index;
        }

        private int FindCriteriaCommand(CheckBox chkCriteriaDevMode, CheckBox chkNot)
        {
            int index = -1;
            string[] criterias = query.Criteria.Split(' ');
            if (criterias[criterias.Length - 1] != "NOT")
            {
                index = queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions("", false, false).ToList().FindIndex(c => c == query.Criteria);
                if (index == -1)
                {
                    chkCriteriaDevMode.Checked = true;
                    index = queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions("", true, false).ToList().FindIndex(c => c == query.Criteria);
                }
            }
            else
            {
                chkNot.Checked = true;
                index = queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions("", false, true).ToList().FindIndex(c => c == query.Criteria);
                if (index == -1)
                {
                    chkCriteriaDevMode.Checked = true;
                    index = queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions("", true, true).ToList().FindIndex(c => c == query.Criteria);
                }
            }
            return index;
        }

        private void setListBoxSelectedIndex(ListBox listbox, int index)
        {
            if (listbox.Items.Count > 0) listbox.SelectedIndex = index;
        }

        private void setUpReqs(string filter, TextBox txtReq1, TextBox txtReq2, TextBox txtReq3)
        {
            string[] filters = filter.Split(' ');
          //  lblReq1.Enabled = false;
            txtReq1.Enabled = false;
            txtReq1.Text = "";
           // lblReq2.Enabled = false;
            txtReq2.Enabled = false;
            txtReq2.Text = "";
          //  lblReq3.Enabled = false;
            txtReq3.Enabled = false;
            txtReq3.Text = "";
            int filterReqNumber = queryCommands.getProperty(query.Property).getCriteria().getFilterReqNumber(query.Criteria);
            if (filterReqNumber >= 1)
            {
              //  lblReq1.Enabled = true;
                txtReq1.Enabled = true;
                if (filter != "" && filters.Length >= 1) txtReq1.Text = filters[0];

            }
            if (filterReqNumber >= 2)
            {
               // lblReq2.Enabled = true;
                txtReq2.Enabled = true;
                if (filter != "" && filters.Length >= 2) txtReq2.Text = filters[1];
            }
            if (filterReqNumber == 3)
            {
               // lblReq3.Enabled = true;
                txtReq3.Enabled = true;
                if (filter != "" && filters.Length >= 3) txtReq3.Text = filters[2];
            }
        }

        private void enableIdHelper(Button btnIdHelper, TextBox txtReq1)
        {
            if (queryCommands.getProperty(query.Property).enableIDHelper())
            {
                btnIdHelper.Enabled = true;
                txtReq1.ReadOnly = true;
            }
            else
            {
                btnIdHelper.Enabled = false;
                txtReq1.ReadOnly = false;
            }
        }

        public void commitPropertyChoice(ListBox lstProperty, TextBox txtSelectedProperty,
            TextBox txtSelectedCriteria, Panel panelCriteria, TextBox txtSelectedFilter,
            Panel panelFilter, Button btnSubmit)
        {
            if (lstProperty.SelectedIndex > -1)
            {
                txtSelectedProperty.Text = lstProperty.SelectedItem.ToString();
                if (query.Property != txtSelectedProperty.Text)
                {
                    clearCriteria(txtSelectedCriteria, txtSelectedFilter, panelFilter, btnSubmit);
                }
                query.Property = txtSelectedProperty.Text;
                setUpCriteria(txtSelectedCriteria, panelCriteria);
            }
        }

        public void clearProperty(TextBox txtSelectedProperty, TextBox txtSelectedCriteria, 
            Panel panelCriteria, TextBox txtSelectedFilter, Panel panelFilter, Button btnSubmit)
        {
            txtSelectedProperty.Text = "";
            query.Property = "";
            query.Criteria = "";
            query.Filter = "";
            btnSubmit.Enabled = false;
            setUpCriteria(txtSelectedCriteria, panelCriteria);
            setUpFilter(txtSelectedFilter, panelFilter, btnSubmit);
        }

        public void commitCriteriaChoice(ListBox lstCriteria, TextBox txtSelectedCriteria,  
            TextBox txtSelectedFilter, Panel panelFilter, Button btnSubmit)
        {
            TextBox txtReq1 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq1");
            TextBox txtReq2 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq2");
            TextBox txtReq3 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq3");
            Button btnIdHelper = (Button)commonUI.getControlFromPanel(panelFilter, "btnIdHelper");
            RichTextBox rtxtInstructions = (RichTextBox)commonUI.getControlFromPanel(panelFilter, "rtxtInstructions");

            if (lstCriteria.SelectedIndex > -1)
            {
                txtSelectedCriteria.Text = lstCriteria.SelectedItem.ToString();
                if (query.Criteria != txtSelectedCriteria.Text)
                {
                    clearFilter(txtSelectedFilter, panelFilter, btnSubmit);
                }
                query.Criteria = txtSelectedCriteria.Text;
                setUpFilter(txtSelectedFilter, panelFilter, btnSubmit);
            }
        }

        public void clearCriteria(TextBox txtSelectedCriteria, 
            TextBox txtSelectedFilter, Panel panelFilter, Button btnSubmit)
        {
            txtSelectedCriteria.Text = "";
            query.Criteria = "";
            query.Filter = "";
            btnSubmit.Enabled = false;
            setUpFilter(txtSelectedFilter, panelFilter, btnSubmit);
        }

        public void commitFilterChoice(TextBox txtSelectedFilter, Panel panelFilter,
            Button btnSubmit)
        {
            TextBox txtReq1 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq1");
            TextBox txtReq2 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq2");
            TextBox txtReq3 = (TextBox)commonUI.getControlFromPanel(panelFilter, "txtReq3");

            if (isFilterValid(txtReq1, txtReq2, txtReq3))
            {
                txtSelectedFilter.Text = (txtReq1.Text + " " + txtReq2.Text + " " + txtReq3.Text).Trim();
                query.Filter = txtSelectedFilter.Text;
                btnSubmit.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error: Filter is not valid!", "Error");
            }
        }

        public void clearFilter(TextBox txtSelectedFilter, Panel panelFilter, Button btnSubmit)
        {
            txtSelectedFilter.Text = "";
            query.Filter = "";
            btnSubmit.Enabled = false;
            setUpFilter(txtSelectedFilter, panelFilter, btnSubmit);
        }

        public void loadIdHelperForm(TextBox txtReq1)
        {
            IDHelper idHelper = new IDHelper(queryCommands.getProperty(query.Property).Entity, txtReq1);
            idHelper.ShowDialog();
        }

        public void submitQuery()
        {
            if (selectedIndex == -1)
            {
                queries.Add(query);
                dgvCurrentQuery.Rows.Add(query.getGateText(), query.Property, query.Criteria, query.Filter);
                dgvCurrentQuery.Rows[dgvCurrentQuery.Rows.Count - 1].Selected = true;
            }
            else
            {
                queries[selectedIndex] = query;
                dgvCurrentQuery.Rows[selectedIndex].SetValues(query.getGateText(), query.Property, query.Criteria, query.Filter);
            }
        }


        private bool isFilterValid(TextBox txtReq1, TextBox txtReq2, TextBox txtReq3)
        {
            return queryCommands.getProperty(query.Property).getCriteria().isFilterValid(query.Criteria, (txtReq1.Text + " " + txtReq2.Text + " " + txtReq3.Text).Trim());
        }
    }
}
