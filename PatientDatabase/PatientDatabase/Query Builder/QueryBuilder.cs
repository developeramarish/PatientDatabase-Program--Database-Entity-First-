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
        QueryBuilderLogic logic;

        public QueryBuilder(QueryEntityCollection queryEntityCollection)
        {
            InitializeComponent();
            logic = new QueryBuilderLogic(queryEntityCollection, -1);       
        }

        public QueryBuilder(QueryEntityCollection queryEntityCollection, int editQueryIndex)
        {
            InitializeComponent();
            logic = new QueryBuilderLogic(queryEntityCollection, editQueryIndex);
        }

        private void QueryBuilder_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            logic.onFormLoad(dgvCurrentQuery, btnSubmitQuery, txtName);
        }

        private void QueryBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            logic.addCondition(dgvCurrentQuery, btnSubmitQuery);
        }

        private void btnEditCondition_Click(object sender, EventArgs e)
        {
            logic.editCondition(dgvCurrentQuery);
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            logic.removeCondition(dgvCurrentQuery, btnSubmitQuery);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            
            logic.moveUp(dgvCurrentQuery);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            logic.moveDown(dgvCurrentQuery);
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            logic.applyInverse(dgvCurrentQuery);
        }

        private void btnAndOr_Click(object sender, EventArgs e)
        {
            logic.applyGateChange(dgvCurrentQuery);
        }

        private void btnSubmitQuery_Click(object sender, EventArgs e)
        {
            logic.submitQuery(txtName, this);
        }
   
        private void dgvCurrentQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            logic.editCondition(dgvCurrentQuery);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            logic.copyCondition(dgvCurrentQuery);
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            logic.pasteCondition(dgvCurrentQuery);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GlobalFormManager.Home(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
