using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatientDatabase
{
    public partial class QueryDataChart : Form
    {
        QueryDataChartLogic logic;

        public QueryDataChart(QueryEntityCollection queryEntityCollection)
        {
            InitializeComponent();
            logic = new QueryDataChartLogic(queryEntityCollection);
        }

        private void DataCharts_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            logic.onFormLoad(cboProtocol, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        private void DataCharts_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void cboProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.ProtocolComboBoxIndexChanged(cboProtocol, cboOutcome, cboEndInterval, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.OutcomeComboBoxIndexChanged(cboOutcome, chartOutcomeData, rtxtQueryData, lstSeries);          
        }

        private void cboStartInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.StartIntervalComboBoxIndexChanged(cboStartInterval, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        private void cboEndInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.EndIntervalComboBoxIndexChanged(cboEndInterval, cboStartInterval, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            logic.toggle(chartOutcomeData, lstSeries);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            logic.moveUp(chartOutcomeData, lstSeries);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            logic.moveDown(chartOutcomeData, lstSeries);
        }

        private void lstSeries_DoubleClick(object sender, EventArgs e)
        {
            logic.toggle(chartOutcomeData, lstSeries);
        }

        private void lstSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.ListBoxSeriesSelectedIndexChanged(rtxtQueryData, lstSeries);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            logic.back(this);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GlobalFormManager.Home(this);
        }
    }
}
