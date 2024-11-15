using DAL.Entities;
using DAL.Enums;
using DAL.Repositories.Interfaces;
using Shared.Helpers;
using Shared.Models;
using Shared.Services.Interfaces;

namespace Shared.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AppointmentModel>> GetAppointments()
        {
            var result = new List<AppointmentModel>();

            try
            {
                var entities = await _repository.GetAllAsync();

                //Could use Automapper or something here
                result = entities.Select(x => new AppointmentModel()
                {
                    Id = x.Id,
                    EngineerName = x.EngineerEntity.Name,
                    EngineerId = x.EngineerId,
                    LocationId = x.LocationId,
                    LocationName = x.LocationEntity.Name,
                    Date = x.Date.Date,
                    Status = EnumHelper.GetEnumDescription(x.Status)
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<List<AppointmentModel>> GetAppointmentsForEngineer(int engineerId)
        {
            var result = new List<AppointmentModel>();

            try
            {
                var entities = await _repository.FindAsync(x => x.EngineerId == engineerId);

                if (entities == null || entities.Count() == 0)
                {
                    return result;
                }
                //Could use Automapper or something here
                result = entities.Select(x => new AppointmentModel()
                {
                    Id = x.Id,
                    EngineerName = x.EngineerEntity.Name,
                    EngineerId = x.EngineerId,
                    LocationId = x.LocationId,
                    LocationName = x.LocationEntity.Name,
                    Date = x.Date.Date,
                    Status = x.Status.ToString()
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<AppointmentModel> GetAppointment(int id)
        {
            try
            {
                var entity = await _repository.GetAsync(id);

                if (entity == null) 
                {
                    throw new Exception($"Could not find appointment with identifier {id}.");
                }
                //Could use Automapper or something here
                return new AppointmentModel()
                {
                    Id = entity.Id,
                    EngineerName = entity.EngineerEntity.Name,
                    EngineerId = entity.EngineerId,
                    LocationId = entity.LocationId,
                    LocationName = entity.LocationEntity.Name,
                    Date = entity.Date,
                    Status = entity.Status.ToString()
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddAppointment(AppointmentModel model)
        {
            try
            {
                await _repository.AddAsync(new Appointment()
                {
                    EngineerId = model.EngineerId,
                    LocationId = model.LocationId,
                    Date = model.Date,
                    Status = AppointmentStatusType.Pending
                });

                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAppointment(AppointmentModel model)
        {
            try
            {
                _repository.Update(new Appointment()
                {
                    Id = model.Id,
                    EngineerId = model.EngineerId,
                    LocationId = model.LocationId,
                    Date = model.Date,
                    Status = Enum.Parse<AppointmentStatusType>(model.Status.Replace(" ", ""))
                });

                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetAppointmentStatuses() 
        {
            var result = new List<string>();

            try
            {
                result = EnumHelper.GetEnumDescriptions<AppointmentStatusType>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public List<KeyValueModel> GetAppointmentStatusesAndIds()
        {
            var result = new List<KeyValueModel>();

            try
            {
                result = EnumHelper.GetEnumKeyValues<AppointmentStatusType>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
