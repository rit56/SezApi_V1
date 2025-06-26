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
    public class CWCChargesController : Controller
    {
        private readonly IServices _services;

        public CWCChargesController(IServices services)
        {
            _services = services;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }

        #region Ground Rent Charge
        [HttpPost("AddGroundRentCharge")]
        public async Task<IActionResult> AddGroundRentCharge(RequestGroundRentCharge request)
        {
            if (request == null)
            {
                return BadRequest("Request data is required.");
            }
            try
            {
                var result = await _services.AddGroundRentCharge(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GETGroundRentChargeList")]
        public async Task<IActionResult> GETGroundRentChargeList(int? GroundRentId)
        {

            try
            {
                var result = await _services.GetGroundRentCharge(GroundRentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region Refer Charge
        [HttpPost("AddReferCharge")]
        public async Task<IActionResult> AddReferCharge(RequestReeferCharge request)
        {
            if (request == null)
            {
                return BadRequest("Request data is required.");
            }
            try
            {
                var result = await _services.AddReeferCharge(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GETReferChargeList")]
        public async Task<IActionResult> GETReferChargeList(int? ReeferChrgId)
        {
            try
            {
                var result = await _services.GetReeferCharge(ReeferChrgId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region MISC Charge sahom
        [HttpPost("AddMISCCharge")]
        public async Task<IActionResult> AddMISCCharge(RequestMISCCharge request)
        {
            if (request == null)
            {
                return BadRequest("Request data is required.");
            }
            try
            {
                var result = await _services.AddMISCCharge(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GETMISCChargeList")]
        public async Task<IActionResult> GETMISCChargeList(int? MiscellaneousId)
        {

            try
            {
                var result = await _services.GetMISCCharge(MiscellaneousId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion
    }
}
