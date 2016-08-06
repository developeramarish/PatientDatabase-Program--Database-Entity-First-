using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class CriteriaBoolean : Criteria
    {
        public string[] Choices { get; }

        public CriteriaBoolean(string entity, string[] choices)
            : base(entity)
        {
            this.Choices = choices;
            criteriaOptions = new CriteriaOption[]
            {
                new CriteriaOption("Is Equal To", true)
            };
        }

        public override int getFilterReqNumber(string criteriaOption)
        {
            if (Entity == "") return 1;
            else return 2;
        }

        public override string getFilterInstructions(string criteriaOption)
        {
            string possibleChoices = string.Join("/", Choices);
            if (Entity == "")
            {
                return "Req 1: [" + possibleChoices + "]";
            }
            else
            {
                return "Req 1: [" + Entity + " ID] (Use ID Helper)"
                    + Environment.NewLine + Environment.NewLine
                    + "Req 2: [" + possibleChoices + "]";
            }
        }

        public override bool isFilterValid(string criteriaOption, string filter)
        {
            string[] filters = splitFilter(filter);
            string[] ids = splitId(filters[0]);
            int intTest;
            criteriaOption = stripNot(criteriaOption);

            if (Entity == "")
            {
                if (criteriaOption == "Is Equal To")
                {
                    foreach (string choice in Choices)
                    {
                        if (filters[0].ToUpper() == choice.ToUpper()) return true;
                    }
                }
            }
            else
            {
                if (criteriaOption == "Is Equal To")
                {
                    if (Int32.TryParse(ids[0], out intTest))
                    {
                        foreach (string choice in Choices)
                        {
                            if (filters[1].ToUpper() == choice.ToUpper()) return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
