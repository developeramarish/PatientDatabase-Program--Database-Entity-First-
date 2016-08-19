using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class CommandCenter
    {
        protected Property[] properties;

        public CommandCenter()
        {
            properties = loadProperties();
        }

        private Property[] loadProperties()
        {
            return new Property[]
            {
                new PropertyString("Last Name", false),
                new PropertyString("First Name", false),
                new PropertyString("Middle Name", false),
                new PropertyBoolean("Sex", true, new string[] { "Male", "Female" }),
                new PropertyDate("Date of Birth", false),
                new PropertyInt("Age", true, "Whole Number", "Years"),
                new PropertyDate("Date Entered Into System", false),
                new PropertyDate("First Visit", false),
                new PropertyDate("Last Visit", false),
                new PropertyString("Address", false),
                new PropertyString("City", false),
                new PropertyString("State", false),
                new PropertyString("Zip Code", false),
                new PropertyString("Country", false),
                new PropertyEntity("Medication Entity", "Medication", true),
                new PropertyInt("Medication Entity MG", "Medication", true, "Whole Number/Decimal", "Milligrams"),
                new PropertyDate("Medication Entity Start Date", "Medication", true),
                new PropertyDate("Medication Entity End Date", "Medication", true),
                new PropertyInt("Medication Entity How Long Taken For", "Medication", true, "Whole Number", "Months"),
                new PropertyIsCurrentlyHappening("Medication Entity Is Currently Being Taken", "Medication", true),
                new PropertyString("Medication @ Name", false),
                new PropertyString("Medication @ Type", false),
                new PropertyString("Medication @ Generic Name", false),
                new PropertyInt("Medication @ Morphine Equivalent", false, "Whole Number/Decimal", "Milligrams"),
                new PropertyBoolean("Medication @ Sustained Release", false, new string[] { "True", "False" }),
                new PropertyBoolean("Medication @ Short Acting", false, new string[] { "True", "False" }),
                new PropertyIsCurrentlyHappening("Medication @ Is Currently Being Taken", false),
                new PropertyInt("Morphine Equivalent Dose", true, "Whole Number/Decimal", "Milligrams"),
                new PropertyEntity("Past Medical History Entity", "Past Medical History", true),
                new PropertyString("Past Medical History @ Name", false),
                new PropertyEntity("Pathology Entity", "Pathology", true),
                new PropertyString("Pathology @ Name", false),
                new PropertyEntity("Problem Entity", "Problem", true),
                new PropertyBoolean("Problem Entity Primary", "Problem", true, new string[] { "True", "False" }),
                new PropertyString("Problem @ Name", false),
                new PropertyEntity("Surgery Entity", "Surgery", true),
                new PropertyDate("Surgery Entity Date Received", "Surgery", true),
                new PropertyString("Surgery @ Name", false),
                new PropertyEntity("Trauma Entity", "Trauma", true),
                new PropertyString("Trauma @ Name", false),
                new PropertyEntity("Treatment Entity", "Treatment", true),
                new PropertyDate("Treatment Entity Start Date", "Treatment", true),
                new PropertyDate("Treatment Entity End Date", "Treatment", true),
                new PropertyString("Treatment @ Name", false),
                new PropertyEntity("Protocol Entity", "Protocol", true),
                new PropertyBoolean("Protocol Entity Has Been Completed", "Protocol", true, new string[] {"True", "False" }),
            };
        }

        public string[] getProperties(string filter, bool devMode)
        {
            Property[] temp = getPropertiesFiltered(filter, devMode);
            List<string> names = new List<string>();
            temp.ToList().ForEach(p => names.Add(p.Name));
            return names.ToArray();
        }

        private Property[] getPropertiesFiltered(string filter, bool devMode)
        {
            if (!devMode)
            {
                if (filter == "") return properties.Where(p => p.StandardCommand == true).ToArray();
                else return properties.Where(p => p.StandardCommand == true && p.Name.StartsWith(filter)).ToArray();
            }
            else
            {
                if (filter == "") return properties;
                else return properties.Where(p => p.Name.StartsWith(filter)).ToArray();
            }
        }

        public Property getProperty(string propertyName)
        {
            return properties.FirstOrDefault(p => p.Name == propertyName);
        }
    }
}
