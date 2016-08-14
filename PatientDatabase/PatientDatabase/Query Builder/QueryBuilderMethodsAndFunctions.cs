using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public partial class QueryBuilder
    {
        // for development, load pre set queries to test
        private void loadTestQueries()
        {

            //queries.Add(new PatientQuery("Last Name", "Starts With", "Thim", true, false));
            queries.Add(new PatientQuery("Sex", "Is Equal To", "Male", true, false));
            //queries.Add(new PatientQuery("First Name", "Starts With", "Ja", false, true));
            //queries.Add(new PatientQuery("First Name", "Starts With", "Ale", true, false));

            loadDataGridView();
        }

        private void addCondition()
        {
            AddQueryToBuilder aqtb = new AddQueryToBuilder(queries, dgvCurrentQuery, -1, queryCommands);
            aqtb.ShowDialog();
            checkSubmitStatus();
        }

        private void editCondition()
        {
            AddQueryToBuilder aqtb = new AddQueryToBuilder(queries, dgvCurrentQuery, selectedRow, queryCommands);
            aqtb.ShowDialog();
        }

        private void removeCondition()
        {
            setSelectedRow();
            queries.RemoveAt(selectedRow);
            loadDataGridView();
            if (selectedRow <= dgvCurrentQuery.Rows.Count - 1) setSelectedDataGridViewRow(selectedRow);
            else setSelectedDataGridViewRow(selectedRow - 1);
            checkSubmitStatus();
        }


        private void moveUp()
        {
            setSelectedRow();
            if (selectedRow > 0)
            {
                Query query = queries[selectedRow];
                queries.RemoveAt(selectedRow);
                queries.Insert(selectedRow - 1, query);
                loadDataGridView();
                setSelectedDataGridViewRow(selectedRow - 1);
            }
        }

        private void moveDown()
        {
            setSelectedRow();
            if (selectedRow < dgvCurrentQuery.Rows.Count - 1)
            {
                Query query = queries[selectedRow];
                queries.RemoveAt(selectedRow);
                queries.Insert(selectedRow + 1, query);
                loadDataGridView();
                setSelectedDataGridViewRow(selectedRow + 1);
            }
        }

        private void applyInverse()
        {
            setSelectedRow();
            string[] criteriaPhrases = queries[selectedRow].Criteria.Split(' ');
            if (criteriaPhrases[criteriaPhrases.Length - 1] == "NOT")
            {
                criteriaPhrases[criteriaPhrases.Length - 1] = "";
                queries[selectedRow].Criteria = string.Join(" ", criteriaPhrases).Trim();
            }
            else queries[selectedRow].Criteria = queries[selectedRow].Criteria + " NOT";
            loadRow(selectedRow);
        }

        private void applyGateChange()
        {
            setSelectedRow();
            queries[selectedRow].inverseGates();
            loadRow(selectedRow);
        }

        private void copyCondition()
        {
            copiedQuery = queries[selectedRow];
        }

        private void pasteCondition()
        {
            queries.Insert(selectedRow, new PatientQuery(copiedQuery.Property, copiedQuery.Criteria, copiedQuery.Filter, copiedQuery.And, copiedQuery.Or));
            loadDataGridView();
            setSelectedDataGridViewRow(selectedRow);
        }

        private void submitQuery()
        {
            if (editQueryIndex == -1) queryEntityCollection.QueryEntities.Add(new QueryEntity(txtName.Text, queries));
            else queryEntityCollection.QueryEntities[editQueryIndex] = new QueryEntity(txtName.Text, queries);
            this.Close();
        }

        private void setSelectedDataGridViewRow(int rowIndex)
        {
            if (dgvCurrentQuery.Rows.Count > 0) dgvCurrentQuery.Rows[rowIndex].Selected = true;
        }

        private void loadRow(int rowIndex)
        {
            Query q = queries[rowIndex];
            dgvCurrentQuery.Rows[rowIndex].SetValues(q.getGateText(), q.Property, q.Criteria, q.Filter);
        }

        private void loadDataGridView()
        {
            dgvCurrentQuery.Rows.Clear();

            queries.ForEach(q => dgvCurrentQuery.Rows
                .Add(q.getGateText(), q.Property, q.Criteria, q.Filter));
        }

        private void setSelectedRow()
        {
            if (dgvCurrentQuery.Rows.Count > 0) selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
        }

        private bool dataGridViewHasData()
        {
            return dgvCurrentQuery.Rows.Count > 0;
        }

        private void checkSubmitStatus()
        {
            if (queries.Count > 0) btnSubmitQuery.Enabled = true;
            else btnSubmitQuery.Enabled = false;
        }
    }
}
