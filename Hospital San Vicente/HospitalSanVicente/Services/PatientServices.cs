using System;
using System.Collections.Generic;
using Citas.Models;
using Citas.Models.Enum;
using Citas.Interfaces;
using Citas.Repositories;

namespace Citas.Services
{
    internal class PatientService
    {
        private readonly IPatientsRepository _repository;

        // 🔹 Constructor que recibe la dependencia del repositorio
        internal PatientService(IPatientsRepository repository)
        {
            _repository = repository;
        }

        // 🔹 Método para registrar un nuevo paciente
        internal void RegisterPatient(string name, string lastName, DocumentType documentType, string documentNumber,
            DateTime dateOfBirth, string phone, string email, string address, Gender gender)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
                    throw new ArgumentException("El nombre y el apellido son obligatorios.");
                if (string.IsNullOrWhiteSpace(documentNumber))
                    throw new ArgumentException("El número de documento no puede estar vacío.");
                if (dateOfBirth > DateTime.Now)
                    throw new ArgumentException("La fecha de nacimiento no puede ser futura.");
                if (string.IsNullOrWhiteSpace(phone))
                    throw new ArgumentException("El teléfono es obligatorio.");
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentException("El correo electrónico es obligatorio.");
                if (!email.Contains("@"))
                    throw new ArgumentException("El correo electrónico no es válido.");
                if (string.IsNullOrWhiteSpace(address))
                    throw new ArgumentException("La dirección es obligatoria.");

                // Crear el paciente
                var newPatient = new Patient(name, lastName, documentType, documentNumber, dateOfBirth, phone, email, address, gender);

                _repository.AddPatient(newPatient);
                Console.WriteLine("✅ Paciente registrado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al registrar paciente: {ex.Message}");
            }
        }

        // 🔹 Método para mostrar todos los pacientes
        internal void ShowAllPatients()
        {
            try
            {
                _repository.ShowAllPatients();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error al mostrar pacientes: {ex.Message}");
            }
        }

        // 🔹 Método para buscar paciente por documento
        internal void FindPatient(string documentNumber, DocumentType documentType)
        {
            try
            {
                var patient = _repository.GetPatientByDocument(documentNumber, documentType);

                if (patient == null)
                {
                    Console.WriteLine("⚠️ No se encontró ningún paciente con esos datos.");
                    return;
                }

                Console.WriteLine("\n🧾 Información del paciente encontrado:");
                patient.ShowPatientInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al buscar paciente: {ex.Message}");
            }
        }

        // 🔹 Método para eliminar paciente por Id
        internal void DeletePatient(Guid id)
        {
            try
            {
                _repository.RemovePatient(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al eliminar paciente: {ex.Message}");
            }
        }

        // 🔹 Método para actualizar paciente existente
        internal void UpdatePatient(Guid id, string phone, string email, string address)
        {
            try
            {
                var existing = _repository.GetAllPatients().FirstOrDefault(p => p.Id == id);

                if (existing == null)
                {
                    Console.WriteLine("⚠️ El paciente no existe.");
                    return;
                }

                // Validaciones
                if (string.IsNullOrWhiteSpace(phone))
                    throw new ArgumentException("El teléfono no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentException("El correo electrónico no puede estar vacío.");
                if (!email.Contains("@"))
                    throw new ArgumentException("El correo electrónico no es válido.");
                if (string.IsNullOrWhiteSpace(address))
                    throw new ArgumentException("La dirección no puede estar vacía.");

                existing.Phone = phone;
                existing.Email = email;
                existing.Address = address;

                _repository.UpdatePatient(existing);
                Console.WriteLine("✅ Información del paciente actualizada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al actualizar paciente: {ex.Message}");
            }
        }
    }
}
