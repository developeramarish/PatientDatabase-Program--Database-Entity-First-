using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;

namespace PatientDatabase
{
    public class PatientQuery : Query
    {
        public PatientQuery(string filter, string property, string criteria)
            : base(filter, property, criteria)
        {

        }

        public PatientQuery(string filter, string property, string criteria, bool and, bool or)
            : base(filter, property, criteria, and, or)
        {

        }

        public override Expression<Func<Patient, bool>> runQuery()
        {
            switch (Property)
            {
                case "Last Name": return checkLastName();
                case "First Name": return checkFirstName();
                case "Middle Name": return checkMiddleName();
                case "Sex": return checkSex();
                case "Date of Birth": return checkDateOfBirth();
                case "Age": return checkAge();
                case "Date Entered Into System": return checkDateEnteredIntoSystem();
                case "First Visit": return checkFirstVisit();
                case "Last Visit": return checkLastVisit();
                case "Address": return checkAddress();
                case "City": return checkCity();
                case "State": return checkState();
                case "Zip Code": return checkZipCode();
                case "Country": return checkCountry();
                case "Medication Entity": return checkMedicationEntity();
                case "Medication Entity MG": return checkMedicationEntityMG();
                case "Medication Entity Start Date": return checkMedicationEntityStartDate();
                case "Medication Entity End Date": return checkMedicationEntityEndDate();
                case "Medication Entity How Long Taken For": return checkMedicationEntityHowLongTakenFor();
                case "Medication Entity Is Currently Being Taken": return checkMedicationEntityIsCurrentlyBeingTaken();
                case "Medication @ Name": return checkMedicationName();
                case "Medication @ Type": return checkMedicationType();
                case "Medication @ Morphine Equivalent": return checkMedicationMorphineEquivalent();
                case "Medication @ Generic Name": return checkMedicationGenericName();
                case "Medication @ Sustained Release": return checkMedicationSustainedRelease();
                case "Medication @ Short Acting": return checkMedicationShortActing();
                case "Past Medical History Entity": return checkPastMedicalHistoryEntity();
                case "Past Medical History @ Name": return checkPastMedicalHistoryName();
                case "Pathology Entity": return checkPathologyEntity();
                case "Pathology @ Name": return checkPathologyName();
                case "Problem Entity": return checkProblemEntity();
                case "Problem Entity Primary": return checkProblemEntityPrimary();
                case "Problem @ Name": return checkProblemName();
                case "Surgery Entity": return checkSurgeryEntity();
                case "Surgery Entity Date Received": return checkSurgeryEntityDateReceived();
                case "Surgery @ Name": return checkSurgeryName();
                case "Trauma Entity": return checkTraumaEntity();
                case "Trauma @ Name": return checkTraumaName();
                case "Treatment Entity": return checkTreatmentEntity();
                case "Treatment Entity Start Date": return checkTreatmentEntityStartDate();
                case "Treatment Entity End Date": return checkTreatmentEntityEndDate();
                case "Treatment @ Name": return checkTreatmentName();
                default: return p => false;
            }

        }

