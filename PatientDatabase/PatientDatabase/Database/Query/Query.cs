using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq.Expressions;

namespace PatientDatabase
{
    public abstract class Query
    {
        public string Property { get; set; }
        public string Criteria { get; set; }
        public string Filter { get; set; }
        public bool StartGroup { get; set; }
        public bool ContinueGroup { get; set; }
        public bool EndGroup { get; set; }
        public bool StandAlone { get; set; }
        public bool And { get; set; }
        public bool Or { get; set; }

        public Query(string property, string criteria, string filter)
        {
            Filter = filter;
            Property = property;
            Criteria = criteria;
            And = true;
        }

        public Query(string property, string criteria, string filter, bool and, bool or)
        {
            Filter = filter;
            Property = property;
            Criteria = criteria;
            And = and;
            Or = or;
        }
        public virtual Expression<Func<Patient, bool>> runQuery() { return p => false; }
        
        public string getGroupText()
        {
            if (StartGroup) return "Start";
            else if (EndGroup) return "End";
            else return "";
        }

        public string getGateText()
        {
            if (And) return "AND";
            else if (Or) return "OR";
            else return "";
        }

        public bool isInGroup()
        {
            return StartGroup || ContinueGroup || EndGroup;
        }

        public void inverseGates()
        {
            if (And)
            {
                And = false;
                Or = true;
                StandAlone = false;
            }
            else if (Or)
            {
                And = true;
                Or = false;

                if (!isInGroup()) StandAlone = true; 
            }
        }
    }
}
