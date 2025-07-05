using DpeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DpeApi.Controllers
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

        #region Operation

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

        #endregion

        #region Sac

        [HttpGet("GetMstSacAll")]
        public async Task<ActionResult<List<MstSac>>> GetMstSacAll()
        {

            var response = await _services.GetMstSacAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region Commodity


        [HttpGet("GetCommodityAll")]
        public async Task<ActionResult<List<MstCommodity>>> GetCommodityAll()
        {

            var response = await _services.GetMstCommodityAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region ReferenceNo
        [HttpGet("GetReferenceNoAll")]
        public async Task<ActionResult<List<MstReferenceNo>>> GetReferenceNoAll()
        {

            var response = await _services.GetReferenceNoAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region ShippingLine


        [HttpGet("GetShippingLineAll")]
        public async Task<ActionResult<List<MstShippingLine>>> GetShippingLineAll()
        {

            var response = await _services.GetShippingLineAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region CHA


        [HttpGet("GetCHAAll")]
        public async Task<ActionResult<List<MstCHA>>> GetCHAAll()
        {

            var response = await _services.GetCHAAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region CFS


        [HttpGet("GetCFSCodeAll")]
        public async Task<ActionResult<List<MstCHA>>> GetCFSAll()
        {

            var response = await _services.GetCFSCodeAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region CargoType


        [HttpGet("GetCargoTypeAll")]
        public async Task<ActionResult<List<MstCargoType>>> GetCargoTypeAll()
        {

            var response = await _services.GetCargoTypeAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region LoadType


        [HttpGet("GetLoadTypeAll")]
        public async Task<ActionResult<List<MstLoadType>>> GetLoadTypeAll()
        {

            var response = await _services.GetLoadTypeAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region Package Type


        [HttpGet("GetPackageTypeAll")]
        public async Task<ActionResult<List<MstPackageType>>> GetPackageTypeAll()
        {

            var response = await _services.GetPackageTypeAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region Equipment Seal Type


        [HttpGet("GetEquipmentSealTypeAll")]
        public async Task<ActionResult<List<MstEquipmentSealType>>> GetEquipmentSealTypeAll()
        {

            var response = await _services.GetEquipmentSealTypeAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region Equipment Status

        [HttpGet("GetEquipmentStatusAll")]
        public async Task<ActionResult<List<MstEquipmentStatus>>> GetEquipmentStatusAll()
        {

            var response = await _services.GetEquipmentStatusAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region Equipment QUC


        [HttpGet("GetEquipmentQUCAll")]
        public async Task<ActionResult<List<MstEquipmentQUC>>> GetEquipmentQUCAll()
        {

            var response = await _services.GetEquipmentQUCAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

        #region Pack UQC


        [HttpGet("GetPackUQCAll")]
        public async Task<ActionResult<List<MstPackUQC>>> GetPackUQCAll()
        {

            var response = await _services.GetPackUQCAll();

            if (response.Data == null)
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
        #endregion

    }
}
