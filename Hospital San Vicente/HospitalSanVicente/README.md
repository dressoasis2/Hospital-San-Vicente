# Hospital San Vicente

Medical Appointment Management System

---

## Description
This project is a C# console application for managing medical appointments at Hospital San Vicente. It allows you to register, consult, update, and delete appointments, as well as manage doctor and patient information. It includes email confirmation using SendGrid.

## Main Features
- Register new medical appointments
- View all appointments
- Search appointments by ID, patient, or doctor
- Update and delete appointments
- Manage doctors and patients
- Send email confirmations
- Validate doctor availability and specialty

## Project Structure
```
HospitalSanVicente.csproj
HospitalSanVicente.sln
Program.cs
bin/
data/
  DataBase.cs
  DoctorDataBase.cs
  PatientDataBase.cs
Interfaces/
  IAppointmentRepository.cs
  IDoctorRepository.cs
  IPatientsRepository.cs
Menus/
  AppointmentMenu.cs
  DoctorMenu.cs
  MainMenu.cs
  PatientMenu.cs
models/
  Appointment.cs
  Doctor.cs
  Patients.cs
  person.cs
  Enum/
    AppointmentStatus.cs
    DocumentType.cs
    Gender.cs
    Speciality.cs
obj/
Repositories/
  AppointmentRepository.cs
  DoctorRepository.cs
  PatientRepository.cs
Services/
  AppointmentServices.cs
  Doctor.cs
  PatientServices.cs
```

## Installation and Execution
1. Clone the repository or copy the files to your local environment.
2. Install the required dependencies:
   ```bash
   dotnet add package SendGrid
   ```
3. Set the environment variable `SENDGRID_API_KEY` for email sending.
4. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```

## Usage
When you run the application, you will see a main menu with the following options:
- Register new appointment
- View all appointments
- Search appointment by ID
- Search appointments by patient
- Search appointments by doctor
- Update appointment
- Delete appointment
- Return to main menu

Follow the on-screen instructions to interact with the system.

## Technologies Used
- C# (.NET 8)
- SendGrid (for email sending)
- Object-oriented programming

## Important Notes
- The SendGrid API Key must be set as an environment variable for security.
- The system validates dates, times, and doctor availability.
- Data is stored in in-memory lists (simulated database).

## Authors
- Hospital San Vicente Development Team

## License
This project is for internal and educational use. You may adapt it as needed.

---

Thank you for using the Hospital San Vicente appointment management system!
