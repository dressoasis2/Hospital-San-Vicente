using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Required for Task and await
using Citas.Interfaces;
using Citas.Models;
using Citas.Models.Enum;
using Citas.Data;
using Citas.Services; // Required to use EmailService

namespace Citas.Repositories
{
    internal class AppointmentRepository : IAppointmentRepository
    {
    // Add a new appointment to the database
        public async Task AddAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment), "La cita no puede ser nula.");

            // Prevent duplicate appointments for the same patient, doctor, and date
            bool exists = DataBase.Appointments.Any(a =>
                a.Patient.Id == appointment.Patient.Id &&
                a.Doctor.Id == appointment.Doctor.Id &&
                a.Date == appointment.Date);

            if (exists)
                throw new InvalidOperationException("Ya existe una cita para ese paciente, doctor y fecha.");

            // Save the appointment to the database
            DataBase.Appointments.Add(appointment);
            Console.WriteLine("✅ Cita registrada correctamente.");

            // Send confirmation email to the patient
            string subject = "Confirmación de Cita Médica";

            // Email body (HTML format)
            string body = $@"
                <h2>¡Hola {appointment.Patient.Name}!</h2>
                <p>Tu cita ha sido registrada exitosamente.</p>
                <ul>
                    <li><b>Doctor:</b> {appointment.Doctor.Name}</li>
                    <li><b>Fecha:</b> {appointment.Date:dd/MM/yyyy}</li>
                    <li><b>Hora:</b> {appointment.Time}</li>
                    <li><b>Motivo:</b> {appointment.Reason}</li>
                </ul>
                <p>Gracias por confiar en el <b>Hospital San Vicente</b> 🩺</p>
            ";

            await EmailService.SendEmailAsync(appointment.Patient.Email, subject, body);
        }

    // Get appointment by ID
        public Appointment? GetAppointmentById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El ID de la cita no puede estar vacío.", nameof(id));

            return DataBase.Appointments.FirstOrDefault(a => a.Id == id);
        }

    // Get all appointments
        public List<Appointment> GetAllAppointments()
        {
            if (DataBase.Appointments == null || DataBase.Appointments.Count == 0)
                throw new InvalidOperationException("No hay citas registradas.");

            return DataBase.Appointments;
        }

    // Delete appointment by ID
        public void RemoveAppointment(Guid id)
        {
            var appointment = DataBase.Appointments.FirstOrDefault(a => a.Id == id);

            if (appointment == null)
                throw new InvalidOperationException("La cita no existe.");

            DataBase.Appointments.Remove(appointment);
            Console.WriteLine("🗑️ Cita eliminada correctamente.");
        }

    // Update an existing appointment
        public void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment), "La cita no puede ser nula.");

            var existing = DataBase.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            if (existing == null)
                throw new InvalidOperationException("La cita no existe.");

            // Update appointment fields
            existing.Patient.Id = appointment.Patient.Id;
            existing.Doctor.Id = appointment.Doctor.Id;
            existing.Date = appointment.Date;
            existing.Reason = appointment.Reason;
            existing.Status = appointment.Status;

            Console.WriteLine("✅ Cita actualizada exitosamente.");
        }

    // Display all registered appointments
        public void ShowAllAppointments()
        {
            if (DataBase.Appointments.Count == 0)
            {
                Console.WriteLine("⚠️ No hay citas registradas.");
                return;
            }

            Console.WriteLine("\n📅 Lista de citas registradas:");
            foreach (var appointment in DataBase.Appointments)
            {
                appointment.ShowAppointmentInfo();
            }
        }

    }
}
