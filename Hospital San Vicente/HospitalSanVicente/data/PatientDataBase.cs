using System;
using System.Collections.Generic;
using Citas.Models;
using Citas.Models.Enum;

namespace Citas.Data
{
    internal static class PatientDataExample
    {
        // 🔹 Lista de pacientes de ejemplo (no afecta la base real)
        internal static List<Patient> ExamplePatients { get; } = new List<Patient>
        {
            new Patient(
                name: "Camila",
                lastName: "Gómez",
                documentType: DocumentType.CC,
                documentNumber: "1023456789",
                dateOfBirth: new DateTime(1998, 4, 15),
                phone: "3001234567",
                email: "camila.gomez@example.com",
                address: "Calle 45 #23-12, Bogotá",
                gender: Gender.Female
            ),
            new Patient(
                name: "Juan",
                lastName: "Martínez",
                documentType: DocumentType.TI,
                documentNumber: "1205678901",
                dateOfBirth: new DateTime(2005, 8, 2),
                phone: "3109876543",
                email: "juan.martinez@example.com",
                address: "Carrera 10 #45-67, Cali",
                gender: Gender.Male
            ),
            new Patient(
                name: "Laura",
                lastName: "Hernández",
                documentType: DocumentType.CC,
                documentNumber: "1011122233",
                dateOfBirth: new DateTime(1992, 12, 10),
                phone: "3152233445",
                email: "laura.hernandez@example.com",
                address: "Av. Siempre Viva 123, Medellín",
                gender: Gender.Female
            ),
            new Patient(
                name: "Carlos",
                lastName: "Pérez",
                documentType: DocumentType.CE,
                documentNumber: "987654321",
                dateOfBirth: new DateTime(1986, 6, 25),
                phone: "3029988776",
                email: "carlos.perez@example.com",
                address: "Calle 9 #30-45, Bucaramanga",
                gender: Gender.Male
            ),
            new Patient(
                name: "Dress",
                lastName: "Toloza",
                documentType: DocumentType.CC,
                documentNumber: "1140895051",
                dateOfBirth: new DateTime(1997,09, 25),
                phone: "3029988776",
                email: "andrestolozatejeda@gmail.com",
                address: "Calle 72 #23-62, Barranquilla",
                gender: Gender.Male


            )
        };

        // 🔹 Método opcional para copiar estos pacientes a la base real
        internal static void LoadToMainDataBasePatient()
        {
            if (DataBase.Patients.Count == 0)
            {
                DataBase.Patients.AddRange(ExamplePatients);
                Console.WriteLine("✅ Pacientes de ejemplo cargados en la base de datos principal.");
            }
            else
            {
                Console.WriteLine("⚠️ Ya existen pacientes en la base de datos, no se agregaron los de ejemplo.");
            }
        }
    }
}
