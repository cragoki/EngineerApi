using DAL.Repositories.Interfaces;
using Shared.Models;
using Shared.Services.Interfaces;

namespace Shared.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;
        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LocationModel>> GetLocations()
        {
            var result = new List<LocationModel>();

            try
            {
                var entities = await _repository.GetAllAsync();

                //Could use Automapper or something here
                result = entities.Select(x => new LocationModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Xordinate = x.Xordinate,
                    Yordinate = x.Yordinate,
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
