using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services.Interfaces;

namespace EngineerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<LocationModel>> GetLocations()
        {
            return await _locationService.GetLocations();
        }
    }
}
