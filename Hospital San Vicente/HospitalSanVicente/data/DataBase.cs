using Citas.Models;
using Citas.Models.Enum;

namespace Citas.Data;

internal static class DataBase
{
    internal static List<Patient> Patients = new List<Patient>();
    internal static List<Doctor> Doctors = new List<Doctor>();
    internal static List<Appointment> Appointments = new List<Appointment>();
}