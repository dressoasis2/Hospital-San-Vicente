using System;
using Citas.Menus;

namespace Citas.Menus
{
    internal static class MainMenu
    {
        internal static void Start()
        {
            bool running = true;

            //dependencias de los menus

            while (running)
            {
                Console.Clear();
                Console.WriteLine("🏥 SISTEMA DE CITAS MÉDICAS");
                Console.WriteLine("──────────────────────────────");
                Console.WriteLine("1️⃣  Gestionar Pacientes");
                Console.WriteLine("2️⃣  Gestionar Doctores");
                Console.WriteLine("3️⃣  Gestionar Citas");
                Console.WriteLine("0️⃣  Salir");
                Console.WriteLine("──────────────────────────────");
                Console.Write("👉 Elige una opción: ");

                string option = Console.ReadLine() ?? "";

                switch (option)
                {
                    case "1":
                        PatientMenu.Show();
                        break;
                    case "2":
                        DoctorMenu.Show();
                        break;
                    case "3":
                        AppointmentMenu.Show().GetAwaiter().GetResult();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("\n👋 Gracias por usar el sistema. ¡Hasta pronto!");
                        break;
                    default:
                        Console.WriteLine("❌ Opción inválida. Intenta nuevamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
