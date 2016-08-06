using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class CriteriaInt : Criteria
    {
        public string NumberType { get; }
        public string Measurement { get; }

        public CriteriaInt(string entity, string numberType, string measurement)
            : base(entity)
        {
            this.NumberType = numberType;
            this.Measurement = measurement;
            criteriaOptions = new CriteriaOption[]
            {
                new CriteriaOption("Is Equal To", true),
                new CriteriaOption("Is Between Inclusive", true),
                new CriteriaOption("Is Greater Than Or Equal To", true),
                new CriteriaOption("Is Less Than Or Equal To", true),
                new CriteriaOption("Is Between Exclusive", false),
                new CriteriaOption("Is Greater Than", false),
                new CriteriaOption("Is Less Than", false)
            };
        }

        public override int getFilterReqNumber(string criteriaOption)
        {
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
                    return "Req 1: [Number] (" + NumberType + ") (" + Measurement + ")"
                        + Environment.NewLine + Environment.NewLine
                        + "Req 2: [Number] (" + NumberType + ") (" + Measurement + ")";
                }
                else
                {
                    return "Req 1: [" + Entity + " ID] (Use ID Helper)"
                        + Environment.NewLine + Environment.NewLine
                        + "Req 2: [Number] (" + NumberType + ") (" + Measurement + ")"
                        + Environment.NewLine + Environment.NewLine
                        + "Req 3: [Number] (" + NumberType + ") (" + Measurement + ")";
                }
            }
            else
            {
                if (Entity == "")
                {
                    return "Req 1: [Number] (" + NumberType + ") (" + Measurement + ")";
                }
                else
                {
                    return "Req 1: [" + Entity + " ID] (Use ID Helper)"
                        + Environment.NewLine + Environment.NewLine
                        + "Req 2: [Number] (" + NumberType + ") (" + Measurement + ")";
                }
            }
        }

        public override bool isFilterValid(string criteriaOption, string filter)
        {
            string[] filters = splitFilter(filter);
            string[] ids = splitId(filters[0]);
            criteriaOption = stripNot(criteriaOption);
            int intTest;
            int intTest2;
            int intTest3;
            if (criteriaOption == "Is Between Inclusive" || criteriaOption == "Is Between Exclusive")
            {
                if (Entity == "")
                {
                    if (Int32.TryParse(filters[0], out intTest)
                        && Int32.TryParse(filters[1], out intTest2))
                    {
                        if (intTest < intTest2) return true;
                    }

                }
                else
                {
                    if (Int32.TryParse(ids[0], out intTest)
                        && Int32.TryParse(filters[1], out intTest2)
                        && Int32.TryParse(filters[2], out intTest3))
                    {
                        if (intTest2 < intTest3) return true;
                    }
                }
            }
            else
            {
                if (Entity == "")
                {
                    if (Int32.TryParse(filters[0], out intTest))
                        return true;
                }
                else
                {
                    if (Int32.TryParse(ids[0], out intTest)
                        && Int32.TryParse(filters[1], out intTest2))
                        return true;
                }
            }
            return false;
        }
    }
}
