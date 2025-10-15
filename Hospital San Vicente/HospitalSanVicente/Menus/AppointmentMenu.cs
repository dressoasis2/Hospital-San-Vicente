using Citas.Services;
using Citas.Models.Enum;
using Citas.Interfaces;
using Citas.Repositories;
using Citas.Models;

namespace Citas.Menus
{
    internal static class AppointmentMenu
    {
        internal static async Task Show()
        {
            IAppointmentRepository appointmentRepository = new AppointmentRepository();
            IDoctorRepository doctorRepository = new DoctorRepository();
            IPatientsRepository patientRepository = new PatientRepository();

            var appointmentService = new AppointmentService(appointmentRepository, doctorRepository);

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("===== GESTIÓN DE CITAS =====");
                Console.WriteLine("1. Registrar nueva cita");
                Console.WriteLine("2. Mostrar todas las citas");
                Console.WriteLine("3. Buscar cita por ID");
                Console.WriteLine("4. Buscar citas por paciente");
                Console.WriteLine("5. Buscar citas por doctor");
                Console.WriteLine("6. Actualizar cita");
                Console.WriteLine("7. Eliminar cita");
                Console.WriteLine("8. Cambiar estado de cita");
                Console.WriteLine("9. Buscar citas por estado");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nElige una opción: ");

                string option = Console.ReadLine() ?? "";

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("===== NUEVA CITA =====\n");

                        Console.WriteLine("Tipo de documento (0: CC, 1: TI, 2: CE): ");
                        Enum.TryParse(Console.ReadLine(), out DocumentType docTypeInput);

                        Console.Write("Ingrese el número de documento del paciente: ");
                        string patientDoc = Console.ReadLine() ?? "";

                        Patient? patient = patientRepository.GetPatientByDocument(patientDoc, docTypeInput);
                        if (patient == null)
                        {
                            Console.WriteLine("❌ Paciente no encontrado.");
                            Console.WriteLine("Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }

                        Console.Write("Fecha (YYYY-MM-DD): ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime date);

                        Console.Write("Hora (HH:MM, formato 24h): ");
                        TimeSpan.TryParse(Console.ReadLine(), out TimeSpan time);

                        // Specialty selection
                        Console.WriteLine("\nSeleccione el área de especialidad del doctor:");

                        var specialties = Enum.GetValues(typeof(Speciality)).Cast<Speciality>().ToList();
                        for (int i = 0; i < specialties.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {specialties[i]}");
                        }

                        Console.Write("\nIngrese el número correspondiente a la especialidad: ");
                        string input = Console.ReadLine() ?? "";

                        if (!int.TryParse(input, out int selectedIndex) || selectedIndex < 1 || selectedIndex > specialties.Count)
                        {
                            Console.WriteLine("⚠️ Número de especialidad no válido. Intente de nuevo.");
                            Console.WriteLine("Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }

                        var specialityEnum = specialties[selectedIndex - 1];
                        Console.WriteLine($"\n✅ Especialidad seleccionada: {specialityEnum}\n");

                        // Search for doctors with the selected specialty
                        var doctorsBySpecialty = doctorRepository.GetDoctorsBySpecialty(specialityEnum);
                        if (doctorsBySpecialty == null || !doctorsBySpecialty.Any())
                        {
                            Console.WriteLine($"⚠️ No se encontraron doctores con la especialidad {specialityEnum}.");
                            Console.WriteLine("Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Doctores disponibles en esta especialidad:");
                        for (int i = 0; i < doctorsBySpecialty.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {doctorsBySpecialty[i].Name} {doctorsBySpecialty[i].LastName}");
                        }

                        Console.Write("\nSeleccione el número del doctor: ");
                        string doctorInput = Console.ReadLine() ?? "";
                        if (!int.TryParse(doctorInput, out int doctorIndex) || doctorIndex < 1 || doctorIndex > doctorsBySpecialty.Count)
                        {
                            Console.WriteLine("⚠️ Número de doctor no válido. Intente de nuevo.");
                            Console.WriteLine("Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }

                        Doctor doctor = doctorsBySpecialty[doctorIndex - 1];

                        // Check doctor's availability for the selected date and time
                        var availableDoctors = appointmentService.GetAvailableDoctors(date, time, doctor);
                        if (availableDoctors == null || !availableDoctors.Any())
                        {
                            Console.WriteLine("⚠️ El doctor no está disponible en esa fecha u hora.");
                            Console.WriteLine("Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }

                        // Reason and status for the appointment
                        Console.Write("Motivo de la cita: ");
                        string reason = Console.ReadLine() ?? "";

                        var status = AppointmentStatus.Scheduled;

                        // Register the appointment
                        await appointmentService.AddAppointment(date, time, doctor, patient, reason, status);

                        Console.WriteLine("\n✅ Cita registrada correctamente.");
                        Console.WriteLine("Presiona Enter para continuar.");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("===== TODAS LAS CITAS =====\n");
                        appointmentService.ShowAllAppointments();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("===== BUSCAR CITA =====\n");
                        appointmentService.ShowAllAppointments();
                        Console.WriteLine();

                        Console.Write("ID de la Cita: ");
                        Guid.TryParse(Console.ReadLine(), out Guid appointmentId);
                        appointmentService.GetAppointmentById(appointmentId);
                        Console.WriteLine("\nPresiona Enter para continuar.");  
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("===== CITAS POR PACIENTE =====\n");

                        Console.WriteLine("Tipo de documento (0: CC, 1: TI, 2: CE): ");
                        Enum.TryParse(Console.ReadLine(), out DocumentType docTypePatient);

                        Console.Write("Número de documento del paciente: ");
                        string patientDocNumber = Console.ReadLine() ?? "";
                        var patientForAppointments = patientRepository.GetPatientByDocument(patientDocNumber, docTypePatient);
                        if (patientForAppointments == null)
                        {
                            Console.WriteLine("❌ Paciente no encontrado.");
                            Console.WriteLine("Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }

                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("===== CITAS POR DOCTOR =====\n");

                        Console.WriteLine("Tipo de documento (0: CC, 1: TI, 2: CE): ");
                        Enum.TryParse(Console.ReadLine(), out DocumentType docTypeDoctor);

                        Console.Write("Número de documento del doctor: ");
                        string doctorDocNumber = Console.ReadLine() ?? "";
                        var doctorForAppointments = doctorRepository.GetDoctorByDocument(doctorDocNumber, docTypeDoctor);
                        if (doctorForAppointments == null)
                        {
                            Console.WriteLine("❌ Doctor no encontrado.");
                            Console.WriteLine("Presiona Enter para continuar.");
                            Console.ReadLine();
                            break;
                        }

                        appointmentService.GetAppointmentsByDoctor(doctorForAppointments);
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break; 
                    case "6":
                        Console.Clear();
                        Console.WriteLine("===== ACTUALIZAR CITA =====\n");
                        appointmentService.ShowAllAppointments();
                        Console.WriteLine();
                        Console.Write("ID de la Cita a actualizar: ");
                        Guid.TryParse(Console.ReadLine(), out Guid updateId);   
                        Console.Write("Nueva fecha (YYYY-MM-DD): ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime newDate);
                        Console.Write("Nueva hora (HH:MM, formato 24h): ");
                        TimeSpan.TryParse(Console.ReadLine(), out TimeSpan newTime);
                        Console.Write("Nuevo motivo: ");
                        string newReason = Console.ReadLine() ?? "";
                        Console.WriteLine("Nuevo estado (0: Scheduled, 1: Completed, 2: Canceled): ");
                        Enum.TryParse(Console.ReadLine(), out AppointmentStatus newStatus);
                        appointmentService.UpdateAppointment(updateId, newDate, newTime, newReason, newStatus);
                        Console.WriteLine("\n✅ Cita actualizada correctamente.");
                        Console.WriteLine("Presiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("===== ELIMINAR CITA =====\n");
                        appointmentService.ShowAllAppointments();
                        Console.WriteLine();
                        Console.Write("ID de la Cita a eliminar: ");
                        Guid.TryParse(Console.ReadLine(), out Guid deleteId);
                        appointmentService.RemoveAppointment(deleteId);
                        Console.WriteLine("\n✅ Cita eliminada correctamente.");
                        Console.WriteLine("Presiona Enter para continuar.");
                        Console.ReadLine();
                        break; 
                    case "8":
                        Console.Clear();
                        Console.WriteLine("===== CAMBIAR ESTADO DE CITA =====\n");
                        appointmentService.ShowAllAppointments();
                        Console.WriteLine();
                        Console.Write("ID de la Cita para cambiar estado: ");
                        Guid.TryParse(Console.ReadLine(), out Guid statusId);
                        Console.WriteLine("Nuevo estado (0: Scheduled, 1: Completed, 2: Canceled): ");
                        Enum.TryParse(Console.ReadLine(), out AppointmentStatus updatedStatus);
                        appointmentService.UpdateAppointmentStatus(statusId, updatedStatus);
                        Console.WriteLine("\n✅ Estado de la cita actualizado correctamente.");
                        Console.WriteLine("Presiona Enter para continuar.");
                        Console.ReadLine();
                        break;  
                    case "9":
                        Console.Clear();
                        Console.WriteLine("===== BUSCAR CITAS POR ESTADO =====\n");
                        Console.WriteLine("Seleccione el estado de la cita a buscar (0: Scheduled, 1: Completed, 2: Canceled): ");
                        Enum.TryParse(Console.ReadLine(), out AppointmentStatus searchStatus);
                        // Search and display appointments by status
                        var appointmentsByStatus = appointmentService.GetAppointmentsByStatus(searchStatus);
                        if (appointmentsByStatus == null || !appointmentsByStatus.Any())
                        {
                            Console.WriteLine($"⚠️ No se encontraron citas con el estado {searchStatus}.");
                        }
                        else
                        {
                            Console.WriteLine($"\n📅 Citas con estado {searchStatus}:");
                            foreach (var appointment in appointmentsByStatus)
                            {
                                appointment.ShowAppointmentInfo();
                            }
                        }
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                        
                        

                    default:
                        Console.WriteLine("⚠️ Opción no válida. Intente nuevamente.");
                        Console.WriteLine("Presiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
