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
        static QueryEntityCollection queryEntityCollection = new QueryEntityCollection();

        public MainMenu()
        {
            InitializeComponent();
            database = new DatabaseAccess();

            // TEST LINE REMOVE IN REAL BUILD
            if (queryEntityCollection.QueryEntities.Count == 0) LoadTestEntities();
        }

        private void LoadTestEntities()
        {
            List<Query> queries = new List<Query>();
            queries.Add(new PatientQuery("Sex", "Is Equal To", "Male"));
            queryEntityCollection.QueryEntities.Add(new QueryEntity("All Male", queries));

            List<Query> queries2 = new List<Query>();
            queries2.Add(new PatientQuery("Sex", "Is Equal To", "Female"));
            queryEntityCollection.QueryEntities.Add(new QueryEntity("All Female", queries2));

            List<Query> queries3 = new List<Query>();
            queries3.Add(new PatientQuery("Age", "Is Greater Than Or Equal To", "18"));
            queryEntityCollection.QueryEntities.Add(new QueryEntity("Age Above 18", queries3));
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            GlobalFormManager.FormOpen();
            database.ConnectionString = @"metadata = res://*/PatientsModel.csdl|res://*/PatientsModel.ssdl|res://*/PatientsModel.msl;provider=System.Data.SqlClient;provider connection string="";data source=(localdb)\MSSQLLocalDB;initial catalog=PatientDatabase;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework"";";
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
         //   QueryBuilder qb = new QueryBuilder();
         //   qb.Show();
            this.Close();
        }

        private void btnQueryManager_Click(object sender, EventArgs e)
        {
            //DataCharts dc = new DataCharts(new List<Query>());
            //dc.Show();
            QueryManager qm = new QueryManager(queryEntityCollection);
            qm.Show();
            this.Close();
        }
    }
}
