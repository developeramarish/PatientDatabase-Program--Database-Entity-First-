using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class CriteriaDate : Criteria
    {
        public CriteriaDate(string entity)
            : base(entity)
        {
            criteriaOptions = new CriteriaOption[]
            {
                new CriteriaOption("Is Equal To", true),
                new CriteriaOption("Is Between Inclusive", true),
                new CriteriaOption("Is Before Or Equal To", true),
                new CriteriaOption("Is After Or Equal To", true),
                new CriteriaOption("Is Between Exclusive", false),
                new CriteriaOption("Is Before", false),
                new CriteriaOption("Is After", false)
            };
        }

        public override int getFilterReqNumber(string criteriaOption)
        {
            criteriaOption = stripNot(criteriaOption);
            if (criteriaOption == "Is Between Inclusive" || criteriaOption == "Is Between Exclusive")
            {
                if (Entity == "") return 2;
                else return 3;
            }
            else
            {
                if (Entity == "") return 1;
                else return 2;
            }
        }

        public override string getFilterInstructions(string criteriaOption)
        {
            criteriaOption = stripNot(criteriaOption);
            if (criteriaOption == "Is Between Inclusive" || criteriaOption == "Is Between Exclusive")
            {
                if (Entity == "")
                {
                    return "Req 1: [Date] (MM/DD/YYYY)"
                        + Environment.NewLine + Environment.NewLine
                        + "Req 2: [Date] (MM/DD/YYYY)";
                }
                else
                {
                    return "Req 1: [" + Entity + " ID] (Use ID Helper)"
                        + Environment.NewLine + Environment.NewLine
                        + "Req 2: [Date] (MM/DD/YYYY)"
                        + Environment.NewLine + Environment.NewLine
                        + "Req 3: [Date] (MM/DD/YYYY)";
                }
            }
            else
            {
                if (Entity == "")
                {
                    return "Req 1: [Date] (MM/DD/YYYY)";
                }
                else
                {
                    return "Req 1: [" + Entity + " ID] (Use ID Helper)"
                        + Environment.NewLine + Environment.NewLine
                        + "Req 2: [Date] (MM/DD/YYYY)";
                }
            }
        }

        public override bool isFilterValid(string criteriaOption, string filter)
        {
            string[] filters = splitFilter(filter);
            string[] ids = splitId(filters[0]);
            criteriaOption = stripNot(criteriaOption);
            int intTest;
            DateTime dateTest;
            DateTime dateTest2;
            if (criteriaOption == "Is Between Inclusive" || criteriaOption == "Is Between Exclusive")
            {
                if (Entity == "")
                {
                    if (DateTime.TryParse(filters[0], out dateTest) 
                        && DateTime.TryParse(filters[1], out dateTest2))
                    {
                        if (dateTest < dateTest2) return true;
                    }
                        
                }
                else
                {
                    if (Int32.TryParse(ids[0], out intTest)
                        && DateTime.TryParse(filters[1], out dateTest)
                        && DateTime.TryParse(filters[2], out dateTest2))
                    {
                        if (dateTest < dateTest2) return true;
                    }
                }
            }
            else
            {
                if (Entity == "")
                {
                    if (DateTime.TryParse(filters[0], out dateTest))
                        return true;
                }
                else
                {
                    if (Int32.TryParse(ids[0], out intTest)
                        && DateTime.TryParse(filters[1], out dateTest))
                        return true;
                }
            }
            return false;
        }
    }
}
