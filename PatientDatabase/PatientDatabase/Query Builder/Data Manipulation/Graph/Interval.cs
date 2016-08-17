using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public class Interval
    {
        public int Number { get; set; }
        public int Length { get; set; }
        public int Months { get; set; }

        public Interval(int number, int length)
        {
            Number = number;
            Length = length;
            Months = Number * Length;
        }

        public string getMonthLabel()
        {
            if (Months == 0) return "Baseline";
            else return Months + " Months";
        }
    }
}
