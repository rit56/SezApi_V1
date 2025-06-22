using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SezApi.Data;
using SezApi.Model.DBModels;
using SezApi.Model.Request;
using SezApi.Model.Response;
using SezApi.Services;

namespace SezApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HTChargesController : Controller
    {
        private readonly IServices _services;

        public HTChargesController(IServices services)
        {
            _services = services;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("AddHTCharge")]
        public async Task<IActionResult> AddHTCharge(RequestHTCharge request)
        {
            if (request == null)
            {
                return BadRequest("Request data is required.");
            }
            try
            {
                var result = await _services.AddHTCharge(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GETHTChargeList")]
        public async Task<IActionResult> GETHTChargeList(int? HTChargesID)
        {
            
            try
            {
                var result = await _services.GetHTCharge(HTChargesID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
