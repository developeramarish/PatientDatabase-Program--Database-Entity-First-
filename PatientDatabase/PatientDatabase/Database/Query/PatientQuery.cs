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
                case "Medication Entity": return checkMedication();
                case "Medication Entity MG": return checkMedicationMG();
                case "Medication Entity Start Date": return checkMedicationStartDate();
                case "Medication Entity End Date": return checkMedicationEndDate();
                case "Medication Entity How Long Taken For": return checkMedicationHowLongTakenFor();
                case "Medication Entity Is Currently Being Taken": return checkMedicationIsCurrentlyBeingTaken();
                case "Medication @ Name": return checkMedicationName();
                case "Medication @ Type": return checkMedicationType();
                case "Medication @ Morphine Equivalent": return checkMedicationMorphineEquivalent();
                case "Medication @ Generic Name": return checkMedicationGenericName();
                case "Medication @ Sustained Release": return checkMedicationSustainedRelease();
                case "Medication @ Short Acting": return checkMedicationShortActing();
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

        #region Medication
        private Expression<Func<Patient, bool>> checkMedication()
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
        #region Medication MG
        private Expression<Func<Patient, bool>> checkMedicationMG()
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
        #region Medication Start Date
        private Expression<Func<Patient, bool>> checkMedicationStartDate()
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
        #region Medication End Date
        private Expression<Func<Patient, bool>> checkMedicationEndDate()
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
        #region Medication How Long Taken For
        private Expression<Func<Patient, bool>> checkMedicationHowLongTakenFor()
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
        #region Medication Is Currently Being Taken
        private Expression<Func<Patient, bool>> checkMedicationIsCurrentlyBeingTaken()
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

        #region DBFunctions
        [DbFunction("PatientDatabaseModel.Store", "getAge")]
        private int? getAge(DateTime bday, DateTime currentDate)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
        #endregion

    }
}