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

namespace PatientDatabase
{
    public partial class PatientSnapshotLogic
    {
        Patient patient;
        DatabaseAccess database;
        ChartData chartData;
        CommonUIMethodsAndFunctions commonUI;

        public PatientSnapshotLogic(Patient patient)
        {
            this.patient = patient;
            database = new DatabaseAccess();
            chartData = new ChartData();
            commonUI = new CommonUIMethodsAndFunctions();
        }

        public void onFormLoad(Panel panelGeneral)
        {
            loadPatientImage(panelGeneral);
            loadPatientGeneralData(panelGeneral);

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
            RichTextBox rtxtGeneralInformation = (RichTextBox)commonUI.getControlFromPanel(panelGeneral, "rtxtGeneralInformation");
            rtxtGeneralInformation.AppendText("Last Name: ", new Font("Microsoft Sans Serif", 12F, FontStyle.Bold));
            rtxtGeneralInformation.AppendText(patient.Last_Name);
            rtxtGeneralInformation.AppendText(Environment.NewLine);

            rtxtGeneralInformation.AppendText("First Name: ", new Font("Microsoft Sans Serif", 12F, FontStyle.Bold));
            rtxtGeneralInformation.AppendText(patient.First_Name);
        }



       

    }
}
