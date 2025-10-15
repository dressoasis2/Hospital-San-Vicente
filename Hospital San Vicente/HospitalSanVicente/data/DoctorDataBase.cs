
using Citas.Models;
using Citas.Models.Enum;

namespace Citas.Data
{
    internal static class DoctorDataExample
    {
        internal static List<Doctor> ExampleDoctors = new List<Doctor>
{
    // 🩺 CARDIOLOGÍA
    new Doctor(
        name: "Luis",
        lastName: "Gómez",
        documentType: DocumentType.CC,
        documentNumber: "987654321",
        phone: "3109876543",
        email: "luis@gmail.com",
        address: "Carrera 10 #45-67, Cali",
        specialty: Speciality.Cardiología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Patricia",
        lastName: "Rincón",
        documentType: DocumentType.CC,
        documentNumber: "1002345678",
        phone: "3002223344",
        email: "patricia.cardiologia@gmail.com",
        address: "Calle 20 #8-30, Bogotá",
        specialty: Speciality.Cardiología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "José",
        lastName: "Navarro",
        documentType: DocumentType.CC,
        documentNumber: "1009871234",
        phone: "3129981122",
        email: "jose.navarro@cardio.com",
        address: "Av. Caracas 120, Bogotá",
        specialty: Speciality.Cardiología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Mariana",
        lastName: "Cruz",
        documentType: DocumentType.CC,
        documentNumber: "1003335556",
        phone: "3148876655",
        email: "mariana.cruz@cardio.com",
        address: "Cra 14 #110-33, Medellín",
        specialty: Speciality.Cardiología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Camilo",
        lastName: "Torres",
        documentType: DocumentType.CC,
        documentNumber: "1002345590",
        phone: "3152234987",
        email: "camilo.torres@cardio.co",
        address: "Cl. 72 #15-10, Barranquilla",
        specialty: Speciality.Cardiología,
        gender: Gender.Male
    ),

    // 🌿 DERMATOLOGÍA
    new Doctor(
        name: "Lucía",
        lastName: "Salazar",
        documentType: DocumentType.CC,
        documentNumber: "2001239876",
        phone: "3106677889",
        email: "lucia.derma@gmail.com",
        address: "Cl. 12 #9-10, Bogotá",
        specialty: Speciality.Dermatología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Esteban",
        lastName: "Ruiz",
        documentType: DocumentType.CC,
        documentNumber: "2002239877",
        phone: "3111234455",
        email: "esteban.ruiz@derma.co",
        address: "Av. Oriental 98, Medellín",
        specialty: Speciality.Dermatología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Sara",
        lastName: "Ortiz",
        documentType: DocumentType.CC,
        documentNumber: "2003339878",
        phone: "3001122334",
        email: "sara.ortiz@derma.com",
        address: "Cra. 5 #45-80, Cali",
        specialty: Speciality.Dermatología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Julio",
        lastName: "Mendoza",
        documentType: DocumentType.CC,
        documentNumber: "2004449879",
        phone: "3123344556",
        email: "julio.mendoza@derma.com",
        address: "Cl. 60 #22-11, Cartagena",
        specialty: Speciality.Dermatología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Tatiana",
        lastName: "Vargas",
        documentType: DocumentType.CC,
        documentNumber: "2005559880",
        phone: "3167788990",
        email: "tatiana.vargas@derma.com",
        address: "Av. Boyacá 134, Bogotá",
        specialty: Speciality.Dermatología,
        gender: Gender.Female
    ),

    // 🧠 NEUROLOGÍA
    new Doctor(
        name: "Andrés",
        lastName: "Patiño",
        documentType: DocumentType.CC,
        documentNumber: "3001112223",
        phone: "3159988776",
        email: "andres.patino@neuro.com",
        address: "Cl. 45 #12-30, Bucaramanga",
        specialty: Speciality.Neurología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Carolina",
        lastName: "Morales",
        documentType: DocumentType.CC,
        documentNumber: "3001112224",
        phone: "3114433221",
        email: "carolina.morales@neuro.com",
        address: "Cra. 10 #54-12, Bogotá",
        specialty: Speciality.Neurología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Felipe",
        lastName: "Zamora",
        documentType: DocumentType.CC,
        documentNumber: "3001112225",
        phone: "3177766554",
        email: "felipe.zamora@neuro.com",
        address: "Av. 80 #33-44, Medellín",
        specialty: Speciality.Neurología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Natalia",
        lastName: "Linares",
        documentType: DocumentType.CC,
        documentNumber: "3001112226",
        phone: "3144455667",
        email: "natalia.linares@neuro.com",
        address: "Cl. 13 #8-19, Cali",
        specialty: Speciality.Neurología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Rafael",
        lastName: "Bonilla",
        documentType: DocumentType.CC,
        documentNumber: "3001112227",
        phone: "3126677889",
        email: "rafael.bonilla@neuro.co",
        address: "Cra. 45 #100-25, Cartagena",
        specialty: Speciality.Neurología,
        gender: Gender.Male
    ),

    // 🧒 PEDIATRÍA
    new Doctor(
        name: "Marta",
        lastName: "López",
        documentType: DocumentType.CC,
        documentNumber: "1122334455",
        phone: "3152233445",
        email: "marta@gmail.com",
        address: "Av. Siempre Viva 123, Medellín",
        specialty: Speciality.Pediatría,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Valentina",
        lastName: "Pérez",
        documentType: DocumentType.CC,
        documentNumber: "4001112233",
        phone: "3145566778",
        email: "valentina.perez@pediatria.co",
        address: "Cl. 9 #30-45, Cali",
        specialty: Speciality.Pediatría,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Daniel",
        lastName: "Ospina",
        documentType: DocumentType.CC,
        documentNumber: "4001112234",
        phone: "3189988776",
        email: "daniel.ospina@pediatria.co",
        address: "Cra. 12 #33-10, Bogotá",
        specialty: Speciality.Pediatría,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Camila",
        lastName: "Giraldo",
        documentType: DocumentType.CC,
        documentNumber: "4001112235",
        phone: "3002233445",
        email: "camila.giraldo@pediatria.com",
        address: "Av. Nutibara 88, Medellín",
        specialty: Speciality.Pediatría,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Juan",
        lastName: "Murillo",
        documentType: DocumentType.CC,
        documentNumber: "4001112236",
        phone: "3126677889",
        email: "juan.murillo@pediatria.com",
        address: "Cl. 21 #18-60, Cartagena",
        specialty: Speciality.Pediatría,
        gender: Gender.Male
    ),

    // 🧘 PSIQUIATRÍA
    new Doctor(
        name: "Carlos",
        lastName: "Pérez",
        documentType: DocumentType.CC,
        documentNumber: "5566778899",
        phone: "3029988776",
        email: "carlos@gmail.com",
        address: "Calle 9 #30-45, Bucaramanga",
        specialty: Speciality.Psiquiatría,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Juliana",
        lastName: "Martínez",
        documentType: DocumentType.CC,
        documentNumber: "5001239871",
        phone: "3142233445",
        email: "juliana.martinez@psiquiatria.co",
        address: "Cra. 20 #10-22, Bogotá",
        specialty: Speciality.Psiquiatría,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Sebastián",
        lastName: "Castro",
        documentType: DocumentType.CC,
        documentNumber: "5001239872",
        phone: "3179988776",
        email: "sebastian.castro@psiquiatria.com",
        address: "Cl. 50 #22-33, Medellín",
        specialty: Speciality.Psiquiatría,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Elena",
        lastName: "Quintero",
        documentType: DocumentType.CC,
        documentNumber: "5001239873",
        phone: "3124433221",
        email: "elena.quintero@psiquiatria.co",
        address: "Av. 80 #12-45, Cali",
        specialty: Speciality.Psiquiatría,
        gender: Gender.Female
    ),
    new Doctor(
        name: "David",
        lastName: "Suárez",
        documentType: DocumentType.CC,
        documentNumber: "5001239874",
        phone: "3166677889",
        email: "david.suarez@psiquiatria.co",
        address: "Cl. 7 #21-33, Cartagena",
        specialty: Speciality.Psiquiatría,
        gender: Gender.Male
    ),

    // ☢️ RADIOLOGÍA
    new Doctor(
        name: "Ana",
        lastName: "Ramírez",
        documentType: DocumentType.CC,
        documentNumber: "123456789",
        phone: "3001234567",
        email: "ana@gmail.com",
        address: "Calle 45 #23-12, Bogotá",
        specialty: Speciality.Radiología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Pedro",
        lastName: "Arango",
        documentType: DocumentType.CC,
        documentNumber: "6001112233",
        phone: "3114455667",
        email: "pedro.arango@radio.com",
        address: "Cl. 10 #8-10, Medellín",
        specialty: Speciality.Radiología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Laura",
        lastName: "Rojas",
        documentType: DocumentType.CC,
        documentNumber: "6001112234",
        phone: "3159988776",
        email: "laura.rojas@radio.co",
        address: "Cra. 25 #15-80, Cali",
        specialty: Speciality.Radiología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Andrés",
        lastName: "Vega",
        documentType: DocumentType.CC,
        documentNumber: "6001112235",
        phone: "3106677889",
        email: "andres.vega@radio.com",
        address: "Cl. 19 #8-19, Cartagena",
        specialty: Speciality.Radiología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Mónica",
        lastName: "Durán",
        documentType: DocumentType.CC,
        documentNumber: "6001112236",
        phone: "3167788990",
        email: "monica.duran@radio.co",
        address: "Cra. 9 #12-60, Bogotá",
        specialty: Speciality.Radiología,
        gender: Gender.Female
    ),

    // 🦴 TRAUMATOLOGÍA
    new Doctor(
        name: "Santiago",
        lastName: "Cortés",
        documentType: DocumentType.CC,
        documentNumber: "7001112233",
        phone: "3172233445",
        email: "santiago.cortes@trauma.com",
        address: "Cl. 8 #45-22, Medellín",
        specialty: Speciality.Traumatología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Isabela",
        lastName: "Reyes",
        documentType: DocumentType.CC,
        documentNumber: "7001112234",
        phone: "3147788990",
        email: "isabela.reyes@trauma.com",
        address: "Av. 68 #20-90, Bogotá",
        specialty: Speciality.Traumatología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Fernando",
        lastName: "Cárdenas",
        documentType: DocumentType.CC,
        documentNumber: "7001112235",
        phone: "3152233445",
        email: "fernando.cardenas@trauma.co",
        address: "Cra. 33 #10-55, Cali",
        specialty: Speciality.Traumatología,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Natalia",
        lastName: "Vélez",
        documentType: DocumentType.CC,
        documentNumber: "7001112236",
        phone: "3119988776",
        email: "natalia.velez@trauma.com",
        address: "Cl. 60 #8-20, Barranquilla",
        specialty: Speciality.Traumatología,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Jorge",
        lastName: "Parra",
        documentType: DocumentType.CC,
        documentNumber: "7001112237",
        phone: "3126677889",
        email: "jorge.parra@trauma.com",
        address: "Cl. 11 #18-33, Cartagena",
        specialty: Speciality.Traumatología,
        gender: Gender.Male
    ),

    // 🏥 MEDICINA GENERAL
    new Doctor(
        name: "Eliana",
        lastName: "Romero",
        documentType: DocumentType.CC,
        documentNumber: "8001112233",
        phone: "3101234567",
        email: "eliana.romero@medgen.com",
        address: "Cra. 15 #10-10, Bogotá",
        specialty: Speciality.MedicinaGeneral,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Felipe",
        lastName: "Agudelo",
        documentType: DocumentType.CC,
        documentNumber: "8001112234",
        phone: "3124455667",
        email: "felipe.agudelo@medgen.com",
        address: "Cl. 100 #12-20, Medellín",
        specialty: Speciality.MedicinaGeneral,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Laura",
        lastName: "Jiménez",
        documentType: DocumentType.CC,
        documentNumber: "8001112235",
        phone: "3139988776",
        email: "laura.jimenez@medgen.com",
        address: "Av. 6 #33-45, Cali",
        specialty: Speciality.MedicinaGeneral,
        gender: Gender.Female
    ),
    new Doctor(
        name: "Oscar",
        lastName: "Castaño",
        documentType: DocumentType.CC,
        documentNumber: "8001112236",
        phone: "3156677889",
        email: "oscar.castano@medgen.com",
        address: "Cl. 9 #8-19, Bucaramanga",
        specialty: Speciality.MedicinaGeneral,
        gender: Gender.Male
    ),
    new Doctor(
        name: "Verónica",
        lastName: "Silva",
        documentType: DocumentType.CC,
        documentNumber: "8001112237",
        phone: "3172233445",
        email: "veronica.silva@medgen.com",
        address: "Cra. 80 #22-10, Cartagena",
        specialty: Speciality.MedicinaGeneral,
        gender: Gender.Female
    )
};
internal static void LoadToMainDataBaseDoctor()
        {
            if (DataBase.Doctors.Count == 0)
            {
                DataBase.Doctors.AddRange(ExampleDoctors);
                Console.WriteLine("✅ Doctores de ejemplo cargados en la base de datos.");
            }
            else
            {
                Console.WriteLine("⚠️ La base de datos ya contiene doctores. No se cargaron los ejemplos.");
            }
        }

    }
}        

    





                