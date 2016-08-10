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

            queries.Add(new PatientQuery("Last Name", "Starts With", "Thim", true, false));
            queries.Add(new PatientQuery("Sex", "Is Equal To", "Male", true, false));
            queries.Add(new PatientQuery("First Name", "Starts With", "Ja", false, true));
            queries.Add(new PatientQuery("First Name", "Starts With", "Ale", true, false));

            loadDataGridView();
        }

        private void addQuery()
        {
            AddQueryToBuilder aqtb = new AddQueryToBuilder(queries, dgvCurrentQuery, -1, queryCommands);
            aqtb.ShowDialog();
        }

        private void editQuery()
        {
            AddQueryToBuilder aqtb = new AddQueryToBuilder(queries, dgvCurrentQuery, selectedRow, queryCommands);
            aqtb.ShowDialog();
        }

        private void removeQuery()
        {
            setSelectedRow();
            queries.RemoveAt(selectedRow);
            loadDataGridView();
            if (selectedRow <= dgvCurrentQuery.Rows.Count - 1) setSelectedDataGridViewRow(selectedRow);
            else setSelectedDataGridViewRow(selectedRow - 1);
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

        private void copyQuery()
        {
            copiedQuery = queries[selectedRow];
        }

        private void pasteQuery()
        {
            queries.Insert(selectedRow, new PatientQuery(copiedQuery.Property, copiedQuery.Criteria, copiedQuery.Filter, copiedQuery.And, copiedQuery.Or));
            loadDataGridView();
            setSelectedDataGridViewRow(selectedRow);
        }

        private void runQuery()
        {
            queries = formatQueriesList();
            List<Patient> results = database.loadPatientsFromQuery(queries);
            //PatientProfileSelection pps = new PatientProfileSelection(results);
            //pps.Show();
            QueryResults qr = new QueryResults(results, queries);
            qr.ShowDialog();
           // this.Close();
        }

        // applies continue and standalone groups where needed to each query for structuring purposes
        private List<Query> formatQueriesList()
        {
            if (queries.Count > 0) queries[0].And = true; // first query MUST be AND otherwise it won't work
            for (int i = 0; i < queries.Count; i++)
            {
                if (queries[i].And && locationExistsInQueriesList(i + 1))
                {
                    if (!queries[i + 1].Or) queries[i].StandAlone = true;
                    else if (queries[i + 1].Or) queries[i].StartGroup = true;
                }
                else if (queries[i].And && !locationExistsInQueriesList(i + 1)) queries[i].StandAlone = true;
                else if (queries[i].Or && locationExistsInQueriesList(i + 1))
                {
                    if (!queries[i + 1].Or) queries[i].EndGroup = true;
                    else if (queries[i + 1].Or) queries[i].ContinueGroup = true;
                }
                else if (queries[i].Or && !locationExistsInQueriesList(i + 1)) queries[i].EndGroup = true;
            }
            return queries;
        }

        private bool locationExistsInQueriesList(int index)
        {
            return index >= 0 & index <= queries.Count - 1;
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
    }
}
