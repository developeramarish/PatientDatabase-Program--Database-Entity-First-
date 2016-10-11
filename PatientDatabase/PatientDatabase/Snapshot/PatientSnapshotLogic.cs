using NodaTime;
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
            chartData = new LineGraph();
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

        // loads patient image from database
        // image is in binary format -- converts it to image using memory stream
        private Image getPatientProfileImage()
        {
            byte[] imageHexCode = database.getPatientImage(patient).Image;
            MemoryStream ms = new MemoryStream(imageHexCode);
            Image image = Image.FromStream(ms);
            image = GlobalImageMethods.ResizeImage(image, 256, 256);
            return image;
        }

        // loads basic patient information
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
            TreeView tvMedicalData = (TreeView)commonUI.getControlFromPanel(panelMedicalData, "tvMedicalData");
            tvMedicalData.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
            loadMorphineEquivalentDose(tvMedicalData);
            loadPastMedicalHistory(tvMedicalData);
            loadPathology(tvMedicalData);
            loadProblem(tvMedicalData);
            loadSurgery(tvMedicalData);
            loadTrauma(tvMedicalData);
            loadTreatment(tvMedicalData);
        }

        private void loadMorphineEquivalentDose(TreeView tvMedicalData)
        {
            tvMedicalData.Nodes.Add("Morphine Equivalent Dose");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].ImageIndex = 0;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].SelectedImageIndex = 0;

            List<PatientMedication> patientMedications = database.getPatientMedications(patient);

            Dictionary<DateTime, MorphineEquivalentDose> patientDateMEDs = new Dictionary<DateTime, MorphineEquivalentDose>();

            foreach (PatientMedication pm in patientMedications)
            {
                if (!patientDateMEDs.ContainsKey(pm.Start_Date))
                {
                    patientDateMEDs.Add(pm.Start_Date,
                        new MorphineEquivalentDose(
                            patient.getMorphineEquivalentDose(pm.Start_Date),
                            patientMedications
                            .Where(pm_ => pm_.Start_Date <= pm.Start_Date
                            && pm_.End_Date > pm.Start_Date)
                            .ToList()));
                }
                if (!patientDateMEDs.ContainsKey(pm.End_Date) && pm.End_Date <= DateTime.Now)
                {
                    patientDateMEDs.Add(pm.End_Date,
                        new MorphineEquivalentDose(
                            patient.getMorphineEquivalentDose(pm.End_Date),
                            patientMedications
                            .Where(pm_ => pm_.Start_Date <= pm.End_Date
                            && pm_.End_Date > pm.End_Date)
                            .ToList()));
                }
            }
            List<PatientMorphineEquivalentDose> patientMEDs = new List<PatientMorphineEquivalentDose>();
            foreach (KeyValuePair<DateTime, MorphineEquivalentDose> pdm in patientDateMEDs)
            {
                patientMEDs.Add(new PatientMorphineEquivalentDose(pdm.Key, pdm.Value));
            }
            patientMEDs = patientMEDs.OrderByDescending(pm => pm.Date).ToList();
            foreach (PatientMorphineEquivalentDose pm in patientMEDs)
            {
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add(pm.MED.MED + "mg - " + pm.Date.ToShortDateString());
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 0;
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 0;

                foreach (PatientMedication pm_ in pm.MED.MakeUp)
                {
                    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.Nodes.Add(
                        pm_.Medication.Name + " - " + pm_.Mg + "mg");
                }

                
            }











            //// start by adding current MED at this very moment
            //tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add("Current");
            //tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 0;
            //tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 0;
            //tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.Nodes.Add(
            //    patient.getMorphineEquivalentDose(DateTime.Now) + "mg");
            //tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.ImageIndex = 0;
            //tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.SelectedImageIndex = 0;

            //List<PatientMedication> patientCurrentMedications = database.getPatientMedications(patient)
            //        .Where(pm => pm.Start_Date <= DateTime.Now && pm.End_Date >= DateTime.Now)
            //        .ToList();

            //foreach (PatientMedication pm in patientCurrentMedications)
            //{
            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.Nodes
            //        .Add(pm.Medication.Name + " - " + pm.Mg + "mg");
            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.LastNode.ImageIndex = 0;
            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.LastNode.SelectedImageIndex = 0;
            //}

            //// later add MED breakdown into intervals from most recent to baseline
            //DateTime baseDate = patient.Date_Entered_Into_System;

            //LocalDate start = new LocalDate(baseDate.Year, baseDate.Month, baseDate.Day);
            //LocalDate end = new LocalDate(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //Period period = Period.Between(start, end, PeriodUnits.Months);
            //int months = (int)period.Months;
            //int monthIntervals = months / 3;

            //DateTime intervalDate = baseDate.AddMonths(monthIntervals);
            //for (int i = monthIntervals; i >= 0; i--)
            //{
            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add((i * 3) + " Months");
            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 0;
            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 0;


            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.Nodes.Add(
            //        patient.getMorphineEquivalentDose(intervalDate) + "mg"
            //        );
            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.ImageIndex = 0;
            //    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.SelectedImageIndex = 0;

            //    List<PatientMedication> patientMedications = database.getPatientMedications(patient)
            //        .Where(pm => pm.Start_Date <= intervalDate && pm.End_Date >= intervalDate)
            //        .ToList();

            //    foreach (PatientMedication pm in patientMedications)
            //    {
            //        tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.Nodes
            //            .Add(pm.Medication.Name + " - " + pm.Mg + "mg");
            //        tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.ImageIndex = 0;
            //        tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.LastNode.SelectedImageIndex = 0;

            //    }
            //    intervalDate.AddMonths(-3);
            //}
        }

        private void loadPastMedicalHistory(TreeView tvMedicalData)
        {
            tvMedicalData.Nodes.Add("Past Medical History");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].ImageIndex = 1;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].SelectedImageIndex = 1;

            List<PatientPast_Medical_History> patientPMH = database.getPatientPastMedicalHistory(patient);

            foreach (PatientPast_Medical_History pmh in patientPMH)
            {
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add(
                    pmh.Past_Medical_History.Name);
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 1;
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 1;

            }
        }

        private void loadPathology(TreeView tvMedicalData)
        {
            tvMedicalData.Nodes.Add("Pathology");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].ImageIndex = 2;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].SelectedImageIndex = 2;

            List<PatientPathology> patientPathology = database.getPatientPathology(patient);

            foreach (PatientPathology pp in patientPathology)
            {
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add(
                    pp.Pathology.Name);
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 2;
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 2;
            }
        }

        private void loadProblem(TreeView tvMedicalData)
        {
            tvMedicalData.Nodes.Add("Problem");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].ImageIndex = 3;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].SelectedImageIndex = 3;

            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add("Primary");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 3;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 3;

            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add("Other");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 3;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 3;


            List<PatientProblem> patientProblem = database.getPatientProblem(patient);

            foreach (PatientProblem pp in patientProblem)
            {
                if (pp.Primary == "Y")
                {
                    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes[0].Nodes.Add(
                        pp.Problem.Name);
                    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes[0].LastNode.ImageIndex = 3;
                    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes[0].LastNode.SelectedImageIndex = 3;
                }
                else
                {
                    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add(
                       pp.Problem.Name);
                    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 3;
                    tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 3;
                }
            }
        }

        private void loadSurgery(TreeView tvMedicalData)
        {
            tvMedicalData.Nodes.Add("Surgery");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].ImageIndex = 4;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].SelectedImageIndex = 4;

            List<PatientSurgery> patientSurgery = database.getPatientSurgery(patient).OrderBy(ps => ps.Date_Received).ToList();

            foreach (PatientSurgery ps in patientSurgery)
            {
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add(
                    ps.Surgery.Name + " - " + ps.Date_Received);
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 4;
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 4;
            }
        }

        private void loadTrauma(TreeView tvMedicalData)
        {
            tvMedicalData.Nodes.Add("Trauma");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].ImageIndex = 5;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].SelectedImageIndex = 5;

            List<PatientTrauma> patientTrauma = database.getPatientTrauma(patient);

            foreach (PatientTrauma pp in patientTrauma)
            {
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add(
                    pp.Trauma.Name);
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 5;
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 5;
            }
        }

        private void loadTreatment(TreeView tvMedicalData)
        {
            tvMedicalData.Nodes.Add("Treatment");
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].ImageIndex = 6;
            tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].SelectedImageIndex = 6;

            List<PatientTreatment> patientTreatment = database.getPatientTreatment(patient).OrderBy(pt => pt.Date_Received).ToList();

            foreach (PatientTreatment pt in patientTreatment)
            {
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].Nodes.Add(
                    pt.Treatment.Name + " - " + pt.Date_Received);
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.ImageIndex = 6;
                tvMedicalData.Nodes[tvMedicalData.Nodes.Count - 1].LastNode.SelectedImageIndex = 6;
            }
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
