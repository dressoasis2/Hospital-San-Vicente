
using Citas.Models;
using Citas.Models.Enum;
using Citas.Interfaces;
using Citas.Repositories;
using System.Threading.Tasks;
using Citas.Services;


namespace Citas.Services
{
        internal class AppointmentService
        {
            // Fields and methods for appointment management
            public List<Appointment> GetAppointmentsByStatus(AppointmentStatus status)
            {
                var appointments = _appointmentRepository.GetAllAppointments()
                    .Where(a => a.Status == status)
                    .ToList();
                return appointments;
            }
            // End of class code
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly DoctorRepository _doctorRepository;

    // Constructor receives repositories for dependency injection from the menu
        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = (DoctorRepository)doctorRepository;
        }

    // Register a new appointment
        public async Task AddAppointment(
            DateTime date,
            TimeSpan time,
            Doctor doctor,
            Patient patient,
            string reason,
            AppointmentStatus status)
        {
            try
            {
                if (date.Date < DateTime.Now.Date)
                    throw new ArgumentException("La fecha de la cita no puede ser en el pasado.");
                if (doctor == null)
                    throw new ArgumentException("El doctor es obligatorio.");
                if (patient == null)
                    throw new ArgumentException("El paciente es obligatorio.");
                if (string.IsNullOrWhiteSpace(reason))
                    throw new ArgumentException("El motivo de la cita no puede estar vacío.");
                if (time < TimeSpan.FromHours(8) || time > TimeSpan.FromHours(17))
                    throw new ArgumentException("La hora de la cita debe estar entre las 08:00 y las 17:00.");
                if (time.Minutes % 30 != 0)
                    throw new ArgumentException("La hora de la cita debe ser en intervalos de 30 minutos.");

                // Create the new appointment object
                var newAppointment = new Appointment(date, time, doctor, patient, reason, status);
                await _appointmentRepository.AddAppointment(newAppointment);

                // Send confirmation email to the patient
                string subject = "📅 Confirmación de Cita Médica - Hospital San Vicente";
                string body = $@"
                <html>
                <body style='font-family: Arial, sans-serif; color: #333;'>
                    <h2 style='color: #0066cc;'>¡Hola {patient.Name}!</h2>
                    <p>Tu cita médica ha sido <strong>registrada exitosamente</strong>.</p>
                    <table style='border-collapse: collapse; margin-top: 10px;'>
                        <tr>
                            <td style='padding: 6px 10px; border: 1px solid #ddd;'><strong>🗓 Fecha:</strong></td>
                            <td style='padding: 6px 10px; border: 1px solid #ddd;'>{date:dd/MM/yyyy}</td>
                        </tr>
                        <tr>
                            <td style='padding: 6px 10px; border: 1px solid #ddd;'><strong>⏰ Hora:</strong></td>
                            <td style='padding: 6px 10px; border: 1px solid #ddd;'>{time:hh\\:mm}</td>
                        </tr>
                        <tr>
                            <td style='padding: 6px 10px; border: 1px solid #ddd;'><strong>👨‍⚕️ Doctor:</strong></td>
                            <td style='padding: 6px 10px; border: 1px solid #ddd;'>{doctor.Name} {doctor.LastName}</td>
                        </tr>
                        <tr>
                            <td style='padding: 6px 10px; border: 1px solid #ddd;'><strong>📝 Motivo:</strong></td>
                            <td style='padding: 6px 10px; border: 1px solid #ddd;'>{reason}</td>
                        </tr>
                    </table>
                    <p style='margin-top: 20px;'>Por favor llega 10 minutos antes de tu cita. <br/>
                    ¡Gracias por confiar en <strong>Hospital San Vicente</strong>!</p>
                    <hr/>
                    <small style='color: #777;'>Este es un mensaje automático, por favor no respondas a este correo.</small>
                </body>
                </html>";

                Console.WriteLine("🚀 Intentando enviar correo...");
                await EmailService.SendEmailAsync(patient.Email, subject, body);
                Console.WriteLine("📬 Correo enviado (o intento finalizado)");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar la cita: {ex.Message}");
            }
        }

    // Show all appointments
        public void ShowAllAppointments()
        {
            try
            {
                _appointmentRepository.ShowAllAppointments();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error: {ex.Message}");
            }
        }

