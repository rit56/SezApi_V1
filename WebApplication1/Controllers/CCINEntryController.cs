using DpeApi.Model.Request;
using DpeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DpeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CCINEntryController : Controller
    {
        private readonly IServices _services;
        public CCINEntryController(IServices services)
        {
            _services = services;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddCCINEntry")]
        public async Task<IActionResult> AddCCINEntry(RequestCCINEntry request)
        {
            if (request == null)
            {
                return BadRequest("Request data is required.");
            }
            try
            {
                var result = await _services.AddCCINEntry(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GETCCINEntryList")]
        public async Task<IActionResult> GETCCINEntryList(int? CCINEntryId)
        {

            try
            {
                var result = await _services.GETCCINEntryList(CCINEntryId);
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
