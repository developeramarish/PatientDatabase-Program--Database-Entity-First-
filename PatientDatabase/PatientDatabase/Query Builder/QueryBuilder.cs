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
//using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Core.Objects.DataClasses;
using LinqKit;

using System.Linq.Expressions;



namespace PatientDatabase
{
    public partial class QueryBuilder : Form
    {
        DatabaseAccess database = new DatabaseAccess();
        List<Query> queries;
        int selectedRow;
        Query copiedQuery;

        public QueryBuilder()
        {
            InitializeComponent();
        }

        private void QueryBuilder_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            queries = new List<Query>();
            dgvCurrentQuery.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            copiedQuery = null;

            // FOR TESTING, NOT FOR RELEASE
            loadTestQueries();
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

        private void btnAddQuery_Click(object sender, EventArgs e)
        {
            addQuery();
        }

        private void btnEditQuery_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) editQuery();
        }

        private void btnRemoveQuery_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) removeQuery();
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

        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            runQuery();
        }

        private void dgvCurrentQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editQuery();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData()) copyQuery();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (dataGridViewHasData() && copiedQuery != null) pasteQuery();
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
    }
}
