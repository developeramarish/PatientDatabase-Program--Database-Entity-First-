using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public class QueryBuilderLogic
    {
        QueryEntityCollection queryEntityCollection;
        int editQueryIndex;
        CommandCenter queryCommands;
        DatabaseAccess database;
        List<Query> queries;
        List<Query> pendingQueries;
        Query copiedQuery;
        CommonUIMethodsAndFunctions commonUI;

        public QueryBuilderLogic(QueryEntityCollection queryEntityCollection, int editQueryIndex)
        {
            this.queryEntityCollection = queryEntityCollection;
            this.editQueryIndex = editQueryIndex;
            queryCommands = new CommandCenter();
            database = new DatabaseAccess();
            commonUI = new CommonUIMethodsAndFunctions();
            queries = setQueries(queries);
            pendingQueries = new List<Query>();
            copiedQuery = null;
        }

        private List<Query> setQueries(List<Query> queries)
        {
            if (editQueryIndex == -1) queries = new List<Query>();
            else queries = queryEntityCollection.QueryEntities[editQueryIndex].Queries;
            return queries;
        }

        public void onFormLoad(DataGridView dgvCurrentQuery, Button btnSubmitQuery, TextBox txtName)
        {
            dgvCurrentQuery.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            pendingQueries = loadPendingQueries(pendingQueries);
            loadNameTextBox(txtName);
            loadDataGridView(dgvCurrentQuery);
            checkSubmitStatus(btnSubmitQuery);
        }

        private void loadNameTextBox(TextBox txtName)
        {
            if (editQueryIndex != -1)
                txtName.Text = queryEntityCollection.QueryEntities[editQueryIndex].Name;
        }

        private List<Query> loadPendingQueries(List<Query> pendingQueries)
        {
            queries.ForEach(q => pendingQueries.Add(new PatientQuery(q.Property, q.Criteria, q.Filter, q.And, q.Or)));
            return pendingQueries;
        }

        public void addCondition(DataGridView dgvCurrentQuery, Button btnSubmitQuery)
        {
            AddQueryToBuilder aqtb = new AddQueryToBuilder(pendingQueries, dgvCurrentQuery, -1, queryCommands);
            aqtb.ShowDialog();
            checkSubmitStatus(btnSubmitQuery);
        }

        public void editCondition(DataGridView dgvCurrentQuery)
        {
            if (commonUI.dataGridViewHasData(dgvCurrentQuery))
            {
                int selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
                AddQueryToBuilder aqtb = new AddQueryToBuilder(pendingQueries, dgvCurrentQuery, selectedRow, queryCommands);
                aqtb.ShowDialog();
            }
        }

        public void removeCondition(DataGridView dgvCurrentQuery, Button btnSubmitQuery)
        {
            if (commonUI.dataGridViewHasData(dgvCurrentQuery))
            {
                int selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
                pendingQueries.RemoveAt(selectedRow);
                loadDataGridView(dgvCurrentQuery);
                if (selectedRow <= dgvCurrentQuery.Rows.Count - 1) commonUI.setSelectedDataGridViewRow(dgvCurrentQuery, selectedRow);
                else commonUI.setSelectedDataGridViewRow(dgvCurrentQuery, selectedRow - 1);
                checkSubmitStatus(btnSubmitQuery);
            }
        }

        public void moveUp(DataGridView dgvCurrentQuery)
        {
            if (commonUI.dataGridViewHasData(dgvCurrentQuery))
            {
                int selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
                if (selectedRow > 0)
                {
                    Query query = pendingQueries[selectedRow];
                    pendingQueries.RemoveAt(selectedRow);
                    pendingQueries.Insert(selectedRow - 1, query);
                    loadDataGridView(dgvCurrentQuery);
                    commonUI.setSelectedDataGridViewRow(dgvCurrentQuery, selectedRow - 1);
                }
            }
        }

        public void moveDown(DataGridView dgvCurrentQuery)
        {
            if (commonUI.dataGridViewHasData(dgvCurrentQuery))
            {
                int selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
                if (selectedRow < dgvCurrentQuery.Rows.Count - 1)
                {
                    Query query = pendingQueries[selectedRow];
                    pendingQueries.RemoveAt(selectedRow);
                    pendingQueries.Insert(selectedRow + 1, query);
                    loadDataGridView(dgvCurrentQuery);
                    commonUI.setSelectedDataGridViewRow(dgvCurrentQuery, selectedRow + 1);
                }
            }
        }

        public void applyInverse(DataGridView dgvCurrentQuery)
        {
            if (commonUI.dataGridViewHasData(dgvCurrentQuery))
            {
                int selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
                string[] criteriaPhrases = pendingQueries[selectedRow].Criteria.Split(' ');
                if (criteriaPhrases[criteriaPhrases.Length - 1] == "NOT")
                {
                    criteriaPhrases[criteriaPhrases.Length - 1] = "";
                    pendingQueries[selectedRow].Criteria = string.Join(" ", criteriaPhrases).Trim();
                }
                else pendingQueries[selectedRow].Criteria = pendingQueries[selectedRow].Criteria + " NOT";
                loadRow(selectedRow, dgvCurrentQuery);
            }
        }

        public void applyGateChange(DataGridView dgvCurrentQuery)
        {
            if (commonUI.dataGridViewHasData(dgvCurrentQuery))
            {
                int selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
                pendingQueries[selectedRow].inverseGates();
                loadRow(selectedRow, dgvCurrentQuery);
            }
        }

        public void copyCondition(DataGridView dgvCurrentQuery)
        {
            if (commonUI.dataGridViewHasData(dgvCurrentQuery))
            {
                int selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
                copiedQuery = pendingQueries[selectedRow];
            }
        }

        public void pasteCondition(DataGridView dgvCurrentQuery)
        {
            if (commonUI.dataGridViewHasData(dgvCurrentQuery) && copiedQuery != null)
            {
                int selectedRow = dgvCurrentQuery.SelectedRows[0].Index;
                pendingQueries.Insert(selectedRow, new PatientQuery(copiedQuery.Property, copiedQuery.Criteria, copiedQuery.Filter, copiedQuery.And, copiedQuery.Or));
                loadDataGridView(dgvCurrentQuery);
                commonUI.setSelectedDataGridViewRow(dgvCurrentQuery, selectedRow);
            }
        }

        public void submitQuery(TextBox txtName, Form queryBuilder)
        {
            if (queryEntityCollection.isNameValid(txtName.Text, editQueryIndex))
            {
                queries = transferPendingQueries();
                if (editQueryIndex == -1)
                    queryEntityCollection.QueryEntities.Add(new QueryEntity(txtName.Text, queries));
                else
                    queryEntityCollection.QueryEntities[editQueryIndex] = new QueryEntity(txtName.Text, queries);
                queryBuilder.Close();
            }
            else
            {
                MessageBox.Show("Error: Name is not valid!"
                    + Environment.NewLine
                    + Environment.NewLine
                    + "Name must not be blank and must not be the same name of another query"
                    , "Error");
            }
        }

        public List<Query> transferPendingQueries()
        {
            queries.Clear();
            pendingQueries.ForEach(pq => queries.Add(
                new PatientQuery(pq.Property, pq.Criteria, pq.Filter, pq.And, pq.Or)));
            return queries;
        }

        public void loadRow(int rowIndex, DataGridView dgvCurrentQuery)
        {
            Query q = pendingQueries[rowIndex];
            dgvCurrentQuery.Rows[rowIndex].SetValues(q.getGateText(), q.Property, q.Criteria, q.Filter);
        }

        public void loadDataGridView(DataGridView dgvCurrentQuery)
        {
            dgvCurrentQuery.Rows.Clear();

            pendingQueries.ForEach(q => dgvCurrentQuery.Rows
                .Add(q.getGateText(), q.Property, q.Criteria, q.Filter));
        }

        public void checkSubmitStatus(Button btnSubmitQuery)
        {
            if (pendingQueries.Count > 0) btnSubmitQuery.Enabled = true;
            else btnSubmitQuery.Enabled = false;
        }
    }
}
