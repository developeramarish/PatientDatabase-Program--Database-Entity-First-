﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class QueryEntity
    {
        public string Name { get; set; }
        public List<Query> Queries { get; set; }
        DatabaseAccess database;

        public QueryEntity(string name, List<Query> queries)
        {
            Name = name;
            Queries = queries;
            database = new DatabaseAccess();
        }

        public string entityToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Query Name:").AppendLine().Append(Name).AppendLine().AppendLine();
            sb.Append("Conditions:").AppendLine();
            sb.Append(queryToString()).AppendLine();
            return sb.ToString().Trim();
        }

        public string queryToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Queries.Count; i++)
            {
                Query query = Queries[i];
                if (i != 0)
                {
                    sb.Append(query.getGateText() + Environment.NewLine);
                }
                sb.Append(query.Property
                + " "
                + query.Criteria
                + " "
                + query.Filter).AppendLine();               
            }
            return sb.ToString().Trim();
        }

        public string countToString()
        {
            int count = getPatientCount();
            return "Total # of Patients: " + count + " (" + getPercentage(count) + "%)";
        }

        private decimal getPercentage(int count)
        {
            int total = database.getTableRecordCount("Patient");
            return Math.Round(((decimal)count / (decimal)total) * 100, 2);
        }

        public List<Patient> getPatients()
        {
            DatabaseAccess databaseAccess = new DatabaseAccess();
            return databaseAccess.loadPatientsFromQuery(Queries);
        }

        public int getPatientCount()
        {
            DatabaseAccess databaseAccess = new DatabaseAccess();
            return databaseAccess.loadPatientsFromQuery(Queries).Count;
        }
    }
}
