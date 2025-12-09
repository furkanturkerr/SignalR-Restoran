using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;
        public MoneyCasesController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }
        
        [HttpGet("MoneyCaseTotalPrice")]
        public IActionResult MoneyCaseTotalPrice()
        {
            return Ok(_moneyCaseService.TMoneyCaseTotalPrice());
        }
    }
}
