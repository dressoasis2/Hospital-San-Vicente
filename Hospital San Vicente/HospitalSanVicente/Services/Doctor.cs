
using Citas.Models;
using Citas.Models.Enum;
using Citas.Interfaces;

namespace Citas.Services
{
    internal class DoctorService
    {
        private readonly IDoctorRepository _repository;

        // Constructor que recibe el repositorio
        internal DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        // Registrar un nuevo doctor (usa todos los parámetros necesarios)
        internal void AddDoctor(
            string name,
            string lastName,
            string phone,
            string email,
            string address,
            Gender gender,
            DocumentType documentType,
            string documentNumber,
            Speciality specialty)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
                    throw new ArgumentException("El nombre y el apellido son obligatorios.");
                if (string.IsNullOrWhiteSpace(documentNumber))
                    throw new ArgumentException("El número de documento no puede estar vacío.");
                if (phone == null)
                    throw new ArgumentException("El teléfono es obligatorio.");
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentException("El correo electrónico es obligatorio.");
                if (!email.Contains("@"))
                    throw new ArgumentException("El correo electrónico no es válido.");
                if (string.IsNullOrWhiteSpace(address))
                    throw new ArgumentException("La dirección es obligatoria.");

                // Crear instancia usando el constructor que definiste
                var newDoctor = new Doctor(
                    name,
                    lastName,
                    phone,
                    email,
                    address,
                    gender,
                    documentType,
                    documentNumber,
                    specialty
                );

                _repository.AddDoctor(newDoctor);
                Console.WriteLine("✅ Doctor registrado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar doctor: {ex.Message}");
            }
        }

        // Mostrar todos los doctores
        internal void ShowAllDoctors()
        {
            try
            {
                _repository.ShowAllDoctors();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error al mostrar doctores: {ex.Message}");
            }
        }

        // Buscar doctor por ID
        internal void GetDoctorById(Guid id)
        {
            try
            {
                var doctor = _repository.GetDoctorById(id);

                if (doctor == null)
                {
                    Console.WriteLine("⚠️ No se encontró ningún doctor con ese ID.");
                    return;
                }

                Console.WriteLine("\n🧾 Información del doctor encontrado:");
                doctor.ShowDoctorInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al buscar doctor: {ex.Message}");
            }
        }

        // Eliminar doctor por ID
        internal void RemoveDoctor(Guid id)
        {
            try
            {
                _repository.RemoveDoctor(id);
                Console.WriteLine("✅ Doctor eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al eliminar doctor: {ex.Message}");
            }
        }

        // Actualizar doctor existente (buscando por número y tipo de documento)
        internal void UpdateDoctor(string documentNumber, DocumentType documentType, string specialty, string phone, string email, string address)
        {
            try
            {
                var existing = _repository.GetAllDoctors().FirstOrDefault(d => d.DocumentNumber == documentNumber && d.DocumentType == documentType);

                if (existing == null)
                {
                    Console.WriteLine("⚠️ El doctor no existe.");
                    return;
                }

                // Validaciones parciales
                if (string.IsNullOrWhiteSpace(specialty))
                    throw new ArgumentException("La especialidad no puede estar vacía.");
                if (string.IsNullOrWhiteSpace(phone))
                    throw new ArgumentException("El teléfono no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentException("El correo electrónico no puede estar vacío.");
                if (!email.Contains("@"))
                    throw new ArgumentException("El correo electrónico no es válido.");
                if (string.IsNullOrWhiteSpace(address))
                    throw new ArgumentException("La dirección no puede estar vacía.");

                // Intentar parsear la nueva especialidad a enum
                if (!Enum.TryParse<Speciality>(specialty, true, out var specialtyEnum))
                {
                    specialtyEnum = Speciality.MedicinaGeneral;
                }

                // Aplicar cambios
                existing.Specialty = specialtyEnum;
                existing.Phone = phone;
                existing.Email = email;
                existing.Address = address;

                _repository.UpdateDoctor(existing);
                Console.WriteLine("✅ Información del doctor actualizada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al actualizar doctor: {ex.Message}");
            }
        }

        // Buscar doctor por especialidad
        internal void GetDoctorsBySpecialty(Speciality specialty)
        {
            try
            {
                var doctors = _repository.GetDoctorsBySpecialty(specialty);

                if (doctors == null || doctors.Count == 0)
                {
                    Console.WriteLine("⚠️ No se encontraron doctores con esa especialidad.");
                    return;
                }

                Console.WriteLine($"\n🧾 Doctores con especialidad {specialty}:");
                foreach (var doctor in doctors)
                {
                    doctor.ShowDoctorInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al buscar doctores por especialidad: {ex.Message}");
            }
        }

        internal void FindDoctor(string documentNumber, DocumentType documentType)
        {
            try
            {
                var doctor = _repository.GetDoctorByDocument(documentNumber, documentType);

                if (doctor == null)
                {
                    Console.WriteLine("⚠️ No se encontró ningún doctor con esos datos.");
                    return;
                }

                Console.WriteLine("\n🧾 Información del doctor encontrado:");
                doctor.ShowDoctorInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al buscar doctor: {ex.Message}");
            }
        }




    }
}
