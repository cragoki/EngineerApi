using Shared.Models;

namespace Shared.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task AddAppointment(AppointmentModel model);
        Task<AppointmentModel> GetAppointment(int id);
        Task<List<AppointmentModel>> GetAppointments();
        Task<List<AppointmentModel>> GetAppointmentsForEngineer(int engineerId);
        List<string> GetAppointmentStatuses();
        List<KeyValueModel> GetAppointmentStatusesAndIds();
        Task UpdateAppointment(AppointmentModel model);
    }
}