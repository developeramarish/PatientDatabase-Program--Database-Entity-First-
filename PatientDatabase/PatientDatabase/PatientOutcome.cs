//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatientDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientOutcome
    {
        public int Id { get; set; }
        public int PatientID { get; set; }
        public int ProtocolID { get; set; }
        public int OutcomeID { get; set; }
        public string Result { get; set; }
        public System.DateTime Date { get; set; }
        public int Interval_Number { get; set; }
    
        public virtual Outcome Outcome { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Protocol Protocol { get; set; }
    }
}
