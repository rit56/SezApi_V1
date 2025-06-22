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
        public async Task<IActionResult> GETGroundRentChargeList(int? HTChargesID)
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
        #endregion

        #region Refer Charge
        [HttpPost("AddReferCharge")]
        public async Task<IActionResult> AddReferCharge(RequestHTCharge request)
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
        [HttpGet("GETReferChargeList")]
        public async Task<IActionResult> GETReferChargeList(int? HTChargesID)
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
        #endregion

        //#region MISC Charge
        //[HttpPost("AddMISCCharge")]
        //public async Task<IActionResult> AddMISCCharge(RequestHTCharge request)
        //{
        //    if (request == null)
        //    {
        //        return BadRequest("Request data is required.");
        //    }
        //    try
        //    {
        //        var result = await _services.AddHTCharge(request);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
        //[HttpGet("GETMISCChargeList")]
        //public async Task<IActionResult> GETMISCChargeList(int? HTChargesID)
        //{

        //    try
        //    {
        //        var result = await _services.GetHTCharge(HTChargesID);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
        //#endregion
    }
}
