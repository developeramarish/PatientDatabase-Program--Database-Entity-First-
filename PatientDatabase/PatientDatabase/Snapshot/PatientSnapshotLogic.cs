using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PatientDatabase
{
    public partial class PatientSnapshotLogic
    {
        Patient patient;
        DatabaseAccess database;
        ChartData chartData;
        CommonUIMethodsAndFunctions commonUI;
        Call_Location callLocation;

        public PatientSnapshotLogic(Patient patient)
        {
            this.patient = patient;
            database = new DatabaseAccess();
            chartData = new ChartData();
            chartData.cds.ShowPointAverageLabels = true;
            chartData.cds.IncludeOnlyEligibleValues = false;
            commonUI = new CommonUIMethodsAndFunctions();
        }

        public void onFormLoad(Panel panelGeneral, Panel panelChart, Panel panelMedicalData)
        {
            loadPatientImage(panelGeneral);
            loadPatientGeneralData(panelGeneral);
            loadMedicalData(panelMedicalData);
            loadChartData(panelChart);
        }

        private void loadPatientImage(Panel panelGeneral)
        {
            PictureBox picPatientPicture = (PictureBox)commonUI.getControlFromPanel(panelGeneral, "picPatientPicture");
            Image image = getPatientProfileImage();
            picPatientPicture.Image = image;
            picPatientPicture.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private Image getPatientProfileImage()
        {
            byte[] imageHexCode = database.getPatientImage(patient).Image;
            MemoryStream ms = new MemoryStream(imageHexCode);
            Image image = Image.FromStream(ms);
            image = GlobalImageMethods.ResizeImage(image, 256, 256);
            return image;
        }

        private void loadPatientGeneralData(Panel panelGeneral)
        {
            DataGridView dgvPatientGeneralInfo = (DataGridView)commonUI.getControlFromPanel(panelGeneral, "dgvPatientGeneralInfo");
            dgvPatientGeneralInfo.Rows.Add("Last Name:", patient.Last_Name);
            dgvPatientGeneralInfo.Rows.Add("First Name:", patient.First_Name);
            dgvPatientGeneralInfo.Rows.Add("Middle Name:", patient.Middle_Name);
            dgvPatientGeneralInfo.Rows.Add("Sex:", patient.Sex);
            dgvPatientGeneralInfo.Rows.Add("Date of Birth:", patient.Date_of_Birth.ToShortDateString());
            dgvPatientGeneralInfo.Rows.Add("Age:", patient.getAge());
            dgvPatientGeneralInfo.Rows.Add("First Visit:", patient.First_Visit.ToShortDateString());
            dgvPatientGeneralInfo.Rows.Add("Last Visit:", patient.Last_Visit.ToShortDateString());
            dgvPatientGeneralInfo.Rows.Add("Address:", patient.Address);
            dgvPatientGeneralInfo.Rows.Add("City:", patient.City);
            dgvPatientGeneralInfo.Rows.Add("State:", patient.State);
            dgvPatientGeneralInfo.Rows.Add("Zip Code:", patient.Zip_Code);
            dgvPatientGeneralInfo.Rows.Add("Country", patient.Country);
            dgvPatientGeneralInfo.Rows.Add("Date Added:", patient.Date_Entered_Into_System.ToShortDateString());
        }

        private void loadMedicalData(Panel panelMedicalData)
        {
            ComboBox cboInterval = (ComboBox)commonUI.getControlFromPanel(panelMedicalData, "cboMedicalDataInterval");
            DataGridView dgvMedicalData = (DataGridView)commonUI.getControlFromPanel(panelMedicalData, "dgvMedicalData");


        }

        private void loadChartData(Panel panelChart)
        {
            Panel panelChartOutline = (Panel)commonUI.getControlFromPanel(panelChart, "panelChartOutline");
            Chart chartOutcomeData = (Chart)commonUI.getControlFromPanel(panelChartOutline, "chartOutcomeData");
            ComboBox cboProtocol = (ComboBox)commonUI.getControlFromPanel(panelChart, "cboProtocol");
            ComboBox cboOutcome = (ComboBox)commonUI.getControlFromPanel(panelChart, "cboOutcome");
            ComboBox cboStartInterval = (ComboBox)commonUI.getControlFromPanel(panelChart, "cboStartInterval");
            ComboBox cboEndInterval = (ComboBox)commonUI.getControlFromPanel(panelChart, "cboEndInterval");

            callLocation = Call_Location.LOAD;
            chartData.cds.ShowPointAverageLabels = true;
            chartData.cdi.loadChartSeries(patient);
            chartData.cdi.loadProtocols();
            loadProtocolComboBox(cboProtocol);
            commonUI.setComboBoxSelectedIndex(cboProtocol, 0);
            loadChart(chartOutcomeData);
            callLocation = Call_Location.NONE;
        }

        public void ProtocolComboBoxIndexChanged(ComboBox cboProtocol, ComboBox cboOutcome, ComboBox cboEndInterval, Chart chartOutcomeData)
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
            loadDataFromComboBoxSelectedIndexChange(Call_Location.PROTOCOL, chartOutcomeData);
        }

        public void OutcomeComboBoxIndexChanged(ComboBox cboOutcome, Chart chartOutcomeData)
        {
            setCallLocation(Call_Location.OUTCOME);
            chartData.cdi.SelectedOutcome = chartData.cdi.Outcomes[cboOutcome.SelectedIndex];
            loadDataFromComboBoxSelectedIndexChange(Call_Location.OUTCOME, chartOutcomeData);
        }

        public void StartIntervalComboBoxIndexChanged(ComboBox cboStartInterval, Chart chartOutcomeData)
        {
            setCallLocation(Call_Location.START_INTERVAL);
            chartData.cdi.SelectedStartInterval = chartData.cdi.StartIntervals[cboStartInterval.SelectedIndex];
            loadDataFromComboBoxSelectedIndexChange(Call_Location.START_INTERVAL, chartOutcomeData);
        }

        public void EndIntervalComboBoxIndexChanged(ComboBox cboEndInterval, ComboBox cboStartInterval, Chart chartOutcomeData)
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
            loadDataFromComboBoxSelectedIndexChange(Call_Location.END_INTERVAL, chartOutcomeData);
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

        private enum Call_Location
        {
            NONE, LOAD, PROTOCOL, OUTCOME, START_INTERVAL, END_INTERVAL
        }

        private void setCallLocation(Call_Location callLocation)
        {
            if (this.callLocation == Call_Location.NONE) this.callLocation = callLocation;
        }

        private void loadDataFromComboBoxSelectedIndexChange(Call_Location callLocation, Chart chartOutcomeData)
        {
            if (this.callLocation == callLocation)
            {
                loadChart(chartOutcomeData);
                this.callLocation = Call_Location.NONE;
            }
        }

        private void loadChart(Chart chartOutcomeData)
        {
            chartData.loadChartData(chartOutcomeData);
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

        public void changeChartDimensions(Size size, Chart chartOutcomeData,
             ToolStripMenuItem parentMenuItem, ToolStripMenuItem selectedMenuItem,
             Panel panelChartOutline)
        {
            foreach (ToolStripMenuItem item in parentMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            selectedMenuItem.Checked = true;
            chartOutcomeData.MinimumSize = size;
            chartOutcomeData.Size = size;
            panelChartOutline.AutoScrollMinSize = size;
        }
    }
}
