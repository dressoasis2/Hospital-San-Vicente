using Citas.Menus;
using Citas.Data; // ✅ Importamos la base de datos de ejemplo

namespace Citas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión de Citas Médicas";
            Console.WriteLine("Bienvenido al Sistema de Gestión de Citas Médicas\n");

            // 🔹 Cargar pacientes de ejemplo (solo si la base está vacía)
            PatientDataExample.LoadToMainDataBasePatient();
            // 🔹 Cargar doctores de ejemplo (solo si la base está vacía
            DoctorDataExample.LoadToMainDataBaseDoctor();

            // 🔹 Iniciar menú principal
            MainMenu.Start();
        }
    }
}
