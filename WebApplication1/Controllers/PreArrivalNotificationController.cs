using DpeApi.Helper;
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddPreArrivalNotification([FromForm] RequestPreArrivalNotification model)
        {
            if (model == null)
            {
                return BadRequest("Request data is required.");
            }
            try
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedData");

                // Save PackListPDF
                if (model.PackListPDF != null)
                {
                    var packListResult = await PDFHelper.SavePdf(model.PackListPDF, "PackListPDF", folderPath);
                    if (!packListResult.Success)
                        return BadRequest(packListResult.Message);
                    else
                    {
                        model.PackListPDFName = packListResult.FileName;
                        model.PackListPDF_GUID = packListResult.FileGUID;
                    }
                }

                // Save CheckListPDF
                if (model.CheckListPDF != null)
                {
                    var checkListResult = await PDFHelper.SavePdf(model.CheckListPDF, "CheckListPDF", folderPath);
                    if (!checkListResult.Success)
                        return BadRequest(checkListResult.Message);
                    else
                    {
                        model.CheckListPDFName = checkListResult.FileName;
                        model.CheckListPDF_GUID = checkListResult.FileGUID;
                    }
                }
                var result = await _services.AddPreArrivalNotification(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GETPreArrivalNotificationList")]
        public async Task<IActionResult> GETPreArrivalNotificationList(int? PreArrivalNotificationId)
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
