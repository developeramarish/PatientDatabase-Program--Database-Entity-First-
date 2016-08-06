using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class CriteriaString : Criteria
    {
        public CriteriaString(string entity)
            : base(entity)
        {
            criteriaOptions = new CriteriaOption[]
            {
                new CriteriaOption("Is Equal To", true),
                new CriteriaOption("Starts With", true),
                new CriteriaOption("Contains", false),
                new CriteriaOption("Ends With", false)
            };
        }

        public override int getFilterReqNumber(string criteriaOption)
        {
            if (Entity == "") return 1;
            else return 2;
        }

        public override string getFilterInstructions(string criteriaOption)
        {
            if (Entity == "")
            {
                return "Req 1: [Anything]";
            }
            else
            {
                return "Req 1: [" + Entity + " ID] (Use ID Helper)"
                    + Environment.NewLine + Environment.NewLine
                    + "Req 2: [Anything]";
            }
        }

        public override bool isFilterValid(string criteriaOption, string filter)
        {
            string[] filters = splitFilter(filter);
            string[] ids = splitId(filter);
            int intTest;
            if (Entity == "")
            {
                if (filter != "") return true;
            }
            else
            {
                if (Int32.TryParse(ids[0], out intTest))
                {
                    filters[0] = "";
                    filter = string.Join("", filters);
                    if (filter.Trim() != "") return true;
                }
            }
            return false;
        }
    }
}
