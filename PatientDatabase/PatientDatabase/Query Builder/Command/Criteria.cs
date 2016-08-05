using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public abstract class Criteria
    {
        public string Entity { get; }
        protected CriteriaOption[] criteriaOptions;

        public Criteria(string entity)
        {
            Entity = entity;
        }

        public string[] getCriteriaOptions(string filter, bool devMode, bool not)
        {
            CriteriaOption[] temp = getCriteriaOptionsFiltered(filter, devMode);
            List<string> names = new List<string>();
            temp.ToList().ForEach(c => names.Add(c.Name));
            if (not) names = notCriteria(names);
            return names.ToArray();
        }

        private CriteriaOption[] getCriteriaOptionsFiltered(string filter, bool devMode)
        {
            if (!devMode)
            {
                if (filter == "") return criteriaOptions.Where(p => p.StandardCommand == true).ToArray();
                else return criteriaOptions.Where(p => p.StandardCommand == true && p.Name.StartsWith(filter)).ToArray();
            }
            else
            {
                if (filter == "") return criteriaOptions;
                else return criteriaOptions.Where(p => p.Name.StartsWith(filter)).ToArray();
            }
        }

        private List<string> notCriteria(List<string> names)
        {
            for (int i = 0; i < names.Count; i++) names[i] += " NOT";
            return names;          
        }

        public virtual int getFilterReqNumber(string criteriaOption)
        {
            return 0;
        }

        public virtual string getFilterInstructions(string criteriaOption)
        {
            return "";
        }

        public virtual bool isFilterValid(string filter)
        {
            return false;
        }
    }
}
