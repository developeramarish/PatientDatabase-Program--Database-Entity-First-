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
    
    public partial class PatientProblem
    {
        public int Id { get; set; }
        public int PatientID { get; set; }
        public int ProblemID { get; set; }
        public string Primary { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Problem Problem { get; set; }
    }
}
