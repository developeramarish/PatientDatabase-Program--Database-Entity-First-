using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatientDatabase
{
    public class QueryDataChartLogic
    {
        DatabaseAccess database;
        CommonUIMethodsAndFunctions commonUI;
        ChartData chartData;
        public QueryEntityCollection queryEntityCollection { get; set; }
        Call_Location callLocation;

        public QueryDataChartLogic(QueryEntityCollection queryEntityCollection)
        {
            database = new DatabaseAccess();
            commonUI = new CommonUIMethodsAndFunctions();
            chartData = new ChartData();
            this.queryEntityCollection = queryEntityCollection;
            callLocation = Call_Location.NONE;
        }

        public void onFormLoad(ComboBox cboProtocol, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            callLocation = Call_Location.LOAD;
            chartData.loadChartSeries(queryEntityCollection.QueryEntities);
            loadSeriesListBox(lstSeries);
            chartData.loadProtocols();
            loadProtocolComboBox(cboProtocol);
            commonUI.setComboBoxSelectedIndex(cboProtocol, 0);
            loadQueryData(rtxtQueryData, lstSeries);
            loadChart(chartOutcomeData);
            callLocation = Call_Location.NONE;
        }

        private void loadSeriesListBox(ListBox lstSeries)
        {
            lstSeries.Items.Clear();
            chartData.ChartSeries.ForEach(cs => lstSeries.Items.Add(cs.getName()));
        }

        public void ProtocolComboBoxIndexChanged(ComboBox cboProtocol, ComboBox cboOutcome, ComboBox cboEndInterval, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            setCallLocation(Call_Location.PROTOCOL);
            chartData.SelectedProtocol = chartData.Protocols[cboProtocol.SelectedIndex];
            chartData.loadOutcomes();
            chartData.loadIntervals();
            chartData.loadEndIntervals();
            loadOutcomeComboBox(cboOutcome);
            loadEndIntervalComboBox(cboEndInterval);
            commonUI.setComboBoxSelectedIndex(cboOutcome, 0);
            commonUI.setComboBoxSelectedIndex(cboEndInterval, cboEndInterval.Items.Count - 1);
            commonUI.setListBoxSelectedIndex(lstSeries, 0);
            loadDataFromComboBoxSelectedIndexChange(Call_Location.PROTOCOL, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        public void OutcomeComboBoxIndexChanged(ComboBox cboOutcome, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            setCallLocation(Call_Location.OUTCOME);
            chartData.SelectedOutcome = chartData.Outcomes[cboOutcome.SelectedIndex];
            loadDataFromComboBoxSelectedIndexChange(Call_Location.OUTCOME, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        public void StartIntervalComboBoxIndexChanged(ComboBox cboStartInterval, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            setCallLocation(Call_Location.START_INTERVAL);
            chartData.SelectedStartInterval = chartData.StartIntervals[cboStartInterval.SelectedIndex];
            loadDataFromComboBoxSelectedIndexChange(Call_Location.START_INTERVAL, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        public void EndIntervalComboBoxIndexChanged(ComboBox cboEndInterval, ComboBox cboStartInterval, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            setCallLocation(Call_Location.END_INTERVAL);
            chartData.SelectedEndInterval = chartData.EndIntervals[cboEndInterval.SelectedIndex];
            chartData.loadStartIntervals();
            int currentStartIntervalIndex = cboStartInterval.SelectedIndex;
            loadStartIntervalComboBox(cboStartInterval);
            if (chartData.SelectedStartInterval == null
                || chartData.SelectedStartInterval.Number >= chartData.SelectedEndInterval.Number)
            {
                commonUI.setComboBoxSelectedIndex(cboStartInterval, 0);
            }
            else commonUI.setComboBoxSelectedIndex(cboStartInterval, currentStartIntervalIndex);
            loadDataFromComboBoxSelectedIndexChange(Call_Location.END_INTERVAL, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        private void setCallLocation(Call_Location callLocation)
        {
            if (this.callLocation == Call_Location.NONE) this.callLocation = callLocation;
        }

        private void loadDataFromComboBoxSelectedIndexChange(Call_Location callLocation, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            if (this.callLocation == callLocation)
            {
                loadQueryData(rtxtQueryData, lstSeries);
                loadChart(chartOutcomeData);
                this.callLocation = Call_Location.NONE;
            }
        }

        private void loadProtocolComboBox(ComboBox cboProtocol)
        {
            cboProtocol.Items.Clear();
            chartData.Protocols.ForEach(p => cboProtocol.Items.Add(p.Name));
        }

        private void loadOutcomeComboBox(ComboBox cboOutcome)
        {
            cboOutcome.Items.Clear();
            chartData.Outcomes.ForEach(o => cboOutcome.Items.Add(o.Name));
        }

        private void loadStartIntervalComboBox(ComboBox cboStartInterval)
        {
            cboStartInterval.Items.Clear();
            chartData.StartIntervals.ForEach(i => cboStartInterval.Items.Add(i.getMonthLabel()));
        }

        private void loadEndIntervalComboBox(ComboBox cboEndInterval)
        {
            cboEndInterval.Items.Clear();
            chartData.EndIntervals.ForEach(i => cboEndInterval.Items.Add(i.getMonthLabel()));
        }

        private void loadChart(Chart chartOutcomeData)
        {
            chartData.loadChartData(chartOutcomeData);
        }

        public void toggle(Chart chartOutcomeData, ListBox lstSeries)
        {
            chartData.ChartSeries[lstSeries.SelectedIndex].toggleShow();
            loadChart(chartOutcomeData);
        }

        public void moveUp(Chart chartOutcomeData, ListBox lstSeries)
        {
            if (lstSeries.SelectedIndex > 0)
            {
                int selectedIndex = lstSeries.SelectedIndex;
                queryEntityCollection.moveQueryUp(selectedIndex);
                chartData.moveSeriesUp(selectedIndex, queryEntityCollection);
                loadSeriesListBox(lstSeries);
                commonUI.setListBoxSelectedIndex(lstSeries, selectedIndex - 1);
                loadChart(chartOutcomeData);
            }
        }

        public void moveDown(Chart chartOutcomeData, ListBox lstSeries)
        {
            if (lstSeries.SelectedIndex < lstSeries.Items.Count - 1)
            {
                int selectedIndex = lstSeries.SelectedIndex;
                queryEntityCollection.moveQueryDown(selectedIndex);
                chartData.moveSeriesDown(selectedIndex, queryEntityCollection);
                loadSeriesListBox(lstSeries);
                commonUI.setListBoxSelectedIndex(lstSeries, selectedIndex + 1);
                loadChart(chartOutcomeData);
            }
        }

        public void ListBoxSeriesSelectedIndexChanged(RichTextBox rtxtQueryData, ListBox lstSeries, Chart chartOutcomeData)
        {
            loadQueryData(rtxtQueryData, lstSeries);
            chartData.SelectedSeries = lstSeries.SelectedIndex;
            chartData.SetUpPointAverageLabels(chartOutcomeData);
        }

        private void loadQueryData(RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            rtxtQueryData.Text = queryEntityCollection.QueryEntities[lstSeries.SelectedIndex].entityToString();
            rtxtQueryData.AppendText(Environment.NewLine + Environment.NewLine);
            rtxtQueryData.AppendText(queryEntityCollection.QueryEntities[lstSeries.SelectedIndex].countToString());
            rtxtQueryData.AppendText(Environment.NewLine);
            rtxtQueryData.AppendText(chartData.ChartSeries[lstSeries.SelectedIndex]
                .getSeriesCount(
                chartData.SelectedProtocol, chartData.SelectedOutcome,
                chartData.SelectedStartInterval, chartData.SelectedEndInterval, chartData.IncludeOnlyEligibleValues));
            rtxtQueryData.AppendText(Environment.NewLine + Environment.NewLine);
            rtxtQueryData.AppendText(chartData.ChartSeries[lstSeries.SelectedIndex]
                .getDataAnalysis(
                chartData.SelectedProtocol, chartData.SelectedOutcome,
                chartData.SelectedStartInterval, chartData.SelectedEndInterval, chartData.IncludeOnlyEligibleValues));
        }

        public void toggleIntervalViewType(Chart chartOutcomeData, ToolStripMenuItem menuItem)
        {
            if (chartData.ShowInBetweenIntervals)
            {
                chartData.ShowInBetweenIntervals = false;
                menuItem.Checked = true;
            }
            else
            {
                chartData.ShowInBetweenIntervals = true;
                menuItem.Checked = false;
            }

            chartData.loadChartData(chartOutcomeData);
        }

        public void setChartYAxisInterval(int interval, Chart chartOutcomeData, ToolStripMenuItem menuItem,
            ToolStripMenuItem yAxisScaleToolStripMenuItem)
        {
            chartData.YAxisInterval = interval;

            foreach (ToolStripMenuItem item in yAxisScaleToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            menuItem.Checked = true;

            chartData.loadChartData(chartOutcomeData);
        }

        public void toggleChartGridLines(Chart chartOutcomeData, ToolStripMenuItem menuItem)
        {
            if (chartData.ShowGridLines)
            {
                chartData.ShowGridLines = false;
                menuItem.Checked = false;
            }
            else
            {
                chartData.ShowGridLines = true;
                menuItem.Checked = true;
            }

            chartData.loadChartData(chartOutcomeData);
        }

        public void toggleShowSelectedSeriesAverages(Chart chartOutcomeData, ToolStripMenuItem menuItem)
        {
            if (chartData.ShowPointAverageLabels)
            {
                chartData.ShowPointAverageLabels = false;
                menuItem.Checked = false;
            }
            else
            {
                chartData.ShowPointAverageLabels = true;
                menuItem.Checked = true;
            }

            chartData.loadChartData(chartOutcomeData);
        }

        public void toggleIncludeOnlyEligibleValues(Chart chartOutcomeData, ToolStripMenuItem menuItem, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            if (chartData.IncludeOnlyEligibleValues)
            {
                chartData.IncludeOnlyEligibleValues = false;
                menuItem.Checked = false;
            }
            else
            {
                chartData.IncludeOnlyEligibleValues = true;
                menuItem.Checked = true;
            }

            chartData.loadChartData(chartOutcomeData);
            loadQueryData(rtxtQueryData, lstSeries);
        }


        private enum Call_Location
        {
            NONE, LOAD, PROTOCOL, OUTCOME, START_INTERVAL, END_INTERVAL
        }
    }
}
