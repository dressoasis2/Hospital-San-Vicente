using Citas.Services;
using Citas.Models.Enum;
using Citas.Interfaces;
using Citas.Repositories;
using Citas.Data;
using Citas.Models;

namespace Citas.Menus
{
    internal static class DoctorMenu
    {
        internal static void Show()
        {
            var doctorRepo = new DoctorRepository();
            var doctorService = new DoctorService(doctorRepo);

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE DOCTORES");
                Console.WriteLine("");
                Console.WriteLine("1  Registrar nuevo doctor");
                Console.WriteLine("2  Mostrar todos los doctores");
                Console.WriteLine("3  Buscar doctor");
                Console.WriteLine("4  Buscar doctor por especialidad");
                Console.WriteLine("5  Actualizar doctor");
                Console.WriteLine("6  Eliminar doctor");
                Console.WriteLine("0  Volver al menú principal");
                Console.WriteLine("");
                Console.Write(" Elige una opción: ");

                string option = Console.ReadLine() ?? "";

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(" NUEVO DOCTOR");

                        Console.Write("Nombre: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("Apellido: ");
                        string lastName = Console.ReadLine() ?? "";

                        Console.WriteLine("Tipo de documento (0: CC, 1: TI, 2: CE): ");
                        Enum.TryParse(Console.ReadLine(), out DocumentType docTypeInput);

                        Console.Write("Número de documento: ");
                        string docNumber = Console.ReadLine() ?? "";

                        Console.Write("Teléfono: ");
                        string phone = Console.ReadLine() ?? "";
                        Console.Write("Correo electrónico: ");
                        string email = Console.ReadLine() ?? "";
                        Console.Write("Dirección: ");
                        string address = Console.ReadLine() ?? "";

                        Console.WriteLine("Género (0: Masculino, 1: Femenino, 2: Otro): ");
                        Enum.TryParse(Console.ReadLine(), out Gender gender);
                        Console.Write("Especialidad: ");
                        string specialty = Console.ReadLine() ?? "";

                        // Intentar parsear la especialidad ingresada a Speciality (enum). Si falla, usar MedicinaGeneral por defecto.
                        if (!Enum.TryParse<Speciality>(specialty, true, out var specialtyEnum))
                        {
                            specialtyEnum = Speciality.MedicinaGeneral;
                        }

                        doctorService.AddDoctor(
                            name,
                            lastName,
                            phone,
                            email,
                            address,
                            gender,
                            docTypeInput,
                            docNumber,
                            specialtyEnum
                        );
                        break;

                    case "2":
                        Console.Clear();
                        doctorService.ShowAllDoctors();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine(" BUSCAR DOCTOR");
                        Console.Write("Número de documento del doctor: ");
                        string searchDoc = Console.ReadLine() ?? "";
                        Console.WriteLine("Tipo de documento (0: CC, 1: TI, 2: CE): ");
                        Enum.TryParse(Console.ReadLine(), out DocumentType searchType);
                        doctorService.FindDoctor(searchDoc, searchType);
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine(" BUSCAR DOCTOR POR ESPECIALIDAD");

                        // 🔹 Mostrar todas las especialidades numeradas
                        var specialties = Enum.GetValues(typeof(Speciality)).Cast<Speciality>().ToList();

                        for (int i = 0; i < specialties.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {specialties[i]}");
                        }

                        Console.Write("\nSeleccione el número de la especialidad: ");
                        if (int.TryParse(Console.ReadLine(), out int specialtyIndex) &&
                            specialtyIndex > 0 && specialtyIndex <= specialties.Count)
                        {
                            var selectedSpecialty = specialties[specialtyIndex - 1];

                            Console.Clear();
                            Console.WriteLine($"👨‍⚕️ DOCTORES CON ESPECIALIDAD EN {selectedSpecialty}:\n");

                            // 🔹 Buscar doctores que tengan la especialidad seleccionada
                            var matchingDoctors = Citas.Data.DataBase.Doctors
                                .Where(d => d.Specialty == selectedSpecialty)
                                .ToList();

                            if (matchingDoctors.Count == 0)
                            {
                                Console.WriteLine("⚠️ No se encontraron doctores con esa especialidad.");
                            }
                            else
                            {
                                foreach (var doctor in matchingDoctors)
                                {
                                    Console.WriteLine($"🩺 {doctor.Name} {doctor.LastName} - {doctor.Specialty}");
                                    Console.WriteLine($"📞 {doctor.Phone} | 📧 {doctor.Email}");
                                    Console.WriteLine("-----------------------------------");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("❌ Opción inválida.");
                        }
                        break;


                    case "5":
                        Console.Clear();
                        Console.WriteLine("🩺 ACTUALIZAR DOCTOR");
                        Console.Write("Ingrese el número de documento del doctor: ");
                        string docNumberUpdate = Console.ReadLine() ?? "";
                        Console.WriteLine("Seleccione el tipo de documento:");
                            Console.WriteLine("1. CC");
                            Console.WriteLine("2. TI");
                            Console.WriteLine("3. CE");
                        Console.Write("Opción: ");
                        string typeOption = Console.ReadLine() ?? "1";
                            DocumentType docTypeUpdate = typeOption switch
                            {
                                "2" => DocumentType.TI,
                                "3" => DocumentType.CE,
                                _ => DocumentType.CC
                            };

                        Console.Write("Nueva especialidad: ");
                        string newSpecialty = Console.ReadLine() ?? "";
                        Console.Write("Nuevo teléfono: ");
                        string newPhone = Console.ReadLine() ?? "";
                        Console.Write("Nuevo correo electrónico: ");
                        string newEmail = Console.ReadLine() ?? "";
                        Console.Write("Nueva dirección: ");
                        string newAddress = Console.ReadLine() ?? "";

                        doctorService.UpdateDoctor(docNumberUpdate, docTypeUpdate, newSpecialty, newPhone, newEmail, newAddress);
                        break;

                    case "6":
                        Console.Write("Ingrese el ID del doctor a eliminar: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid deleteId))
                        {
                            doctorService.RemoveDoctor(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("ID no válido.");
                        }
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}