using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public class MainMenuLogic
    {
        DatabaseAccess database;
        static QueryEntityCollection queryEntityCollection = new QueryEntityCollection();

        public MainMenuLogic()
        {
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

        public void onFormLoad()
        {
            GlobalFormManager.FormOpen();
            database.ConnectionString = @"metadata = res://*/PatientsModel.csdl|res://*/PatientsModel.ssdl|res://*/PatientsModel.msl;provider=System.Data.SqlClient;provider connection string="";data source=(localdb)\MSSQLLocalDB;initial catalog=PatientDatabase;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework"";";
            database.establishConnection();
        }

        public void loadPatientProfilePreSelectionForm(Form form)
        {
            PatientProfilePreSelection pps = new PatientProfilePreSelection();
            pps.Show();
            form.Close();
        }

        public void loadQueryManagerForm(Form form)
        {
            QueryManager qm = new QueryManager(queryEntityCollection);
            qm.Show();
            form.Close();
        }
    }
}
