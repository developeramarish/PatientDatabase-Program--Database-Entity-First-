using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    // All logic for AddQueryToBuilder controls here
    public partial class AddQueryToBuilder
    {
        private void setUpProperty()
        {
            txtSelectedProperty.Text = query.Property;
            lstProperty.Items.AddRange(queryCommands.getProperties(txtPropertyFilter.Text, chkPropertyDevMode.Checked));

            if (query.Property != "") setListBoxSelectedIndex(lstProperty, FindPropertyCommand());
            else setListBoxSelectedIndex(lstProperty, 0);
        }

        private void setUpCriteria()
        {
            if (query.Property != "")
            {
                txtSelectedCriteria.Text = query.Criteria;
                lstCriteria.Items.Clear();
                lstCriteria.Items.AddRange(queryCommands.getProperty(query.Property).getCriteria().getCriteriaOptions(txtCriteriaFilter.Text, chkCriteriaDevMode.Checked, chkNot.Checked));

                txtCriteriaFilter.Enabled = true;
                lstCriteria.Enabled = true;
                chkNot.Enabled = true;
                chkNot.Checked = false;
                chkCriteriaDevMode.Enabled = true;
                chkCriteriaDevMode.Checked = false;
                btnSelectCriteria.Enabled = true;
                btnClearCriteria.Enabled = true;
                lblFilterCriteria.Enabled = true;
                txtSelectedCriteria.Enabled = true;
                lblCriteria.Enabled = true;

                if (query.Criteria != "") setListBoxSelectedIndex(lstCriteria, FindCriteriaCommand());
                else setListBoxSelectedIndex(lstCriteria, 0);
            }
            else
            {
                txtCriteriaFilter.Text = "";
                txtCriteriaFilter.Enabled = false;
                lstCriteria.Items.Clear();
                lstCriteria.Enabled = false;
                chkNot.Checked = false;
                chkNot.Enabled = false;
                chkCriteriaDevMode.Checked = false;
                chkCriteriaDevMode.Enabled = false;
                btnSelectCriteria.Enabled = false;
                btnClearCriteria.Enabled = false;
                lblFilterCriteria.Enabled = false;
                txtSelectedCriteria.Text = "";
                txtSelectedCriteria.Enabled = false;
                lblCriteria.Enabled = false;
            }
        }

        private void setUpFilter()
        {
            if (query.Criteria != "")
            {
                txtSelectedFilter.Text = query.Filter;
                lblFilter.Enabled = true;
                setUpReqs(query.Filter);
                rtxtInstructions.Enabled = true;
                enableIdHelper();
                btnSelectFilter.Enabled = true;
                btnClearFilter.Enabled = true;
                txtSelectedFilter.Enabled = true;
                rtxtInstructions.Text = queryCommands.getProperty(query.Property).getCriteria().getFilterInstructions(query.Criteria);

                if (query.Filter == "")
                {
                    txtReq1.Text = "";
                    txtReq2.Text = "";
                    txtReq3.Text = "";
                    txtSelectedFilter.Text = "";
                }

                if (isFilterValid()) btnSubmit.Enabled = true;
            }
            else
            {
                lblFilter.Enabled = false;
                lblReq1.Enabled = false;
                txtReq1.Enabled = false;
                txtReq1.Text = "";
                lblReq2.Enabled = false;
                txtReq2.Enabled = false;
                txtReq2.Text = "";
                lblReq3.Enabled = false;
                txtReq3.Enabled = false;
                txtReq3.Text = "";
                rtxtInstructions.Enabled = false;
                rtxtInstructions.Text = "";
                btnIdHelper.Enabled = false;
                btnSelectFilter.Enabled = false;
                btnClearFilter.Enabled = false;
                txtSelectedFilter.Text = "";
                txtSelectedFilter.Enabled = false;
            }
        }

        private int FindPropertyCommand()
        {
            int index = queryCommands.getProperties("", false).ToList().FindIndex(p => p == query.Property);
            if (index == -1)
            {
                chkPropertyDevMode.Checked = true;
                index = queryCommands.getProperties("", true).ToList().FindIndex(p => p == query.Property);
            }
            return index;
        }

        private int FindCriteriaCommand()
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

        private void setUpReqs(string filter)
        {
            string[] filters = filter.Split(' ');
            lblReq1.Enabled = false;
            txtReq1.Enabled = false;
            txtReq1.Text = "";
            lblReq2.Enabled = false;
            txtReq2.Enabled = false;
            txtReq2.Text = "";
            lblReq3.Enabled = false;
            txtReq3.Enabled = false;
            txtReq3.Text = "";
            int filterReqNumber = queryCommands.getProperty(query.Property).getCriteria().getFilterReqNumber(query.Criteria);
            if (filterReqNumber >= 1)
            {
                lblReq1.Enabled = true;
                txtReq1.Enabled = true;
                if (filter != "" && filters.Length >= 1) txtReq1.Text = filters[0];

            }
            if (filterReqNumber >= 2)
            {
                lblReq2.Enabled = true;
                txtReq2.Enabled = true;
                if (filter != "" && filters.Length >= 2) txtReq2.Text = filters[1];
            }
            if (filterReqNumber == 3)
            {
                lblReq3.Enabled = true;
                txtReq3.Enabled = true;
                if (filter != "" && filters.Length >= 3) txtReq3.Text = filters[2];
            }
        }

        private void enableIdHelper()
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

        private void commitPropertyChoice()
        {
            if (lstProperty.SelectedIndex > -1)
            {
                txtSelectedProperty.Text = lstProperty.SelectedItem.ToString();
                if (query.Property != txtSelectedProperty.Text) clearCriteria();
                query.Property = txtSelectedProperty.Text;
                setUpCriteria();
            }
        }

        private void clearProperty()
        {
            txtSelectedProperty.Text = "";
            query.Property = "";
            query.Criteria = "";
            query.Filter = "";
            btnSubmit.Enabled = false;
            setUpCriteria();
            setUpFilter();
        }

        private void commitCriteriaChoice()
        {
            if (lstCriteria.SelectedIndex > -1)
            {
                txtSelectedCriteria.Text = lstCriteria.SelectedItem.ToString();
                if (query.Criteria != txtSelectedCriteria.Text) clearFilter();
                query.Criteria = txtSelectedCriteria.Text;
                setUpFilter();
            }
        }

        private void clearCriteria()
        {
            txtSelectedCriteria.Text = "";
            query.Criteria = "";
            query.Filter = "";
            btnSubmit.Enabled = false;
            setUpFilter();
        }

        private void commitFilterChoice()
        {
            if (isFilterValid())
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

        private void clearFilter()
        {
            txtSelectedFilter.Text = "";
            query.Filter = "";
            btnSubmit.Enabled = false;
            setUpFilter();
        }

        private void submitQuery()
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


        private bool isFilterValid()
        {
            return queryCommands.getProperty(query.Property).getCriteria().isFilterValid(query.Criteria, (txtReq1.Text + " " + txtReq2.Text + " " + txtReq3.Text).Trim());
        }

        private void enableSubmitButton()
        {
            
        }
    }
}
