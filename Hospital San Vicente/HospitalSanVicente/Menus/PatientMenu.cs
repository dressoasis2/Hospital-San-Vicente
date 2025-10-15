
using Citas.Services;
using Citas.Repositories;
using Citas.Models.Enum;

namespace Citas.Menus
{
    internal static class PatientMenu
    {
        internal static void Show()
        {
            var patientRepo = new PatientRepository();
            var patientService = new PatientService(patientRepo);

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine(" GESTIÓN DE PACIENTES");
                Console.WriteLine("");
                Console.WriteLine("1  Registrar nuevo paciente");
                Console.WriteLine("2  Mostrar todos los pacientes");
                Console.WriteLine("3  Buscar paciente");
                Console.WriteLine("4  Actualizar paciente");
                Console.WriteLine("5  Eliminar paciente");
                Console.WriteLine("0  Volver al menú principal");
                Console.WriteLine("");
                Console.Write(" Elige una opción: ");

                string option = Console.ReadLine() ?? "";

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(" NUEVO PACIENTE");

                        Console.Write("Nombre: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("Apellido: ");
                        string lastName = Console.ReadLine() ?? "";

                        Console.WriteLine("Tipo de documento (0: CC, 1: TI, 2: CE): ");
                        Enum.TryParse(Console.ReadLine(), out DocumentType docType);

                        Console.Write("Número de documento: ");
                        string docNumber = Console.ReadLine() ?? "";

                        Console.Write("Fecha de nacimiento (YYYY-MM-DD): ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime dob);

                        Console.Write("Teléfono: ");
                        string phone = Console.ReadLine() ?? "";
                        Console.Write("Correo electrónico: ");
                        string email = Console.ReadLine() ?? "";
                        Console.Write("Dirección: ");
                        string address = Console.ReadLine() ?? "";

                        Console.WriteLine("Género (0: Masculino, 1: Femenino, 2: Otro): ");
                        Enum.TryParse(Console.ReadLine(), out Gender gender);

                        patientService.RegisterPatient(name, lastName, docType, docNumber, dob, phone, email, address, gender);
                        break;

                    case "2":
                        Console.Clear();
                        patientService.ShowAllPatients();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine(" BUSCAR PACIENTE");
                        Console.Write("Número de documento del paciente: ");
                        string searchDoc = Console.ReadLine() ?? "";

                        Console.WriteLine("Tipo de documento (0: CC, 1: TI, 2: CE): ");
                        Enum.TryParse(Console.ReadLine(), out DocumentType searchType);

                        patientService.FindPatient(searchDoc, searchType);
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("🧍 ACTUALIZAR PACIENTE");

                        Console.Write("Ingrese el número de documento del paciente: ");
                        string docNumberToUpdate = Console.ReadLine() ?? "";

                        Console.WriteLine("Seleccione el tipo de documento:");
                        Console.WriteLine("1. CC");
                        Console.WriteLine("2. TI");
                        Console.WriteLine("3. CE");
                        Console.Write("Opción: ");
                        string typeOption = Console.ReadLine() ?? "1";
                        DocumentType docTypeToUpdate = typeOption switch
                        {
                            "2" => DocumentType.TI,
                            "3" => DocumentType.CE,
                            _ => DocumentType.CC
                        };

                        Console.Write("Nuevo teléfono: ");
                        string newPhone = Console.ReadLine() ?? "";
                        Console.Write("Nuevo correo electrónico: ");
                        string newEmail = Console.ReadLine() ?? "";
                        Console.Write("Nueva dirección: ");
                        string newAddress = Console.ReadLine() ?? "";

                        // Buscar paciente por documento y tipo, luego actualizar por Id
                        var patient = Citas.Data.DataBase.Patients.FirstOrDefault(p => p.DocumentNumber == docNumberToUpdate && p.DocumentType == docTypeToUpdate);
                        if (patient == null)
                        {
                            Console.WriteLine("No se encontró el paciente especificado.");
                        }
                        else
                        {
                            patientService.UpdatePatient(patient.Id, newPhone, newEmail, newAddress);
                        }
                        break;


                    case "5":
                        Console.Clear();
                        Console.WriteLine(" ELIMINAR PACIENTE");
                        Console.Write("ID del paciente (GUID): ");
                        Guid.TryParse(Console.ReadLine(), out Guid idToDelete);
                        patientService.DeletePatient(idToDelete);
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine(" Opción inválida. Intenta de nuevo.");
                        break;
                }

                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
