using Citas.Models;
using Citas.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Citas.Interfaces
{
    internal interface IAppointmentRepository
    {
        // 🔹 Ahora el método es asíncrono y devuelve una Task
        Task AddAppointment(Appointment appointment);

        Appointment? GetAppointmentById(Guid id);
        List<Appointment> GetAllAppointments();
        void RemoveAppointment(Guid id);
        void UpdateAppointment(Appointment appointment);
        void ShowAllAppointments();
    }
        

}
