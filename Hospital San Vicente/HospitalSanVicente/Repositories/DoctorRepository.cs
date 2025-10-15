using Citas.Data;
using Citas.Models;
using Citas.Models.Enum;
using Citas.Interfaces;


namespace Citas.Repositories;

internal class DoctorRepository : IDoctorRepository
{
    // 🔹 Agregar un nuevo doctor
    public void AddDoctor(Doctor doctor)
    {
        if (doctor == null)
            throw new ArgumentNullException(nameof(doctor), "El doctor no puede ser nulo.");

        if (DataBase.Doctors.Any(d => d.DocumentNumber == doctor.DocumentNumber && d.DocumentType == doctor.DocumentType))
            throw new InvalidOperationException("Ya existe un doctor con ese número de documento.");
        //no se puede agregar un doctor con tipo de documento TI
        if (doctor.DocumentType == DocumentType.TI)
            throw new InvalidOperationException("No se puede agregar un doctor con tipo de documento TI.");
        DataBase.Doctors.Add(doctor);
        Console.WriteLine("✅ Doctor agregado correctamente.");
    }

    // 🔹 Obtener doctor por ID
    public Doctor? GetDoctorById(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("El ID del doctor no puede estar vacío.", nameof(id));

        return DataBase.Doctors.FirstOrDefault(d => d.Id == id);
    }

    // 🔹 Obtener todos los doctores
    public List<Doctor> GetAllDoctors()
    {
        if (DataBase.Doctors == null || DataBase.Doctors.Count == 0)
            throw new InvalidOperationException("No hay doctores registrados.");

        return DataBase.Doctors;
    }

    // 🔹 Eliminar doctor por ID
    public void RemoveDoctor(Guid id)
    {
        var doctor = DataBase.Doctors.FirstOrDefault(d => d.Id == id);

        if (doctor == null)
            throw new InvalidOperationException("El doctor no existe.");

        DataBase.Doctors.Remove(doctor);
        Console.WriteLine(" Doctor eliminado correctamente.");
    }

    // 🔹 Actualizar información de un doctor existente
    public void UpdateDoctor(Doctor doctor)
    {
        if (doctor == null)
            throw new ArgumentNullException(nameof(doctor), "El doctor no puede ser nulo.");

        var existing = DataBase.Doctors.FirstOrDefault(d => d.Id == doctor.Id);
        if (existing == null)
            throw new InvalidOperationException("El doctor no existe.");

        // Actualiza los campos necesarios
        existing.Name = doctor.Name;
        existing.LastName = doctor.LastName;
        existing.Specialty = doctor.Specialty;
        existing.Phone = doctor.Phone;
        existing.DocumentNumber = doctor.DocumentNumber;
        existing.DocumentType = doctor.DocumentType;

        Console.WriteLine("✅ Doctor actualizado exitosamente.");
    }

    // 🔹 Mostrar todos los doctores
    public void ShowAllDoctors()
    {
        if (DataBase.Doctors.Count == 0)
        {
            Console.WriteLine("⚠️ No hay doctores registrados.");
            return;
        }

        Console.WriteLine("\n👨 Lista de doctores registrados:");
        foreach (var doctor in DataBase.Doctors)
        {
            Console.WriteLine($"🩺 {doctor.Id} {doctor.Name} {doctor.LastName} - Especialidad: {doctor.Specialty} - {doctor.DocumentType}: {doctor.DocumentNumber}");
        }
    }
    // 🔹 Buscar doctor por especialidad
    public List<Doctor> GetDoctorsBySpecialty(Speciality specialty)
    {
        var doctors = DataBase.Doctors
        .Where(d => d.Specialty == specialty)
        .ToList();

        if (doctors.Count == 0)
            throw new InvalidOperationException("No se encontraron doctores con esa especialidad.");

        return doctors;
    }
    public Doctor? GetDoctorByDocument(string documentNumber, DocumentType documentType)
    {
        if (string.IsNullOrWhiteSpace(documentNumber))
            throw new ArgumentException("El número de documento no puede estar vacío.", nameof(documentNumber));

        return DataBase.Doctors.FirstOrDefault(d => d.DocumentNumber == documentNumber && d.DocumentType == documentType);
    }
    public List<Doctor> GetAvailableDoctors(DateTime date, TimeSpan time, Speciality speciality)
    {
        // Obtener todos los doctores con la especialidad dada
        var doctorsWithSpecialty = DataBase.Doctors
            .Where(d => d.Specialty == speciality)
            .ToList();

        // Filtrar los doctores que no tienen citas en la fecha y hora dadas
        var availableDoctors = doctorsWithSpecialty
            .Where(d => !DataBase.Appointments.Any(a => a.Doctor.Id == d.Id && a.Date.Date == date.Date && a.Date.TimeOfDay == time))
            .ToList();

        return availableDoctors;
    }
}

