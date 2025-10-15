using Citas.Models;
using Citas.Models.Enum;

namespace Citas.Interfaces;

internal interface IDoctorRepository
{
    void AddDoctor(Doctor doctor);
    Doctor? GetDoctorById(Guid id);
    List<Doctor> GetAllDoctors();
    void RemoveDoctor(Guid id);
    void UpdateDoctor(Doctor doctor);
    void ShowAllDoctors();
    Doctor? GetDoctorByDocument(string documentNumber, DocumentType documentType);


    List<Doctor> GetDoctorsBySpecialty(Speciality speciality);
    List<Doctor> GetAvailableDoctors(DateTime date, TimeSpan time, Speciality speciality);
}