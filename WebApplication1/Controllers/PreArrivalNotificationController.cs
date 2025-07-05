using DpeApi.Model.Request;
using DpeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DpeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreArrivalNotificationController : Controller
    {
        private readonly IServices _services;
        public PreArrivalNotificationController(IServices services)
        {
            _services = services;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddPreArrivalNotification")]
        public async Task<IActionResult> AddPreArrivalNotification(RequestPreArrivalNotification request)
        {
            if (request == null)
            {
                return BadRequest("Request data is required.");
            }
            try
            {
                var result = await _services.AddPreArrivalNotification(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GETPreArrivalNotificationList")]
        public async Task<IActionResult> GETPreArrivalNotificationList(int? GroundRentId)
        {

            try
            {
                var result = await _services.GetPreArrivalNotification(GroundRentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
