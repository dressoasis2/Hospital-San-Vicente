using Citas.Models.Enum;
namespace Citas.Models
{
    internal class Appointment
    {
        internal Guid Id { get; } = Guid.NewGuid();
        internal DateTime Date { get; set; }
        internal TimeSpan Time { get; set; }
        internal Doctor Doctor { get; set; }
        internal Patient Patient { get; set; }
        internal string Reason { get; set; }
        internal AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

        internal Appointment(DateTime date, TimeSpan time, Doctor doctor, Patient patient, string reason, AppointmentStatus status = AppointmentStatus.Scheduled)
        {
            Date = date;
            Time = time;
            Doctor = doctor;
            Patient = patient;
            Reason = reason;
            Status = status;
        }

        internal void ShowAppointmentInfo()
        {
            Console.WriteLine("────────────────────────────────────────────");
            Console.WriteLine($"📅 Fecha: {Date.ToShortDateString()}");
            Console.WriteLine($"⏰ Hora: {Time}");
            Console.WriteLine($"🆔 Cita ID: {Id}");
            Console.WriteLine($"🔖 Estado: {Status}");
            Console.WriteLine($"👨‍⚕️ Nombre del Doctor: {Doctor.Name} {Doctor.LastName}");
            Console.WriteLine($"🩺 Especialidad: {Doctor.Specialty}");
            Console.WriteLine($"#️⃣ Documento del Doctor: {Doctor.DocumentType} {Doctor.DocumentNumber}");
            Console.WriteLine($"🧑‍🤝‍🧑 Paciente: {Patient.Name} {Patient.LastName}");
            Console.WriteLine($"#️⃣ Documento del Paciente: {Patient.DocumentType} {Patient.DocumentNumber}");
            Console.WriteLine($"💬 Motivo: {Reason}");

            Console.WriteLine("────────────────────────────────────────────\n");
        }
    }
}
