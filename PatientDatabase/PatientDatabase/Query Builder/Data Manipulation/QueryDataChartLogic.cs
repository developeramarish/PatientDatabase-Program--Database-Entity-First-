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
            chartData = new LineGraph();
            this.queryEntityCollection = queryEntityCollection;
            callLocation = Call_Location.NONE;
        }

        public void onFormLoad(ComboBox cboProtocol, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            callLocation = Call_Location.LOAD;
            chartData.cdi.loadChartSeries(queryEntityCollection.QueryEntities);
            loadSeriesListBox(lstSeries);
            chartData.cdi.loadProtocols();
            loadProtocolComboBox(cboProtocol);
            commonUI.setComboBoxSelectedIndex(cboProtocol, 0);
            loadQueryData(rtxtQueryData, lstSeries);
            loadChart(chartOutcomeData);
            callLocation = Call_Location.NONE;
        }

        private void loadSeriesListBox(ListBox lstSeries)
        {
            lstSeries.Items.Clear();
            chartData.cdi.ChartSeries.ForEach(cs => lstSeries.Items.Add(cs.getName()));
        }

        public void ProtocolComboBoxIndexChanged(ComboBox cboProtocol, ComboBox cboOutcome, ComboBox cboEndInterval, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            setCallLocation(Call_Location.PROTOCOL);
            chartData.cdi.SelectedProtocol = chartData.cdi.Protocols[cboProtocol.SelectedIndex];
            chartData.cdi.loadOutcomes();
            chartData.cdi.loadIntervals();
            chartData.cdi.loadEndIntervals();
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
            chartData.cdi.SelectedOutcome = chartData.cdi.Outcomes[cboOutcome.SelectedIndex];
            loadDataFromComboBoxSelectedIndexChange(Call_Location.OUTCOME, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        public void StartIntervalComboBoxIndexChanged(ComboBox cboStartInterval, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            setCallLocation(Call_Location.START_INTERVAL);
            chartData.cdi.SelectedStartInterval = chartData.cdi.StartIntervals[cboStartInterval.SelectedIndex];
            loadDataFromComboBoxSelectedIndexChange(Call_Location.START_INTERVAL, chartOutcomeData, rtxtQueryData, lstSeries);
        }

        public void EndIntervalComboBoxIndexChanged(ComboBox cboEndInterval, ComboBox cboStartInterval, Chart chartOutcomeData, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            setCallLocation(Call_Location.END_INTERVAL);
            chartData.cdi.SelectedEndInterval = chartData.cdi.EndIntervals[cboEndInterval.SelectedIndex];
            chartData.cdi.loadStartIntervals();
            int currentStartIntervalIndex = cboStartInterval.SelectedIndex;
            loadStartIntervalComboBox(cboStartInterval);
            if (chartData.cdi.SelectedStartInterval == null
                || chartData.cdi.SelectedStartInterval.Number >= chartData.cdi.SelectedEndInterval.Number)
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
            chartData.cdi.Protocols.ForEach(p => cboProtocol.Items.Add(p.Name));
        }

        private void loadOutcomeComboBox(ComboBox cboOutcome)
        {
            cboOutcome.Items.Clear();
            chartData.cdi.Outcomes.ForEach(o => cboOutcome.Items.Add(o.Name));
        }

        private void loadStartIntervalComboBox(ComboBox cboStartInterval)
        {
            cboStartInterval.Items.Clear();
            chartData.cdi.StartIntervals.ForEach(i => cboStartInterval.Items.Add(i.getMonthLabel()));
        }

        private void loadEndIntervalComboBox(ComboBox cboEndInterval)
        {
            cboEndInterval.Items.Clear();
            chartData.cdi.EndIntervals.ForEach(i => cboEndInterval.Items.Add(i.getMonthLabel()));
        }

        private void loadChart(Chart chartOutcomeData)
        {
            chartData.loadChartData(chartOutcomeData);
        }

        // shows/hides selected listbox series item
        public void toggle(Chart chartOutcomeData, ListBox lstSeries)
        {
            chartData.cdi.ChartSeries[lstSeries.SelectedIndex].toggleShow();

            // reloads item in listbox so draw item is triggered, thus changing back color of item depending on whether it's showing or hiding
            int index = lstSeries.SelectedIndex;
            if (index < lstSeries.Items.Count) lstSeries.Items.Insert(index, chartData.cdi.ChartSeries[index].getName());
            else lstSeries.Items.Add(chartData.cdi.ChartSeries[index].getName());
            lstSeries.Items.RemoveAt(index);

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
            chartData.cds.SelectedSeries = lstSeries.SelectedIndex;
            chartData.SetUpPointAverageLabels(chartOutcomeData);
        }

        private void loadQueryData(RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            rtxtQueryData.Text = queryEntityCollection.QueryEntities[lstSeries.SelectedIndex].entityToString();
            rtxtQueryData.AppendText(Environment.NewLine + Environment.NewLine);
            rtxtQueryData.AppendText(queryEntityCollection.QueryEntities[lstSeries.SelectedIndex].countToString());
            rtxtQueryData.AppendText(Environment.NewLine);
            rtxtQueryData.AppendText(chartData.cdi.ChartSeries[lstSeries.SelectedIndex]
                .getSeriesCount(
                chartData.cdi.SelectedProtocol, chartData.cdi.SelectedOutcome,
                chartData.cdi.SelectedStartInterval, chartData.cdi.SelectedEndInterval, chartData.cds.IncludeOnlyEligibleValues));
            rtxtQueryData.AppendText(Environment.NewLine + Environment.NewLine);
            rtxtQueryData.AppendText(chartData.cdi.ChartSeries[lstSeries.SelectedIndex]
                .getDataAnalysis(
                chartData.cdi.SelectedProtocol, chartData.cdi.SelectedOutcome,
                chartData.cdi.SelectedStartInterval, chartData.cdi.SelectedEndInterval, chartData.cds.IncludeOnlyEligibleValues));
        }

        public void toggleIntervalViewType(Chart chartOutcomeData, ToolStripMenuItem menuItem)
        {
            if (chartData.cds.ShowInBetweenIntervals)
            {
                chartData.cds.ShowInBetweenIntervals = false;
                menuItem.Checked = true;
            }
            else
            {
                chartData.cds.ShowInBetweenIntervals = true;
                menuItem.Checked = false;
            }

            chartData.loadChartData(chartOutcomeData);
        }

        public void setChartYAxisInterval(int interval, Chart chartOutcomeData, ToolStripMenuItem menuItem,
            ToolStripMenuItem yAxisScaleToolStripMenuItem)
        {
            chartData.cds.YAxisInterval = interval;

            foreach (ToolStripMenuItem item in yAxisScaleToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            menuItem.Checked = true;

            chartData.loadChartData(chartOutcomeData);
        }

        public void toggleChartGridLines(Chart chartOutcomeData, ToolStripMenuItem menuItem)
        {
            if (chartData.cds.ShowGridLines)
            {
                chartData.cds.ShowGridLines = false;
                menuItem.Checked = false;
            }
            else
            {
                chartData.cds.ShowGridLines = true;
                menuItem.Checked = true;
            }

            chartData.loadChartData(chartOutcomeData);
        }

        public void toggleShowSelectedSeriesAverages(Chart chartOutcomeData, ToolStripMenuItem menuItem)
        {
            if (chartData.cds.ShowPointAverageLabels)
            {
                chartData.cds.ShowPointAverageLabels = false;
                menuItem.Checked = false;
            }
            else
            {
                chartData.cds.ShowPointAverageLabels = true;
                menuItem.Checked = true;
            }

            chartData.loadChartData(chartOutcomeData);
        }

        public void toggleIncludeOnlyEligibleValues(Chart chartOutcomeData, ToolStripMenuItem menuItem, RichTextBox rtxtQueryData, ListBox lstSeries)
        {
            if (chartData.cds.IncludeOnlyEligibleValues)
            {
                chartData.cds.IncludeOnlyEligibleValues = false;
                menuItem.Checked = false;
            }
            else
            {
                chartData.cds.IncludeOnlyEligibleValues = true;
                menuItem.Checked = true;
            }

            chartData.loadChartData(chartOutcomeData);
            loadQueryData(rtxtQueryData, lstSeries);
        }

        public void drawListBoxSeriesItemColor(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            else
            {
                e.DrawBackground();
                Brush myBrush = Brushes.Black;
                Graphics g = e.Graphics;

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    if (chartData.cdi.ChartSeries[e.Index].Show)
                    {
                        myBrush = Brushes.White;
                        g.FillRectangle(new SolidBrush(Color.DarkGreen), e.Bounds);
                    }
                    else
                    {
                        myBrush = Brushes.White;
                        g.FillRectangle(new SolidBrush(SystemColors.Highlight), e.Bounds);
                    }
                }
                else
                {
                    if (chartData.cdi.ChartSeries[e.Index].Show)
                    {
                        myBrush = Brushes.White;
                        g.FillRectangle(new SolidBrush(Color.SeaGreen), e.Bounds);
                    }
                    else
                    {
                        myBrush = Brushes.Black;
                        g.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                    }
                }
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }


        private enum Call_Location
        {
            NONE, LOAD, PROTOCOL, OUTCOME, START_INTERVAL, END_INTERVAL
        }
    }
}
