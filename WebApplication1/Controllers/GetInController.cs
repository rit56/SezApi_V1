using DpeApi.Model.Request;
using DpeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DpeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetInController : Controller
    {
        private readonly IServices _services;
        public GetInController(IServices services)
        {
            _services = services;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("AddGetIn")]
        public async Task<IActionResult> AddGetIn(RequestPreArrivalNotification request)
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
        [HttpGet("GETGetInList")]
        public async Task<IActionResult> GETGetInList(int? PreArrivalNotificationId)
        {

            try
            {
                var result = await _services.GetPreArrivalNotification(PreArrivalNotificationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
