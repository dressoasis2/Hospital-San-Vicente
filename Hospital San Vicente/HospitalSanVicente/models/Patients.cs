using Citas.Models.Enum;

namespace Citas.Models;

internal class Patient : Person
{
    internal DateTime DateOfBirth { get; set; }

    internal Patient(string name,
    string lastName,
    DocumentType documentType,
    string documentNumber,
    DateTime dateOfBirth,
    string phone,
    string email,
    string address,
    Gender gender) : base(name,
    lastName,
    phone,
    email,
    address,
    gender,
    documentType,
    documentNumber)
    {
        DateOfBirth = dateOfBirth;
    }
    internal void ShowPatientInfo()
    {
        BasicInfo();
        Console.WriteLine($"🎂 Fecha de nacimiento: {DateOfBirth.ToShortDateString()}");
        Console.WriteLine("────────────────────────────────────────────");
    }
}