        #region Last Name
        private Expression<Func<Patient, bool>> checkLastName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Last_Name == Filter;
                case "Starts With": return p => p.Last_Name.StartsWith(Filter);
                case "Contains": return p => p.Last_Name.Contains(Filter);
                case "Ends With": return p => p.Last_Name.EndsWith(Filter);
                case "Is Equal To NOT": return p => p.Last_Name != Filter;
                case "Starts With NOT": return p => !p.Last_Name.StartsWith(Filter);
                case "Contains NOT": return p => !p.Last_Name.Contains(Filter);
                case "Ends With NOT": return p => !p.Last_Name.EndsWith(Filter);
                default: return p => false;
            }
        }
        #endregion
        #region First Name
        private Expression<Func<Patient, bool>> checkFirstName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.First_Name == Filter;
                case "Starts With": return p => p.First_Name.StartsWith(Filter);
                case "Contains": return p => p.First_Name.Contains(Filter);
                case "Ends With": return p => p.First_Name.EndsWith(Filter);
                case "Is Equal To NOT": return p => p.First_Name != Filter;
                case "Starts With NOT": return p => !p.First_Name.StartsWith(Filter);
                case "Contains NOT": return p => !p.First_Name.Contains(Filter);
                case "Ends With NOT": return p => !p.First_Name.EndsWith(Filter);
                default: return p => false;
            }
        }
        #endregion
        #region Middle Name
        private Expression<Func<Patient, bool>> checkMiddleName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Middle_Name == Filter;
                case "Starts With": return p => p.Middle_Name.StartsWith(Filter);
                case "Contains": return p => p.Middle_Name.Contains(Filter);
                case "Ends With": return p => p.Middle_Name.EndsWith(Filter);
                case "Is Equal To NOT": return p => p.Middle_Name != Filter;
                case "Starts With NOT": return p => !p.Middle_Name.StartsWith(Filter);
                case "Contains NOT": return p => !p.Middle_Name.Contains(Filter);
                case "Ends With NOT": return p => !p.Middle_Name.EndsWith(Filter);
                default: return p => false;
            }
        }
        #endregion
        #region Sex
        private Expression<Func<Patient, bool>> checkSex()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Sex == Filter;
                case "Is Equal To NOT": return p => p.Sex != Filter;
                default: return p => false;
            }
        }
        #endregion
        #region Date Of Birth
        private Expression<Func<Patient, bool>> checkDateOfBirth()
        {
            DateTime date1 = DateTime.Parse(Filter.Substring(0, 10));
            DateTime date2 = date1;
            if (Filter.Length > 10) date2 = DateTime.Parse(Filter.Substring(11, 11));
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Date_of_Birth == date1;
                case "Is Between Inclusive": return p => p.Date_of_Birth >= date1 && p.Date_of_Birth <= date2;
                case "Is Before Or Equal To": return p => p.Date_of_Birth <= date1;
                case "Is After Or Equal To": return p => p.Date_of_Birth >= date1;
                case "Is Between Exclusive": return p => p.Date_of_Birth > date1 && p.Date_of_Birth < date2;
                case "Is Before": return p => p.Date_of_Birth < date1;
                case "Is After": return p => p.Date_of_Birth > date1;
                case "Is Equal To NOT": return p => p.Date_of_Birth != date1;
                case "Is Between Inclusive NOT": return p => p.Date_of_Birth < date1 && p.Date_of_Birth > date2;
                case "Is Before Or Equal To NOT": return p => p.Date_of_Birth > date1;
                case "Is After Or Equal To NOT": return p => p.Date_of_Birth < date1;
                case "Is Between Exclusive NOT": return p => p.Date_of_Birth <= date1 && p.Date_of_Birth >= date2;
                case "Is Before NOT": return p => p.Date_of_Birth <= date1;
                case "Is After NOT": return p => p.Date_of_Birth >= date1;
                default: return p => false;
            }
        }
        #endregion
        #region Age
        private Expression<Func<Patient, bool>> checkAge()
        {
            string[] ages = Filter.Split(' ');
            int age1 = Int32.Parse(ages[0]);
            int age2 = age1;
            if (ages.Length > 1) { age1 = Int32.Parse(ages[0]); age2 = Int32.Parse(ages[1]); }
            switch (Criteria)
            {
                case "Is Equal To": return p => getAge(p.Date_of_Birth, DateTime.Now) == age1;
                case "Is Between Inclusive": return p => getAge(p.Date_of_Birth, DateTime.Now) >= age1 && getAge(p.Date_of_Birth, DateTime.Now) <= age2;
                case "Is Greater Than Or Equal To": return p => getAge(p.Date_of_Birth, DateTime.Now) >= age1;
                case "Is Less Than Or Equal To": return p => getAge(p.Date_of_Birth, DateTime.Now) <= age1;
                case "Is Between Exclusive": return p => getAge(p.Date_of_Birth, DateTime.Now) > age1 && getAge(p.Date_of_Birth, DateTime.Now) < age2;
                case "Is Greater Than": return p => getAge(p.Date_of_Birth, DateTime.Now) > age1;
                case "Is Less Than": return p => getAge(p.Date_of_Birth, DateTime.Now) < age1;
                case "Is Equal To NOT": return p => getAge(p.Date_of_Birth, DateTime.Now) != age1;
                case "Is Between Inclusive NOT": return p => getAge(p.Date_of_Birth, DateTime.Now) < age1 && getAge(p.Date_of_Birth, DateTime.Now) > age2;
                case "Is Greater Than Or Equal To NOT": return p => getAge(p.Date_of_Birth, DateTime.Now) < age1;
                case "Is Less Than Or Equal To NOT": return p => getAge(p.Date_of_Birth, DateTime.Now) > age1;
                case "Is Between Exclusive NOT": return p => getAge(p.Date_of_Birth, DateTime.Now) <= age1 && getAge(p.Date_of_Birth, DateTime.Now) >= age2;
                case "Is Greater Than NOT": return p => getAge(p.Date_of_Birth, DateTime.Now) <= age1;
                case "Is Less Than NOT": return p => getAge(p.Date_of_Birth, DateTime.Now) >= age1;
                default: return p => false;
            }
        }
        #endregion
        #region Date Entered Into System
        private Expression<Func<Patient, bool>> checkDateEnteredIntoSystem()
        {
            DateTime date1 = DateTime.Parse(Filter.Substring(0, 10));
            DateTime date2 = date1;
            if (Filter.Length > 10) date2 = DateTime.Parse(Filter.Substring(11, 11));
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Date_Entered_Into_System == date1;
                case "Is Between Inclusive": return p => p.Date_Entered_Into_System >= date1 && p.Date_Entered_Into_System <= date2;
                case "Is Before Or Equal To": return p => p.Date_Entered_Into_System <= date1;
                case "Is After Or Equal To": return p => p.Date_Entered_Into_System >= date1;
                case "Is Between Exclusive": return p => p.Date_Entered_Into_System > date1 && p.Date_Entered_Into_System < date2;
                case "Is Before": return p => p.Date_Entered_Into_System < date1;
                case "Is After": return p => p.Date_Entered_Into_System > date1;
                case "Is Equal To NOT": return p => p.Date_Entered_Into_System != date1;
                case "Is Between Inclusive NOT": return p => p.Date_Entered_Into_System < date1 && p.Date_Entered_Into_System > date2;
                case "Is Before Or Equal To NOT": return p => p.Date_Entered_Into_System > date1;
                case "Is After Or Equal To NOT": return p => p.Date_Entered_Into_System < date1;
                case "Is Between Exclusive NOT": return p => p.Date_Entered_Into_System <= date1 && p.Date_Entered_Into_System >= date2;
                case "Is Before NOT": return p => p.Date_Entered_Into_System <= date1;
                case "Is After NOT": return p => p.Date_Entered_Into_System >= date1;
                default: return p => false;
            }
        }
        #endregion
        #region First Visit
        private Expression<Func<Patient, bool>> checkFirstVisit()
        {
            DateTime date1 = DateTime.Parse(Filter.Substring(0, 10));
            DateTime date2 = date1;
            if (Filter.Length > 10) date2 = DateTime.Parse(Filter.Substring(11, 11));
            switch (Criteria)
            {
                case "Is Equal To": return p => p.First_Visit == date1;
                case "Is Between Inclusive": return p => p.First_Visit >= date1 && p.First_Visit <= date2;
                case "Is Before Or Equal To": return p => p.First_Visit <= date1;
                case "Is After Or Equal To": return p => p.First_Visit >= date1;
                case "Is Between Exclusive": return p => p.First_Visit > date1 && p.First_Visit < date2;
                case "Is Before": return p => p.First_Visit < date1;
                case "Is After": return p => p.First_Visit > date1;
                case "Is Equal To NOT": return p => p.First_Visit != date1;
                case "Is Between Inclusive NOT": return p => p.First_Visit < date1 && p.First_Visit > date2;
                case "Is Before Or Equal To NOT": return p => p.First_Visit > date1;
                case "Is After Or Equal To NOT": return p => p.First_Visit < date1;
                case "Is Between Exclusive NOT": return p => p.First_Visit <= date1 && p.First_Visit >= date2;
                case "Is Before NOT": return p => p.First_Visit <= date1;
                case "Is After NOT": return p => p.First_Visit >= date1;
                default: return p => false;
            }
        }
        #endregion
        #region Last Visit
        private Expression<Func<Patient, bool>> checkLastVisit()
        {
            DateTime date1 = DateTime.Parse(Filter.Substring(0, 10));
            DateTime date2 = date1;
            if (Filter.Length > 10) date2 = DateTime.Parse(Filter.Substring(11, 11));
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Last_Visit == date1;
                case "Is Between Inclusive": return p => p.Last_Visit >= date1 && p.Last_Visit <= date2;
                case "Is Before Or Equal To": return p => p.Last_Visit <= date1;
                case "Is After Or Equal To": return p => p.Last_Visit >= date1;
                case "Is Between Exclusive": return p => p.Last_Visit > date1 && p.Last_Visit < date2;
                case "Is Before": return p => p.Last_Visit < date1;
                case "Is After": return p => p.Last_Visit > date1;
                case "Is Equal To NOT": return p => p.Last_Visit != date1;
                case "Is Between Inclusive NOT": return p => p.Last_Visit < date1 && p.Last_Visit > date2;
                case "Is Before Or Equal To NOT": return p => p.Last_Visit > date1;
                case "Is After Or Equal To NOT": return p => p.Last_Visit < date1;
                case "Is Between Exclusive NOT": return p => p.Last_Visit <= date1 && p.Last_Visit >= date2;
                case "Is Before NOT": return p => p.Last_Visit <= date1;
                case "Is After NOT": return p => p.Last_Visit >= date1;
                default: return p => false;
            }
        }
        #endregion
        #region Address
        private Expression<Func<Patient, bool>> checkAddress()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Address == Filter;
                case "Starts With": return p => p.Address.StartsWith(Filter);
                case "Contains": return p => p.Address.Contains(Filter);
                case "Ends With": return p => p.Address.EndsWith(Filter);
                case "Is Equal To NOT": return p => p.Address != Filter;
                case "Starts With NOT": return p => !p.Address.StartsWith(Filter);
                case "Contains NOT": return p => !p.Address.Contains(Filter);
                case "Ends With NOT": return p => !p.Address.EndsWith(Filter);
                default: return p => false;
            }
        }
        #endregion
        #region City
        private Expression<Func<Patient, bool>> checkCity()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.City == Filter;
                case "Starts With": return p => p.City.StartsWith(Filter);
                case "Contains": return p => p.City.Contains(Filter);
                case "Ends With": return p => p.City.EndsWith(Filter);
                case "Is Equal To NOT": return p => p.City != Filter;
                case "Starts With NOT": return p => !p.City.StartsWith(Filter);
                case "Contains NOT": return p => !p.City.Contains(Filter);
                case "Ends With NOT": return p => !p.City.EndsWith(Filter);
                default: return p => false;
            }
        }
        #endregion
        #region State
        private Expression<Func<Patient, bool>> checkState()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.State == Filter;
                case "Starts With": return p => p.State.StartsWith(Filter);
                case "Contains": return p => p.State.Contains(Filter);
                case "Ends With": return p => p.State.EndsWith(Filter);
                case "Is Equal To NOT": return p => p.State != Filter;
                case "Starts With NOT": return p => !p.State.StartsWith(Filter);
                case "Contains NOT": return p => !p.State.Contains(Filter);
                case "Ends With NOT": return p => !p.State.EndsWith(Filter);
                default: return p => false;
            }
        }
        #endregion
        #region Zip Code
        private Expression<Func<Patient, bool>> checkZipCode()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Zip_Code == Filter;
                case "Starts With": return p => p.Zip_Code.StartsWith(Filter);
                case "Contains": return p => p.Zip_Code.Contains(Filter);
                case "Ends With": return p => p.Zip_Code.EndsWith(Filter);
                case "Is Equal To NOT": return p => p.Zip_Code != Filter;
                case "Starts With NOT": return p => !p.Zip_Code.StartsWith(Filter);
                case "Contains NOT": return p => !p.Zip_Code.Contains(Filter);
                case "Ends With NOT": return p => !p.Zip_Code.EndsWith(Filter);
                default: return p => false;
            }
        }
        #endregion
        #region Country
        private Expression<Func<Patient, bool>> checkCountry()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.Country == Filter;
                case "Starts With": return p => p.Country.StartsWith(Filter);
                case "Contains": return p => p.Country.Contains(Filter);
                case "Ends With": return p => p.Country.EndsWith(Filter);
                case "Is Equal To NOT": return p => p.Country != Filter;
                case "Starts With NOT": return p => !p.Country.StartsWith(Filter);
                case "Contains NOT": return p => !p.Country.Contains(Filter);
                case "Ends With NOT": return p => !p.Country.EndsWith(Filter);
                default: return p => false;
            }
        }
        #endregion

        #region Medication Entity
        private Expression<Func<Patient, bool>> checkMedicationEntity()
        {
            string[] id = Filter.Split(':');
            int medId = Int32.Parse(id[0]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(m => m.MedicationID == medId);
                case "Is Equal To NOT": return p => p.PatientMedications.Any(m => m.MedicationID != medId);
                default: return p => false;
            }
        }
        #endregion
        #region Medication Entity MG
        private Expression<Func<Patient, bool>> checkMedicationEntityMG()
        {
            string[] values = Filter.Split(' ');
            string[] id = values[0].Split(':');
            int medId = Int32.Parse(id[0]);
            int value1 = Int32.Parse(values[1]);
            int value2 = value1;
            if (values.Length > 2) { value1 = Int32.Parse(values[1]); value2 = Int32.Parse(values[2]); }
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg == value1);
                case "Is Between Inclusive": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg >= value1 && pm.Mg <= value2);
                case "Is Greater Than Or Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg >= value1);
                case "Is Less Than Or Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg <= value1);
                case "Is Between Exclusive": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg > value1 && pm.Mg < value2);
                case "Is Greater Than": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg > value1);
                case "Is Less Than": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg < value1);
                case "Is Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg != value1);
                case "Is Between Inclusive NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg < value1 && pm.Mg > value2);
                case "Is Greater Than Or Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg < value1);
                case "Is Less Than Or Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg > value1);
                case "Is Between Exclusive NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg <= value1 && pm.Mg >= value2);
                case "Is Greater Than NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg <= value1);
                case "Is Less Than NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Mg >= value1);
                default: return p => false;
            }
        }
        #endregion
        #region Medication Entity Start Date
        private Expression<Func<Patient, bool>> checkMedicationEntityStartDate()
        {
            string[] values = Filter.Split(' ');
            string[] id = values[0].Split(':');
            int medId = Int32.Parse(id[0]);
            DateTime date1 = DateTime.Parse(values[1]);
            DateTime date2 = date1;
            if (values.Length > 2) date2 = DateTime.Parse(values[2]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date == date1);
                case "Is Between Inclusive": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date >= date1 && pm.Start_Date <= date2);
                case "Is Before Or Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date <= date1);
                case "Is After Or Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date >= date1);
                case "Is Between Exclusive": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date > date1 && pm.Start_Date < date2);
                case "Is Before": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date < date1);
                case "Is After": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date > date1);
                case "Is Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date != date1);
                case "Is Between Inclusive NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date < date1 && pm.Start_Date > date2);
                case "Is Before Or Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date > date1);
                case "Is After Or Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date < date1);
                case "Is Between Exclusive NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date <= date1 && pm.Start_Date >= date2);
                case "Is Before NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date >= date1);
                case "Is After NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.Start_Date <= date1);
                default: return p => false;
            }
        }
        #endregion
        #region Medication Entity End Date
        private Expression<Func<Patient, bool>> checkMedicationEntityEndDate()
        {
            string[] values = Filter.Split(' ');
            string[] id = values[0].Split(':');
            int medId = Int32.Parse(id[0]);
            DateTime date1 = DateTime.Parse(values[1]);
            DateTime date2 = date1;
            if (values.Length > 2) date2 = DateTime.Parse(values[2]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date == date1);
                case "Is Between Inclusive": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date >= date1 && pm.End_Date <= date2);
                case "Is Before Or Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date <= date1);
                case "Is After Or Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date >= date1);
                case "Is Between Exclusive": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date > date1 && pm.End_Date < date2);
                case "Is Before": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date < date1);
                case "Is After": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date > date1);
                case "Is Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date != date1);
                case "Is Between Inclusive NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date < date1 && pm.End_Date > date2);
                case "Is Before Or Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date > date1);
                case "Is After Or Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date < date1);
                case "Is Between Exclusive NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date <= date1 && pm.End_Date >= date2);
                case "Is Before NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date >= date1);
                case "Is After NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date <= date1);
                default: return p => false;
            }
        }
        #endregion
        #region Medication Entity How Long Taken For
        private Expression<Func<Patient, bool>> checkMedicationEntityHowLongTakenFor()
        {
            string[] values = Filter.Split(' ');
            string[] id = values[0].Split(':');
            int medId = Int32.Parse(id[0]);
            int value1 = Int32.Parse(values[1]); ;
            int value2 = value1;
            if (values.Length > 2) { value1 = Int32.Parse(values[1]); value2 = Int32.Parse(values[2]); }
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) == value1);
                case "Is Between Inclusive": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) >= value1 && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) <= value2);
                case "Is Greater Than Or Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) >= value1);
                case "Is Less Than Or Equal To": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) <= value1);
                case "Is Between Exclusive": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) > value1 && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) < value2);
                case "Is Greater Than": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) > value1);
                case "Is Less Than": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) < value1);
                case "Is Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) != value1);
                case "Is Between Inclusive NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) < value1 && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) > value2);
                case "Is Greater Than Or Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) < value1);
                case "Is Less Than Or Equal To NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) > value1);
                case "Is Between Exclusive NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) <= value1 && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) >= value2);
                case "Is Greater Than NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) <= value1);
                case "Is Less Than NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && SqlFunctions.DateDiff("MONTH", pm.Start_Date, pm.End_Date) >= value1);
                default: return p => false;
            }
        }
        #endregion
        #region Medication Entity Is Currently Being Taken
        private Expression<Func<Patient, bool>> checkMedicationEntityIsCurrentlyBeingTaken()
        {
            string[] id = Filter.Split(':');
            int medId = Int32.Parse(id[0]);
            string endDate = "12/31/9999";
            DateTime neverEndingDate = DateTime.Parse(endDate);
            switch (Criteria)
            {
                case "Is Current": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date == neverEndingDate);
                case "Is Current NOT": return p => p.PatientMedications.Any(pm => pm.MedicationID == medId && pm.End_Date != neverEndingDate);
                default: return p => false;
            }
        }

        #endregion
        #region Medication Name
        private Expression<Func<Patient, bool>> checkMedicationName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(m => m.Medication.Name == Filter);
                case "Starts With": return p => p.PatientMedications.Any(m => m.Medication.Name.StartsWith(Filter));
                case "Contains": return p => p.PatientMedications.Any(m => m.Medication.Name.Contains(Filter));
                case "Ends With": return p => p.PatientMedications.Any(m => m.Medication.Name.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientMedications.Any(m => m.Medication.Name != Filter);
                case "Starts With NOT": return p => p.PatientMedications.Any(m => !m.Medication.Name.StartsWith(Filter)); 
                case "Contains NOT": return p => p.PatientMedications.Any(m => !m.Medication.Name.Contains(Filter));
                case "Ends With NOT": return p => p.PatientMedications.Any(m => !m.Medication.Name.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion
        #region Medication Type
        private Expression<Func<Patient, bool>> checkMedicationType()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(m => m.Medication.Type == Filter);
                case "Starts With": return p => p.PatientMedications.Any(m => m.Medication.Type.StartsWith(Filter));
                case "Contains": return p => p.PatientMedications.Any(m => m.Medication.Type.Contains(Filter));
                case "Ends With": return p => p.PatientMedications.Any(m => m.Medication.Type.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientMedications.Any(m => m.Medication.Type != Filter);
                case "Starts With NOT": return p => p.PatientMedications.Any(m => !m.Medication.Type.StartsWith(Filter));
                case "Contains NOT": return p => p.PatientMedications.Any(m => !m.Medication.Type.Contains(Filter));
                case "Ends With NOT": return p => p.PatientMedications.Any(m => !m.Medication.Type.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion
        #region Medication Morphine Equivalent
        private Expression<Func<Patient, bool>> checkMedicationMorphineEquivalent()
        {
            string[] values = Filter.Split(' ');
            int value1 = Int32.Parse(values[0]);
            int value2 = value1;
            if (values.Length > 2) { value1 = Int32.Parse(values[0]); value2 = Int32.Parse(values[1]); }
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ == value1);
                case "Is Between Inclusive": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ >= value1) && p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ <= value2);
                case "Is Greater Than Or Equal To": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ >= value1);
                case "Is Less Than Or Equal To": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ <= value1);
                case "Is Between Exclusive": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ > value1) && p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ < value2);
                case "Is Greater Than": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ > value1);
                case "Is Less Than": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ < value1);
                case "Is Equal To NOT": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ != value1);
                case "Is Between Inclusive NOT": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ < value1) && p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ > value2);
                case "Is Greater Than Or Equal To NOT": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ < value1);
                case "Is Less Than Or Equal To NOT": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ > value1);
                case "Is Between Exclusive NOT": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ <= value1) && p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ >= value2);
                case "Is Greater Than NOT": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ <= value1);
                case "Is Less Than NOT": return p => p.PatientMedications.Any(m => m.Medication.Morphine_Equivalent__mg_ >= value1);
                default: return p => false;
            }
        }
        #endregion
        #region Medication Generic Name
        private Expression<Func<Patient, bool>> checkMedicationGenericName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(m => m.Medication.Generic_Name == Filter);
                case "Starts With": return p => p.PatientMedications.Any(m => m.Medication.Generic_Name.StartsWith(Filter));
                case "Contains": return p => p.PatientMedications.Any(m => m.Medication.Generic_Name.Contains(Filter));
                case "Ends With": return p => p.PatientMedications.Any(m => m.Medication.Generic_Name.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientMedications.Any(m => m.Medication.Generic_Name != Filter);
                case "Starts With NOT": return p => p.PatientMedications.Any(m => !m.Medication.Generic_Name.StartsWith(Filter));
                case "Contains NOT": return p => p.PatientMedications.Any(m => !m.Medication.Generic_Name.Contains(Filter));
                case "Ends With NOT": return p => p.PatientMedications.Any(m => !m.Medication.Generic_Name.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion
        #region Medication Sustained Release
        private Expression<Func<Patient, bool>> checkMedicationSustainedRelease()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(m => m.Medication.Sustained_Release == Filter);
                case "Is Equal To NOT": return p => p.PatientMedications.Any(m => m.Medication.Sustained_Release != Filter);
                default: return p => false;
            }

        }
        #endregion
        #region Medication Short Acting
        private Expression<Func<Patient, bool>> checkMedicationShortActing()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientMedications.Any(m => m.Medication.Short_Acting == Filter);
                case "Is Equal To NOT": return p => p.PatientMedications.Any(m => m.Medication.Short_Acting != Filter);
                default: return p => false;
            }

        }
        #endregion

        #region Past Medical History Entity
        private Expression<Func<Patient, bool>> checkPastMedicalHistoryEntity()
        {
            string[] id = Filter.Split(':');
            int pmhId = Int32.Parse(id[0]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientPast_Medical_History.Any(pmh => pmh.Past_Medical_HistoryID == pmhId);
                case "Is Equal To NOT": return p => p.PatientPast_Medical_History.Any(pmh => pmh.Past_Medical_HistoryID != pmhId);
                default: return p => false;
            }
        }
        #endregion
        #region Past Medical History Name
        private Expression<Func<Patient, bool>> checkPastMedicalHistoryName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientPast_Medical_History.Any(pmh => pmh.Past_Medical_History.Name == Filter);
                case "Starts With": return p => p.PatientPast_Medical_History.Any(pmh => pmh.Past_Medical_History.Name.StartsWith(Filter));
                case "Contains": return p => p.PatientPast_Medical_History.Any(pmh => pmh.Past_Medical_History.Name.Contains(Filter));
                case "Ends With": return p => p.PatientPast_Medical_History.Any(pmh => pmh.Past_Medical_History.Name.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientPast_Medical_History.Any(pmh => pmh.Past_Medical_History.Name != Filter);
                case "Starts With NOT": return p => p.PatientPast_Medical_History.Any(pmh => !pmh.Past_Medical_History.Name.StartsWith(Filter));
                case "Contains NOT": return p => p.PatientPast_Medical_History.Any(pmh => !pmh.Past_Medical_History.Name.Contains(Filter));
                case "Ends With NOT": return p => p.PatientPast_Medical_History.Any(pmh => !pmh.Past_Medical_History.Name.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion

        #region Pathology Entity
        private Expression<Func<Patient, bool>> checkPathologyEntity()
        {
            string[] id = Filter.Split(':');
            int patId = Int32.Parse(id[0]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientPathologies.Any(pat => pat.PathologyID == patId);
                case "Is Equal To NOT": return p => p.PatientPathologies.Any(pat => pat.PathologyID != patId);
                default: return p => false;
            }
        }
        #endregion
        #region Pathology Name
        private Expression<Func<Patient, bool>> checkPathologyName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientPathologies.Any(pat => pat.Pathology.Name == Filter);
                case "Starts With": return p => p.PatientPathologies.Any(pat => pat.Pathology.Name.StartsWith(Filter));
                case "Contains": return p => p.PatientPathologies.Any(pat => pat.Pathology.Name.Contains(Filter));
                case "Ends With": return p => p.PatientPathologies.Any(pat => pat.Pathology.Name.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientPathologies.Any(pat => pat.Pathology.Name != Filter);
                case "Starts With NOT": return p => p.PatientPathologies.Any(pat => !pat.Pathology.Name.StartsWith(Filter));
                case "Contains NOT": return p => p.PatientPathologies.Any(pat => !pat.Pathology.Name.Contains(Filter));
                case "Ends With NOT": return p => p.PatientPathologies.Any(pat => !pat.Pathology.Name.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion

        #region Problem Entity
        private Expression<Func<Patient, bool>> checkProblemEntity()
        {
            string[] id = Filter.Split(':');
            int probId = Int32.Parse(id[0]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientProblems.Any(prob => prob.ProblemID == probId);
                case "Is Equal To NOT": return p => p.PatientProblems.Any(prob => prob.ProblemID != probId);
                default: return p => false;
            }
        }
        #endregion
        #region Problem Entity Primary
        private Expression<Func<Patient, bool>> checkProblemEntityPrimary()
        {
            string[] id = Filter.Split(':');
            int probId = Int32.Parse(id[0]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientProblems.Any(prob => prob.ProblemID == probId && prob.Primary == Filter);
                case "Is Equal To NOT": return p => p.PatientProblems.Any(prob => prob.ProblemID == probId && prob.Primary != Filter);
                default: return p => false;
            }
        }
        #endregion
        #region Problem Name
        private Expression<Func<Patient, bool>> checkProblemName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientProblems.Any(prob => prob.Problem.Name == Filter);
                case "Starts With": return p => p.PatientProblems.Any(prob => prob.Problem.Name.StartsWith(Filter));
                case "Contains": return p => p.PatientProblems.Any(prob => prob.Problem.Name.Contains(Filter));
                case "Ends With": return p => p.PatientProblems.Any(prob => prob.Problem.Name.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientProblems.Any(prob => prob.Problem.Name != Filter);
                case "Starts With NOT": return p => p.PatientProblems.Any(prob => !prob.Problem.Name.StartsWith(Filter));
                case "Contains NOT": return p => p.PatientProblems.Any(prob => !prob.Problem.Name.Contains(Filter));
                case "Ends With NOT": return p => p.PatientProblems.Any(prob => !prob.Problem.Name.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion

        #region Surgery Entity
        private Expression<Func<Patient, bool>> checkSurgeryEntity()
        {
            string[] id = Filter.Split(':');
            int surId = Int32.Parse(id[0]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId);
                case "Is Equal To NOT": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID != surId);
                default: return p => false;
            }
        }
        #endregion
        #region Surgery Entity Date Received
        private Expression<Func<Patient, bool>> checkSurgeryEntityDateReceived()
        {
            string[] values = Filter.Split(' ');
            string[] id = values[0].Split(':');
            int surId = Int32.Parse(id[0]);
            DateTime date1 = DateTime.Parse(values[1]);
            DateTime date2 = date1;
            if (values.Length > 2) date2 = DateTime.Parse(values[2]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received == date1);
                case "Is Between Inclusive": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received >= date1 && sur.Date_Received <= date2);
                case "Is Before Or Equal To": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received <= date1);
                case "Is After Or Equal To": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received >= date1);
                case "Is Between Exclusive": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received > date1 && sur.Date_Received < date2);
                case "Is Before": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received < date1);
                case "Is After": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received > date1);
                case "Is Equal To NOT": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received != date1);
                case "Is Between Inclusive NOT": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received < date1 && sur.Date_Received > date2);
                case "Is Before Or Equal To NOT": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received > date1);
                case "Is After Or Equal To NOT": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received < date1);
                case "Is Between Exclusive NOT": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received <= date1 && sur.Date_Received >= date2);
                case "Is Before NOT": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received >= date1);
                case "Is After NOT": return p => p.PatientSurgeries.Any(sur => sur.SurgeryID == surId && sur.Date_Received <= date1);
                default: return p => false;
            }
        }
        #endregion
        #region Surgery Name
        private Expression<Func<Patient, bool>> checkSurgeryName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientSurgeries.Any(sur => sur.Surgery.Name == Filter);
                case "Starts With": return p => p.PatientSurgeries.Any(sur => sur.Surgery.Name.StartsWith(Filter));
                case "Contains": return p => p.PatientSurgeries.Any(sur => sur.Surgery.Name.Contains(Filter));
                case "Ends With": return p => p.PatientSurgeries.Any(sur => sur.Surgery.Name.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientSurgeries.Any(sur => sur.Surgery.Name != Filter);
                case "Starts With NOT": return p => p.PatientSurgeries.Any(sur => !sur.Surgery.Name.StartsWith(Filter));
                case "Contains NOT": return p => p.PatientSurgeries.Any(sur => !sur.Surgery.Name.Contains(Filter));
                case "Ends With NOT": return p => p.PatientSurgeries.Any(sur => !sur.Surgery.Name.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion

        #region Trauma Entity
        private Expression<Func<Patient, bool>> checkTraumaEntity()
        {
            string[] id = Filter.Split(':');
            int traId = Int32.Parse(id[0]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientTraumas.Any(tra => tra.TraumaID == traId);
                case "Is Equal To NOT": return p => p.PatientTraumas.Any(tra => tra.TraumaID != traId);
                default: return p => false;
            }
        }
        #endregion
        #region Trauma Name
        private Expression<Func<Patient, bool>> checkTraumaName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientTraumas.Any(tra => tra.Trauma.Name == Filter);
                case "Starts With": return p => p.PatientTraumas.Any(tra => tra.Trauma.Name.StartsWith(Filter));
                case "Contains": return p => p.PatientTraumas.Any(tra => tra.Trauma.Name.Contains(Filter));
                case "Ends With": return p => p.PatientTraumas.Any(tra => tra.Trauma.Name.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientTraumas.Any(tra => tra.Trauma.Name != Filter);
                case "Starts With NOT": return p => p.PatientTraumas.Any(tra => !tra.Trauma.Name.StartsWith(Filter));
                case "Contains NOT": return p => p.PatientTraumas.Any(tra => !tra.Trauma.Name.Contains(Filter));
                case "Ends With NOT": return p => p.PatientTraumas.Any(tra => !tra.Trauma.Name.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion

        #region Treatment Entity
        private Expression<Func<Patient, bool>> checkTreatmentEntity()
        {
            string[] id = Filter.Split(':');
            int treId = Int32.Parse(id[0]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientTreatments.Any(tra => tra.TreatmentID == treId);
                case "Is Equal To NOT": return p => p.PatientTreatments.Any(tra => tra.TreatmentID != treId);
                default: return p => false;
            }
        }
        #endregion
        #region Treatment Entity Start Date
        private Expression<Func<Patient, bool>> checkTreatmentEntityStartDate()
        {
            string[] values = Filter.Split(' ');
            string[] id = values[0].Split(':');
            int treId = Int32.Parse(id[0]);
            DateTime date1 = DateTime.Parse(values[1]);
            DateTime date2 = date1;
            if (values.Length > 2) date2 = DateTime.Parse(values[2]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started == date1);
                case "Is Between Inclusive": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started >= date1 && tre.Date_Started <= date2);
                case "Is Before Or Equal To": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started <= date1);
                case "Is After Or Equal To": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started >= date1);
                case "Is Between Exclusive": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started > date1 && tre.Date_Started < date2);
                case "Is Before": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started < date1);
                case "Is After": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started > date1);
                case "Is Equal To NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started != date1);
                case "Is Between Inclusive NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started < date1 && tre.Date_Started > date2);
                case "Is Before Or Equal To NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started > date1);
                case "Is After Or Equal To NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started < date1);
                case "Is Between Exclusive NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started <= date1 && tre.Date_Started >= date2);
                case "Is Before NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started >= date1);
                case "Is After NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Started <= date1);
                default: return p => false;
            }
        }
        #endregion
        #region Treatment Entity End Date
        private Expression<Func<Patient, bool>> checkTreatmentEntityEndDate()
        {
            string[] values = Filter.Split(' ');
            string[] id = values[0].Split(':');
            int treId = Int32.Parse(id[0]);
            DateTime date1 = DateTime.Parse(values[1]);
            DateTime date2 = date1;
            if (values.Length > 2) date2 = DateTime.Parse(values[2]);
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended == date1);
                case "Is Between Inclusive": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended >= date1 && tre.Date_Ended <= date2);
                case "Is Before Or Equal To": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended <= date1);
                case "Is After Or Equal To": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended >= date1);
                case "Is Between Exclusive": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended > date1 && tre.Date_Ended < date2);
                case "Is Before": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended < date1);
                case "Is After": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended > date1);
                case "Is Equal To NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended != date1);
                case "Is Between Inclusive NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended < date1 && tre.Date_Ended > date2);
                case "Is Before Or Equal To NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended > date1);
                case "Is After Or Equal To NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended < date1);
                case "Is Between Exclusive NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended <= date1 && tre.Date_Ended >= date2);
                case "Is Before NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended >= date1);
                case "Is After NOT": return p => p.PatientTreatments.Any(tre => tre.TreatmentID == treId && tre.Date_Ended <= date1);
                default: return p => false;
            }
        }
        #endregion
        #region Treatment Name
        private Expression<Func<Patient, bool>> checkTreatmentName()
        {
            switch (Criteria)
            {
                case "Is Equal To": return p => p.PatientTreatments.Any(tre => tre.Treatment.Name == Filter);
                case "Starts With": return p => p.PatientTreatments.Any(tre => tre.Treatment.Name.StartsWith(Filter));
                case "Contains": return p => p.PatientTreatments.Any(tre => tre.Treatment.Name.Contains(Filter));
                case "Ends With": return p => p.PatientTreatments.Any(tre => tre.Treatment.Name.EndsWith(Filter));
                case "Is Equal To NOT": return p => p.PatientTreatments.Any(tre => tre.Treatment.Name != Filter);
                case "Starts With NOT": return p => p.PatientTreatments.Any(tre => !tre.Treatment.Name.StartsWith(Filter));
                case "Contains NOT": return p => p.PatientTreatments.Any(tre => !tre.Treatment.Name.Contains(Filter));
                case "Ends With NOT": return p => p.PatientTreatments.Any(tre => !tre.Treatment.Name.EndsWith(Filter));
                default: return p => false;
            }
        }
        #endregion

        #region DBFunctions
        [DbFunction("PatientDatabaseModel.Store", "getAge")]
        private int? getAge(DateTime bday, DateTime currentDate)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
        #endregion

    }
}