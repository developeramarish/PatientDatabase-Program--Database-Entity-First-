using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class CriteriaIsCurrentlyHappening : Criteria
    {
        public CriteriaIsCurrentlyHappening(string entity)
            : base(entity)
        {
            criteriaOptions = new CriteriaOption[]
            {
                new CriteriaOption("Is Current", true)
            };
        }

        public override int getFilterReqNumber(string criteriaOption)
        {
            if (Entity == "") return 0;
            else return 1;
        }

        public override string getFilterInstructions(string criteria)
        {
            if (Entity == "")
            {
                return "No Filter Needed";
            }
            else
            {
                return "Req 1: [" + Entity + " ID] (Use ID Helper)";
            }
        }
    }
}
