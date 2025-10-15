
using Citas.Interfaces;
using Citas.Models;
using Citas.Models.Enum;
using Citas.Data;

namespace Citas.Repositories
{
    internal class PatientRepository : IPatientsRepository
    {
        // 🔹 Agregar un paciente
        public void AddPatient(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient), "El paciente no puede ser nulo.");

            if (GetPatientByDocument(patient.DocumentNumber, patient.DocumentType) != null)
                throw new InvalidOperationException("El paciente ya existe.");

            DataBase.Patients.Add(patient);
            Console.WriteLine("✅ Paciente agregado correctamente.");
        }

        // 🔹 Obtener paciente por documento y tipo
        public Patient? GetPatientByDocument(string documentNumber, DocumentType documentType)
        {
            if (string.IsNullOrWhiteSpace(documentNumber))
                throw new ArgumentException("El número de documento no puede estar vacío.", nameof(documentNumber));

            return DataBase.Patients
                .FirstOrDefault(p => p.DocumentNumber == documentNumber && p.DocumentType == documentType);
        }

        // 🔹 Obtener todos los pacientes
        public List<Patient> GetAllPatients()
        {
            if (DataBase.Patients == null || DataBase.Patients.Count == 0)
                throw new InvalidOperationException("No hay pacientes registrados.");

            return DataBase.Patients;
        }

        // 🔹 Eliminar paciente por ID
        public void RemovePatient(Guid id)
        {
            var patient = DataBase.Patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                throw new InvalidOperationException("El paciente no existe.");

            DataBase.Patients.Remove(patient);
            Console.WriteLine("🗑️ Paciente eliminado correctamente.");
        }

        // 🔹 Actualizar paciente existente
        public void UpdatePatient(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));

            var existing = DataBase.Patients.FirstOrDefault(p => p.Id == patient.Id);
            if (existing == null)
                throw new InvalidOperationException("El paciente no existe.");

            // Actualiza los datos del paciente
            existing.Name = patient.Name;
            existing.LastName = patient.LastName;
            existing.Phone = patient.Phone;
            existing.DocumentNumber = patient.DocumentNumber;
            existing.DocumentType = patient.DocumentType;

            Console.WriteLine("✅ Paciente actualizado exitosamente.");
        }

        // 🔹 Mostrar todos los pacientes
        public void ShowAllPatients()
        {
            if (DataBase.Patients.Count == 0)
            {
                Console.WriteLine("⚠️ No hay pacientes registrados.");
                return;
            }

            Console.WriteLine("\n📋 Lista de pacientes registrados:");
            foreach (var patient in DataBase.Patients)
            {
                Console.WriteLine($"🧍 {patient.Id} {patient.Name} {patient.LastName} - {patient.DocumentType}: {patient.DocumentNumber}");
            }
        }
    }
}
