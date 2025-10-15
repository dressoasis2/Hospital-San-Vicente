using Citas.Models;
using Citas.Models.Enum;

namespace Citas.Interfaces;

internal interface IPatientsRepository
{
    void AddPatient(Patient patient);
    Patient? GetPatientByDocument(string documentNumber, DocumentType documentType);
    List<Patient> GetAllPatients();
    void RemovePatient(Guid id);
    void UpdatePatient(Patient patient);
    void ShowAllPatients();
}
