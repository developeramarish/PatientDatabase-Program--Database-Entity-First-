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
            commonUI = new CommonUIMethodsAndFunctions();
        }

        public void onFormLoad(Panel panelGeneral, Panel panelChart)
        {




            loadPatientImage(panelGeneral);
            loadPatientGeneralData(panelGeneral);

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

        private void loadChartData(Panel panelChart)
        {
            Panel panelChartOutline = (Panel)commonUI.getControlFromPanel(panelChart, "panelChartOutline");
            Chart chartOutcomeData = (Chart)commonUI.getControlFromPanel(panelChartOutline, "chartOutcomeData");
            ComboBox cboProtocol = (ComboBox)commonUI.getControlFromPanel(panelChart, "cboProtocol");
            ComboBox cboOutcome = (ComboBox)commonUI.getControlFromPanel(panelChart, "cboOutcome");
            ComboBox cboStartInterval = (ComboBox)commonUI.getControlFromPanel(panelChart, "cboStartInterval");
            ComboBox cboEndInterval = (ComboBox)commonUI.getControlFromPanel(panelChart, "cboEndInterval");

            callLocation = Call_Location.LOAD;
            chartData.ShowPointAverageLabels = true;
            chartData.loadChartSeries(patient);
            chartData.loadProtocols();
            loadProtocolComboBox(cboProtocol);
            commonUI.setComboBoxSelectedIndex(cboProtocol, 0);
            loadChart(chartOutcomeData);
            callLocation = Call_Location.NONE;
        }

        public void ProtocolComboBoxIndexChanged(ComboBox cboProtocol, ComboBox cboOutcome, ComboBox cboEndInterval, Chart chartOutcomeData)
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
            loadDataFromComboBoxSelectedIndexChange(Call_Location.PROTOCOL, chartOutcomeData);
        }

        public void OutcomeComboBoxIndexChanged(ComboBox cboOutcome, Chart chartOutcomeData)
        {
            setCallLocation(Call_Location.OUTCOME);
            chartData.SelectedOutcome = chartData.Outcomes[cboOutcome.SelectedIndex];
            loadDataFromComboBoxSelectedIndexChange(Call_Location.OUTCOME, chartOutcomeData);
        }

        public void StartIntervalComboBoxIndexChanged(ComboBox cboStartInterval, Chart chartOutcomeData)
        {
            setCallLocation(Call_Location.START_INTERVAL);
            chartData.SelectedStartInterval = chartData.StartIntervals[cboStartInterval.SelectedIndex];
            loadDataFromComboBoxSelectedIndexChange(Call_Location.START_INTERVAL, chartOutcomeData);
        }

        public void EndIntervalComboBoxIndexChanged(ComboBox cboEndInterval, ComboBox cboStartInterval, Chart chartOutcomeData)
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
            loadDataFromComboBoxSelectedIndexChange(Call_Location.END_INTERVAL, chartOutcomeData);
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
    }
}
