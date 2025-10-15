using Citas.Models.Enum;

namespace Citas.Models;

internal class Doctor : Person
{
    internal Speciality Specialty { get; set; }
    internal List<Appointment> Appointments { get; set; }
    internal Doctor(string name,
     string lastName,
     string phone,
     string email,
     string address,
     Gender gender,
        DocumentType documentType,
        string documentNumber,
            Speciality specialty) : base(name,
        lastName,
        phone,
        email,
        address,
        gender,
        documentType,
        documentNumber
    )
    {
        Specialty = specialty;
        Appointments = new List<Appointment>();
    }

    internal void ShowDoctorInfo()
    {
        BasicInfo();
        Console.WriteLine($"🩺 Especialidad:        {Specialty}");
        Console.WriteLine("────────────────────────────────────────────");
        if (Appointments.Count == 0)
        {
            Console.WriteLine("       ❗ EL DOCTOR NO TIENE CITAS ❗");
            Console.WriteLine("────────────────────────────────────────────\n");
        }
        else
        {
            Console.WriteLine("         📅 CITAS DEL DOCTOR");
            Console.WriteLine("────────────────────────────────────────────");
            foreach (var appointment in Appointments)
            {
                appointment.ShowAppointmentInfo();
            }
        }
    }
}