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
        DatabaseAccess database;

        public MainMenu()
        {
            InitializeComponent();
            database = new DatabaseAccess();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            database.establishConnection();
        }

        private void btnPatientProfiles_Click(object sender, EventArgs e)
        {
            PatientProfilePreSelection pps = new PatientProfilePreSelection();
            pps.Show();
            this.Close();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalFormManager.FormClose();
        }

        private void btnQueryBuilder_Click(object sender, EventArgs e)
        {
            QueryBuilder qb = new QueryBuilder();
            qb.Show();
            this.Close();
        }
    }
}
