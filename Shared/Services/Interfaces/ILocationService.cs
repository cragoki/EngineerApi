using Shared.Models;

namespace Shared.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationModel>> GetLocations();
    }
}