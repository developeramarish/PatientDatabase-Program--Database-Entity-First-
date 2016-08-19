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
            logic.loadPatientProfilePreSelectionForm(this);
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }


        private void btnQueryManager_Click(object sender, EventArgs e)
        {
            logic.loadQueryManagerForm(this);
        }
    }
}
