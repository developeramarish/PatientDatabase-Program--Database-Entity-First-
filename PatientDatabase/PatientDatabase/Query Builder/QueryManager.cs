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
        QueryManagerLogic logic;

        public QueryManager(QueryEntityCollection queryEntityCollection)
        {
            InitializeComponent();
            logic = new QueryManagerLogic(queryEntityCollection);
        }

        private void ChartSeriesManager_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            logic.onFormLoad(lstQuery);
        }

        private void QueryManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void lstQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.loadConditions(rtxtConditions, lstQuery);
        }

        private void btnAddQuery_Click(object sender, EventArgs e)
        {
            logic.addQuery(lstQuery);
        }

        private void btnEditQuery_Click(object sender, EventArgs e)
        {
            logic.editQuery(lstQuery);
        }

        private void lstQuery_DoubleClick(object sender, EventArgs e)
        {
            logic.editQuery(lstQuery);
        }

        private void btnDataChart_Click(object sender, EventArgs e)
        {
            GlobalFormManager.OpenNewForm(new QueryDataChart(logic.queryEntityCollection), this);
            GlobalFormManager.CloseCurrentForm(this);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            logic.back(this);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GlobalFormManager.Home(this);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            logic.moveUp(lstQuery);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            logic.moveDown(lstQuery);
        }

        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            logic.duplicate(lstQuery);
        }

        private void btnRemoveQuery_Click(object sender, EventArgs e)
        {
            logic.remove(lstQuery, rtxtConditions);
        }
    }
}
