using Citas.Models.Enum;

namespace Citas.Models;

internal abstract class Person(string name,
 string lastName,
 string phone,
 string email,
    string address,
    Gender gender,
    DocumentType documentType,
    string documentNumber)
{
    internal Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = name;
    public string LastName { get; set; } = lastName;
    public string Address { get; set; } = address;
    public string Phone { get; set; } = phone;
    public string Email { get; set; } = email;
    public Gender Gender { get; set; } = gender;
    public DocumentType DocumentType { get; set; } = documentType;
    public string DocumentNumber { get; set; } = documentNumber;


    protected void BasicInfo()
    {
        Console.WriteLine("────────────────────────────────────────────");
        Console.WriteLine("           👤 INFORMACIÓN BÁSICA");
        Console.WriteLine("────────────────────────────────────────────");
        Console.WriteLine($"🆔 ID:                  {Id}");
        Console.WriteLine($"👩‍💼 Nombre:             {Name}");
        Console.WriteLine($"👨‍💼 Apellido:           {LastName}");
        Console.WriteLine($"📞 Teléfono:            {Phone}");
        Console.WriteLine($"🏠 Dirección:           {Address}");
        Console.WriteLine($"📧 Email:               {Email}");
        Console.WriteLine($"🪪 Tipo de documento:   {DocumentType}");
        Console.WriteLine($"#️⃣ Número de documento: {DocumentNumber}");
        Console.WriteLine("────────────────────────────────────────────\n");
    }
}