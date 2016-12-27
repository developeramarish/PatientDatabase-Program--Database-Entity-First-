using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public partial class MainMenu : Form
    {
        MainMenuLogic logic;

        public MainMenu()
        {
            InitializeComponent();
            logic = new MainMenuLogic();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            logic.onFormLoad();
        }

        private void btnPatientProfiles_Click(object sender, EventArgs e)
        {
            //logic.loadPatientProfilePreSelectionForm(this);
            TestQueryBuilder tqb = new TestQueryBuilder(); tqb.Show(); this.Close();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }


        private void btnQueryManager_Click(object sender, EventArgs e)
        {
            logic.loadQueryManagerForm(this);
        }

        private void btnPatientSnapShot_Click(object sender, EventArgs e)
        {
            Patient patient = new DatabaseAccess().loadPatient(3);
            GlobalFormManager.OpenNewForm(new PatientSnapshot(patient), this);
            GlobalFormManager.CloseCurrentForm(this);
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
                dlg.Title = "Select Patient Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string imageLoc = dlg.FileName.ToString();
                    Image img = Image.FromFile(imageLoc);
                    img.Save("sih", System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] image = null;
                    FileStream fs = new FileStream(imageLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    image = br.ReadBytes((int)fs.Length);
                    using (PatientDatabaseEntities pde = new PatientDatabaseEntities())
                    {
                        PatientImage patientImage = pde.PatientImages.FirstOrDefault(pi => pi.PatientID == 3);
                        patientImage.Image = image;
                        pde.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