    // Search appointment by ID
        public void GetAppointmentById(Guid id)
        {
            try
            {
                var appointment = _appointmentRepository.GetAppointmentById(id);
                if (appointment != null)
                {
                    appointment.ShowAppointmentInfo();
                }
                else
                {
                    Console.WriteLine("⚠️ No se encontró ninguna cita con ese ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

    // Delete appointment
        public void RemoveAppointment(Guid id)
        {
            try
            {
                _appointmentRepository.RemoveAppointment(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al eliminar la cita: {ex.Message}");
            }
        }

    // Update appointment (date, time, reason, or status)
        public void UpdateAppointment(Guid id, DateTime newDate, TimeSpan newTime, string newReason, AppointmentStatus newStatus)
        {
            try
            {
                var appointment = _appointmentRepository.GetAppointmentById(id);
                if (appointment == null)
                {
                    Console.WriteLine("⚠️ No se encontró ninguna cita con ese ID.");
                    return;
                }

                appointment.Date = newDate;
                appointment.Time = newTime;
                appointment.Reason = newReason;
                appointment.Status = newStatus;

                _appointmentRepository.UpdateAppointment(appointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al actualizar la cita: {ex.Message}");
            }
        }
        public List<Doctor> GetAvailableDoctors(DateTime date, TimeSpan time, Doctor doctor)
        {
            // Validate input parameters
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor), "El doctor es obligatorio.");
            if (date.Date < DateTime.Now.Date)
                throw new ArgumentException("La fecha de la cita no puede ser en el pasado.");
            if (time < TimeSpan.FromHours(8) || time > TimeSpan.FromHours(17))
                throw new ArgumentException("La hora de la cita debe estar entre las 08:00 y las 17:00.");
            if (time.Minutes % 30 != 0)
                throw new ArgumentException("La hora de la cita debe ser en intervalos de 30 minutos.");
            var availableDoctors = _doctorRepository.GetAvailableDoctors(date, time, doctor.Specialty);
            return availableDoctors;
        }
        public void GetAppointmentsByPatient(Patient patient)
        {
            try
            {
                if (patient == null)
                    throw new ArgumentNullException(nameof(patient), "El paciente es obligatorio.");

                var appointments = _appointmentRepository.GetAllAppointments()
                    .Where(a => a.Patient.Id == patient.Id)
                    .ToList();

                if (appointments.Count == 0)
                {
                    Console.WriteLine("⚠️ No se encontraron citas para este paciente.");
                    return;
                }

                Console.WriteLine($"\n🗓️ Citas del paciente {patient.Name} {patient.LastName}:");
                foreach (var appointment in appointments)
                {
                    appointment.ShowAppointmentInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        public void GetAppointmentsByDoctor(Doctor doctor)
        {
            try
            {
                if (doctor == null)
                    throw new ArgumentNullException(nameof(doctor), "El doctor es obligatorio.");

                var appointments = _appointmentRepository.GetAllAppointments()
                    .Where(a => a.Doctor.Id == doctor.Id)
                    .ToList();
                if (appointments.Count == 0)
                {
                    Console.WriteLine("⚠️ No se encontraron citas para este doctor.");
                    return;
                }
                Console.WriteLine($"\n🗓️ Citas del doctor {doctor.Name} {doctor.LastName}:");
                foreach (var appointment in appointments)
                {
                    appointment.ShowAppointmentInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");

            }
        }
        public void UpdateAppointmentStatus(Guid id, AppointmentStatus newStatus)
        {
            try
            {
                var appointment = _appointmentRepository.GetAppointmentById(id);
                if (appointment == null)
                {
                    Console.WriteLine("⚠️ No se encontró ninguna cita con ese ID.");
                    return;
                }

                appointment.Status = newStatus;
                _appointmentRepository.UpdateAppointment(appointment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al actualizar el estado de la cita: {ex.Message}");
            }
        }  
        public void GetAppointmentByStatus(AppointmentStatus status)
        {
            try
            {
                var appointments = _appointmentRepository.GetAllAppointments()
                    .Where(a => a.Status == status)
                    .ToList();

                if (appointments.Count == 0)
                {
                    Console.WriteLine("⚠️ No se encontraron citas con ese estado.");
                    return;
                }

                Console.WriteLine($"\n🗓️ Citas con estado {status}:");
                foreach (var appointment in appointments)
                {
                    appointment.ShowAppointmentInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }       
    }
}
