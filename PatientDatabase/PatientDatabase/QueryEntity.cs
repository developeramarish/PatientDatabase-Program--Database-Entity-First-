using System;
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

        public QueryEntity(string name, List<Query> queries)
        {
            Name = name;
            Queries = queries;
        }

        public string queryToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Query query in Queries)
            {
                sb.Append(
                    query.getGateText()
                    + " " 
                    + query.Property 
                    + " " 
                    + query.Criteria 
                    + " " 
                    + query.Filter).AppendLine();
            }
            return sb.ToString().Trim();
        }

        public List<Patient> getPatients()
        {
            DatabaseAccess databaseAccess = new DatabaseAccess();
            return databaseAccess.loadPatientsFromQuery(Queries);
        }
    }
}
