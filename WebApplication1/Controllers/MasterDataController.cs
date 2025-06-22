using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SezApi.Data;
using SezApi.Model.DBModels;
using SezApi.Model.Request;
using SezApi.Model.Response;
using SezApi.Services;
using System.Text;

namespace SezApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterDataController : Controller
    {
        private readonly IServices _services;
        public MasterDataController(IServices services)
        {
            _services = services;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetMstOperation")]
        public async Task<ActionResult<List<MstOperation>>> GetMstOperation()
        {

            var response = await _services.GetMstOperation();

            if (response.Data == null || !response.Data.Any())
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }

        [HttpGet("GetMstSacByOperation")]
        public async Task<ActionResult<List<MstSac>>> GetMstSacByOperation(int SacId)
        {

            var response = await _services.GetMstSacByOperation(SacId);

            if (response.Data == null )
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
    }
}
