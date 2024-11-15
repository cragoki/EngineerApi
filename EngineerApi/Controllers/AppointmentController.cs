using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services.Interfaces;

namespace EngineerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService) 
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<AppointmentModel>> GetAppointments() 
        {
            return await _appointmentService.GetAppointments();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<AppointmentModel>> GetAppointmentsForEngineer(int engineerId)
        {
            return await _appointmentService.GetAppointmentsForEngineer(engineerId);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<AppointmentModel> GetAppointment(int id)
        {
            return await _appointmentService.GetAppointment(id);
        }

        [HttpGet]
        [Route("[action]")]
        public List<string> GetAppointmentStatuses()
        {
            return _appointmentService.GetAppointmentStatuses();
        }

        [HttpGet]
        [Route("[action]")]
        public List<KeyValueModel> GetAppointmentStatusesAndIds()
        {
            return _appointmentService.GetAppointmentStatusesAndIds();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task AddAppointment(AppointmentModel model)
        {
            await _appointmentService.AddAppointment(model);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task UpdateAppointment(AppointmentModel model)
        {
            await _appointmentService.UpdateAppointment(model);
        }
    }
}
