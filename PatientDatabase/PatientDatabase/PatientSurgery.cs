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
    
    public partial class PatientSurgery
    {
        public int Id { get; set; }
        public int PatientID { get; set; }
        public int SurgeryID { get; set; }
        public System.DateTime Date_Received { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Surgery Surgery { get; set; }
    }
}
