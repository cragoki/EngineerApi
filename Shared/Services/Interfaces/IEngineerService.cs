using Shared.Models;

namespace Shared.Services.Interfaces
{
    public interface IEngineerService
    {
        Task<List<EngineerModel>> GetEngineers();
    }
}