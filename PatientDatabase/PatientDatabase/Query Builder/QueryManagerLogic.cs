using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public class QueryManagerLogic
    {
        public QueryEntityCollection queryEntityCollection { get; set; }
        CommonUIMethodsAndFunctions commonUI;

        public QueryManagerLogic(QueryEntityCollection queryEntityCollection)
        {
            this.queryEntityCollection = queryEntityCollection;
            commonUI = new CommonUIMethodsAndFunctions();
        }

        public void onFormLoad(ListBox lstQuery)
        {
            loadSeries(lstQuery);
            commonUI.setListBoxSelectedIndex(lstQuery, 0);
        }

        private void loadSeries(ListBox lstQuery)
        {
            lstQuery.Items.Clear();
            queryEntityCollection.QueryEntities.ForEach(q => lstQuery.Items.Add(q.Name));
        }

        public void loadConditions(RichTextBox rtxtConditions, ListBox lstQuery)
        {
            rtxtConditions.Text = queryEntityCollection.QueryEntities[lstQuery.SelectedIndex].queryToString();
        }

        public void addQuery(ListBox lstQuery)
        {
            if (queryEntityCollection.QueryEntities.Count <= 15)
            {
                int index = lstQuery.SelectedIndex;
                int count = queryEntityCollection.QueryEntities.Count;
                QueryBuilder qb = new QueryBuilder(queryEntityCollection);
                qb.ShowDialog();
                loadSeries(lstQuery);

                if (count < queryEntityCollection.QueryEntities.Count)
                    commonUI.setListBoxSelectedIndex(lstQuery, lstQuery.Items.Count - 1);
                else
                    commonUI.setListBoxSelectedIndex(lstQuery, index);
            }
            else
            {
                MessageBox.Show("Error: Max number of queries allowed is fifteen (15)", "Error");
            }
        }

        public void editQuery(ListBox lstQuery)
        {
            int selectedIndex = lstQuery.SelectedIndex;
            QueryBuilder qb = new QueryBuilder(queryEntityCollection, selectedIndex);
            qb.ShowDialog();
            loadSeries(lstQuery);
            commonUI.setListBoxSelectedIndex(lstQuery, selectedIndex);
        }

        public void back(Form form)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            form.Close();
        }

        public void moveUp(ListBox lstQuery)
        {
            if (queryEntityCollection.QueryEntities.Count > 0)
            {
                if (lstQuery.SelectedIndex > 0)
                {
                    int selectedIndex = lstQuery.SelectedIndex;
                    queryEntityCollection.moveQueryUp(selectedIndex);
                    loadSeries(lstQuery);
                    commonUI.setListBoxSelectedIndex(lstQuery, selectedIndex - 1);
                }
            }
        }

        public void moveDown (ListBox lstQuery)
        {
            if (queryEntityCollection.QueryEntities.Count > 0)
            {
                if (lstQuery.SelectedIndex < lstQuery.Items.Count - 1)
                {
                    int selectedIndex = lstQuery.SelectedIndex;
                    queryEntityCollection.moveQueryDown(selectedIndex);
                    loadSeries(lstQuery);
                    commonUI.setListBoxSelectedIndex(lstQuery, selectedIndex + 1);
                }
            }
        }

        public void duplicate(ListBox lstQuery)
        {
            if (queryEntityCollection.QueryEntities.Count <= 15)
            {
                int selectedIndex = lstQuery.SelectedIndex;
                QueryEntity copiedQueryEntity = queryEntityCollection.QueryEntities[selectedIndex];
                string duplicateName = queryEntityCollection.getDuplicateName(copiedQueryEntity.Name);
                List<Query> copiedQueriesList = getCopiedQueriesList(copiedQueryEntity);
                queryEntityCollection.QueryEntities.Add(new QueryEntity(duplicateName, copiedQueriesList));
                loadSeries(lstQuery);
                commonUI.setListBoxSelectedIndex(lstQuery, lstQuery.Items.Count - 1);
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

        public void remove(ListBox lstQuery)
        {
            if (queryEntityCollection.QueryEntities.Count > 0)
            {
                int selectedIndex = lstQuery.SelectedIndex;
                queryEntityCollection.QueryEntities.RemoveAt(lstQuery.SelectedIndex);
                loadSeries(lstQuery);

                if (queryEntityCollection.QueryEntities.Count > 0)
                {
                    if (selectedIndex != 0) commonUI.setListBoxSelectedIndex(lstQuery, selectedIndex - 1);
                    else commonUI.setListBoxSelectedIndex(lstQuery, 0);
                }
            }
        }
    }
}
