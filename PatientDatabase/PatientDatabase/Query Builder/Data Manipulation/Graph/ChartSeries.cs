using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public abstract class ChartSeries
    {
        public bool Show { get; set; }
        protected QueryEntity entity;
        protected Patient patient;
        protected DatabaseAccess database;

        public ChartSeries(QueryEntity entity, bool show)
        {
            this.entity = entity;
            Show = show;
            database = new DatabaseAccess();
        }

        public ChartSeries(Patient patient)
        {
            this.patient = patient;
            database = new DatabaseAccess();
        }

        public abstract string getName();
        public abstract List<Patient> getPatients();
        public abstract Dictionary<int, int> getPoints(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval);

        public virtual string getDataAnalysis(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval) { return ""; }
        public virtual string getSeriesCount(Protocol selectedProtocol, Outcome selectedOutcome, Interval startInterval, Interval endInterval) { return ""; }

        public void toggleShow()
        {
            if (Show) Show = false;
            else Show = true;
        }
    }
}
