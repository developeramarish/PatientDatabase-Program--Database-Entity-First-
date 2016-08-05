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
    
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.PatientPathologies = new HashSet<PatientPathology>();
            this.PatientMedications = new HashSet<PatientMedication>();
            this.PatientPast_Medical_History = new HashSet<PatientPast_Medical_History>();
            this.PatientProblems = new HashSet<PatientProblem>();
            this.PatientSurgeries = new HashSet<PatientSurgery>();
            this.PatientTraumas = new HashSet<PatientTrauma>();
            this.PatientTreatments = new HashSet<PatientTreatment>();
        }
    
        public int Id { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Sex { get; set; }
        public System.DateTime Date_of_Birth { get; set; }
        public System.DateTime Date_Entered_Into_System { get; set; }
        public System.DateTime First_Visit { get; set; }
        public System.DateTime Last_Visit { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientPathology> PatientPathologies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientMedication> PatientMedications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientPast_Medical_History> PatientPast_Medical_History { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientProblem> PatientProblems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientSurgery> PatientSurgeries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientTrauma> PatientTraumas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientTreatment> PatientTreatments { get; set; }
    }
}
