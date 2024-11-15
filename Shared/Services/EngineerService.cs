using DAL.Repositories.Interfaces;
using Shared.Models;
using Shared.Services.Interfaces;

namespace Shared.Services
{
    public class EngineerService : IEngineerService
    {
        private readonly IEngineerRepository _repository;
        public EngineerService(IEngineerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EngineerModel>> GetEngineers()
        {
            var result = new List<EngineerModel>();

            try
            {
                var entities = await _repository.GetAllAsync();

                //Could use Automapper or something here
                result = entities.Select(x => new EngineerModel()
                {
                    Id = x.Id,
                    Name = x.Name
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
