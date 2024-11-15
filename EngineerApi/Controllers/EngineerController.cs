using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Services;
using Shared.Services.Interfaces;

namespace EngineerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EngineerController : ControllerBase
    {
        private readonly IEngineerService _engineerService;

        public EngineerController(IEngineerService engineerService) 
        {
            _engineerService = engineerService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<EngineerModel>> GetEngineers()
        {
            return await _engineerService.GetEngineers();
        }
    }
}
