using (PatientDatabaseEntities pde = new PatientDatabaseEntities())
{
	// INSERT
	//Patient patient = new Patient
	//{
	//    Last_Name = "Rizzo", First_Name = "Nick", Sex = "Male", Date_of_Birth = "5/6/1993"
	//};

	//pde.Patients.Add(patient);
	//pde.SaveChanges();

	// SELECT
	//Patient patient = pde.Patients.FirstOrDefault(r => r.Last_Name == "Cuomo");
	//MessageBox.Show(patient.Last_Name);

	// UPDATE
	//Patient patient = pde.Patients.FirstOrDefault(r => r.Last_Name == "Cuomo");
	//patient.Last_Name = "Shake";
	//pde.SaveChanges();

	// DELETE
	//Patient patient = pde.Patients.FirstOrDefault(r => r.Last_Name == "Shake");
	//pde.Patients.Remove(patient);
	//pde.SaveChanges();


	// Adding with foreign keys in mind
	// 1. Using ID property
	//Patient patient = pde.Patients.FirstOrDefault(p => p.Last_Name == "Cuomo");
	//Pathology pathology = pde.Pathologies.FirstOrDefault(p => p.Name == "Migraine");
	//pde.PatientPathologies.Add(new PatientPathology { PatientID = patient.Id, PathologyID = pathology.Id });
	//pde.SaveChanges();

	// 2. Using navigation property
	//Patient patient = pde.Patients.FirstOrDefault(p => p.Last_Name == "Cuomo");
	//Pathology pathology = pde.Pathologies.FirstOrDefault(p => p.Name == "Cervical Thorax");
	//pde.PatientPathologies.Add(new PatientPathology { Patient = patient, Pathology = pathology });
	//pde.SaveChanges();

	// 3. Using opposite navigation property
	//Patient patient = pde.Patients.FirstOrDefault(p => p.Last_Name == "Cuomo");
	//Pathology pathology = pde.Pathologies.FirstOrDefault(p => p.Name == "Gay");
	//patient.PatientPathologies.Add(new PatientPathology { Pathology = pathology });
	//pde.SaveChanges();

	// Query Relationships
	//Patient patient = pde.Patients.FirstOrDefault(p => p.Last_Name == "Cuomo");
	//Pathology pathology = pde.Pathologies.FirstOrDefault(p => p.Name == "Gay");
	//List<PatientPathology> patients = patient.PatientPathologies.ToList();
	//patients.ForEach(p => MessageBox.Show(p.Patient.Last_Name + ", " + p.Pathology.Name));

	//List<PatientPathology> pathologies = pathology.PatientPathologies.ToList();
	//pathologies.ForEach(p => MessageBox.Show(p.Patient.Last_Name + ", " + p.Pathology.Name));


	//List<Patient> patientsuh = pde.Patients.Where(p => p.Sex == "Male").OrderBy(p => p.Last_Name).ToList();
	//patientsuh.ForEach(p => MessageBox.Show(p.Last_Name + ", " + p.First_Name));
	
}