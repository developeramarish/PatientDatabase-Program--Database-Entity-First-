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
            logic.ListBoxSeriesSelectedIndexChanged(rtxtQueryData, lstSeries, chartOutcomeData);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GlobalFormManager.OpenNewForm(new QueryManager(logic.queryEntityCollection), this);
            GlobalFormManager.CloseCurrentForm(this);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GlobalFormManager.Home(this);
        }

        private void onlyShowStartAndEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.toggleIntervalViewType(chartOutcomeData, onlyShowStartAndEndToolStripMenuItem);           
        }

        private void YAxisInterval20toolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.setChartYAxisInterval(20, chartOutcomeData, YAxisInterval20toolStripMenuItem,
                yAxisScaleToolStripMenuItem);
        }

        private void YAxisInterval10toolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.setChartYAxisInterval(10, chartOutcomeData, YAxisInterval10toolStripMenuItem,
                yAxisScaleToolStripMenuItem);
        }

        private void YAxisInterval5toolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.setChartYAxisInterval(5, chartOutcomeData, YAxisInterval5toolStripMenuItem,
                yAxisScaleToolStripMenuItem);
        }

        private void showGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.toggleChartGridLines(chartOutcomeData, showGridToolStripMenuItem);
        }

        private void showSelectedSeriesAveragesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.toggleShowSelectedSeriesAverages(chartOutcomeData, showSelectedSeriesAveragesToolStripMenuItem);
        }

        private void includeOnlyEligibleValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logic.toggleIncludeOnlyEligibleValues(chartOutcomeData, includeOnlyEligibleValuesToolStripMenuItem, rtxtQueryData, lstSeries);
        }

        private void lstSeries_DrawItem(object sender, DrawItemEventArgs e)
        {
            logic.drawListBoxSeriesItemColor(sender, e);
            
        }
    
    }
}
