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
    public partial class QueryManager : Form
    {
        QueryEntityCollection queryEntityCollection;

        public QueryManager(QueryEntityCollection queryEntityCollection)
        {
            InitializeComponent();
            this.queryEntityCollection = queryEntityCollection;
        }

        private void ChartSeriesManager_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            loadSeries();
            setListBoxSelectedIndex(lstQuery, 0);
        }

        private void QueryManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void loadSeries()
        {
            lstQuery.Items.Clear();
            queryEntityCollection.QueryEntities.ForEach(q => lstQuery.Items.Add(q.Name));
        }

        private void setListBoxSelectedIndex(ListBox listBox, int index)
        {
            if (listBox.Items.Count > 0) listBox.SelectedIndex = index;
        }

        private void lstChartSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtConditions.Text = queryEntityCollection.QueryEntities[lstQuery.SelectedIndex].queryToString();
        }

        private void btnAddQuery_Click(object sender, EventArgs e)
        {
            if (queryEntityCollection.QueryEntities.Count == 15)
            {
                int index = lstQuery.SelectedIndex;
                int count = queryEntityCollection.QueryEntities.Count;
                QueryBuilder qb = new QueryBuilder(queryEntityCollection);
                qb.ShowDialog();
                loadSeries();

                if (count < queryEntityCollection.QueryEntities.Count)
                    setListBoxSelectedIndex(lstQuery, lstQuery.Items.Count - 1);
                else
                    setListBoxSelectedIndex(lstQuery, index);
            }
            else
            {
                MessageBox.Show("Error: Max number of queries allowed is fifteen (15)", "Error");
            }
        }

        private void btnEditQuery_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstQuery.SelectedIndex;
            QueryBuilder qb = new QueryBuilder(queryEntityCollection, selectedIndex);
            qb.ShowDialog();
            loadSeries();
            setListBoxSelectedIndex(lstQuery, lstQuery.Items.Count - 1);
        }

        private void lstChartSeries_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = lstQuery.SelectedIndex;
            QueryBuilder qb = new QueryBuilder(queryEntityCollection, selectedIndex);
            qb.ShowDialog();
            loadSeries();
            setListBoxSelectedIndex(lstQuery, selectedIndex);
        }

        private void btnDataChart_Click(object sender, EventArgs e)
        {
            DataCharts dc = new DataCharts(queryEntityCollection);
            dc.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();

            // Close all forms besides Main Menu
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name != "MainMenu") Application.OpenForms[i].Close();
            }
            this.Close();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (queryEntityCollection.QueryEntities.Count > 0)
            {
                if (lstQuery.SelectedIndex > 0)
                {
                    int selectedIndex = lstQuery.SelectedIndex;
                    QueryEntity temp = queryEntityCollection.QueryEntities[selectedIndex];
                    queryEntityCollection.QueryEntities[selectedIndex] = queryEntityCollection.QueryEntities[selectedIndex - 1];
                    queryEntityCollection.QueryEntities[selectedIndex - 1] = temp;
                    loadSeries();
                    setListBoxSelectedIndex(lstQuery, selectedIndex - 1);
                }
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (queryEntityCollection.QueryEntities.Count > 0)
            {
                if (lstQuery.SelectedIndex < lstQuery.Items.Count - 1)
                {
                    int selectedIndex = lstQuery.SelectedIndex;
                    QueryEntity temp = queryEntityCollection.QueryEntities[selectedIndex];
                    queryEntityCollection.QueryEntities[selectedIndex] = queryEntityCollection.QueryEntities[selectedIndex + 1];
                    queryEntityCollection.QueryEntities[selectedIndex + 1] = temp;
                    loadSeries();
                    setListBoxSelectedIndex(lstQuery, selectedIndex + 1);
                }
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if (queryEntityCollection.QueryEntities.Count == 15)
            {
                int selectedIndex = lstQuery.SelectedIndex;
                QueryEntity copiedQueryEntity = queryEntityCollection.QueryEntities[selectedIndex];
                string duplicateName = queryEntityCollection.getDuplicateName(copiedQueryEntity.Name);
                List<Query> copiedQueriesList = getCopiedQueriesList(copiedQueryEntity);
                queryEntityCollection.QueryEntities.Add(new QueryEntity(duplicateName, copiedQueriesList));
                loadSeries();
                setListBoxSelectedIndex(lstQuery, lstQuery.Items.Count - 1);
            }
            else
            {
                MessageBox.Show("Error: Max number of queries allowed is fifteen (15)", "Error");
            }
        }

        private List<Query> getCopiedQueriesList(QueryEntity copiedQueryEntity)
        {
            List<Query> copiedQueries = new List<Query>();
            foreach (Query query in copiedQueryEntity.Queries)
            {
                copiedQueries.Add(
                    new PatientQuery(query.Property, query.Criteria, query.Filter, query.And, query.Or));
            }
            return copiedQueries;
        }

        private void btnRemoveQuery_Click(object sender, EventArgs e)
        {
            if (queryEntityCollection.QueryEntities.Count > 0)
            {
                int selectedIndex = lstQuery.SelectedIndex;
                queryEntityCollection.QueryEntities.RemoveAt(lstQuery.SelectedIndex);
                loadSeries();

                if (queryEntityCollection.QueryEntities.Count > 0)
                {
                    if (selectedIndex != 0) setListBoxSelectedIndex(lstQuery, selectedIndex - 1);
                    else setListBoxSelectedIndex(lstQuery, 0);
                }
            }
                    
        }
    }
}
