using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Core.Objects.DataClasses;
using LinqKit;

using System.Linq.Expressions;



namespace PatientDatabase
{
    public partial class QueryBuilder : Form
    {
        CommandCenter queryCommands;
        DatabaseAccess database;
        List<Query> queries;
        int selectedRow;
        Query copiedQuery;
        QueryEntityCollection queryEntityCollection;
        int editQueryIndex;

        public QueryBuilder(QueryEntityCollection queryEntityCollection)
        {
            InitializeComponent();
            queryCommands = new CommandCenter();
            database = new DatabaseAccess();
            this.queryEntityCollection = queryEntityCollection;
            queries = new List<Query>();
            editQueryIndex = -1;
            checkSubmitStatus();
        }

        public QueryBuilder(QueryEntityCollection queryEntityCollection, int editQueryIndex)
        {
            InitializeComponent();
            queryCommands = new CommandCenter();
            database = new DatabaseAccess();
            this.queryEntityCollection = queryEntityCollection;
            queries = queryEntityCollection.QueryEntities[editQueryIndex].Queries;
            queries.ForEach(q => dgvCurrentQuery.Rows.Add(q.getGateText(), q.Property, q.Criteria, q.Filter));
            txtName.Text = queryEntityCollection.QueryEntities[editQueryIndex].Name;
            this.editQueryIndex = editQueryIndex;
        }

        private void QueryBuilder_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            dgvCurrentQuery.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            copiedQuery = null;

            // FOR TESTING, NOT FOR RELEASE
            //loadTestQueries();
            setSelectedRow();
        }

        private void QueryBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void dgvCurrentQuery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectedRow();
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            addCondition();
        }

        private void btnEditCondition_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) editCondition();
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) removeCondition();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) moveUp();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) moveDown();
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) applyInverse();
        }

        private void btnAndOr_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) applyGateChange();
        }

        private void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            if (queryEntityCollection.isNameValid(txtName.Text, editQueryIndex))
            {
                submitQuery();
            }
            else
            {
                MessageBox.Show("Error: Name is not valid!"
                    + Environment.NewLine
                    + Environment.NewLine
                    + "Name must not be blank and must not be a repeat of another query's name."
                    , "Error");
            }

        }

        private void dgvCurrentQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editCondition();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) copyCondition();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData() && copiedQuery != null) pasteCondition();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
