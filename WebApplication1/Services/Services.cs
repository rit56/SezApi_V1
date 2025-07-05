
using Microsoft.EntityFrameworkCore;
using DpeApi.Data;
using DpeApi.Model.DBModels;
using DpeApi.Model.Request;
using DpeApi.Model.Response;
using System.Linq;
namespace DpeApi.Services
{
    public class Services : IServices
    {
        private readonly DpeApiDbContext _db;

        public Services(DpeApiDbContext db)
        {
            _db = db;
        }

        public async Task AddTest(test product)
        {
            try
            {
                _db.test.Add(product);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<AddEditResponse> AddMststorageCharge(RequestMststorageCharge mststorageCharge)
        {
            var response = new AddEditResponse();
            try
            {
                var result = await _db.AddEditResponse
                    .FromSqlInterpolated($@"
                EXEC SP_AddMstStorageCharge
                    {mststorageCharge.StorageChargeId},
                    {mststorageCharge.BranchId},
                    {mststorageCharge.WarehouseType},
                    {mststorageCharge.ChargeType},
                    {mststorageCharge.RateSqMPerWeek},
                    {mststorageCharge.RateSqMeterPerMonth},
                    {mststorageCharge.RateMeterPerDay},
                    {mststorageCharge.RateCubMeterPerDay},
                    {mststorageCharge.RateCubMeterPerWeek},
                    {mststorageCharge.RateCubMeterPerMonth},
                    {mststorageCharge.EffectiveDate},
                    {mststorageCharge.DaysRangeFrom},
                    {mststorageCharge.DaysRangeTo},
                    {mststorageCharge.SacCode},
                    {mststorageCharge.CommodityType},
                    {mststorageCharge.CreatedBy},
                    {mststorageCharge.CreatedOn},
                    {mststorageCharge.UpdatedBy},
                    {mststorageCharge.UpdatedOn},
                    {mststorageCharge.SurCharge}
            ").ToListAsync();

                response.Response = result.FirstOrDefault()?.Response ?? "No response";
            }
            catch (Exception ex)
            {
                response.Response = "Some error occurred";
            }

            return response;
        }

        public async Task<Response<List<mststoragecharge>>> GetMststorageCharge()
        {
            var response = new Response<List<mststoragecharge>>();
            try
            {
                var result = await _db.mststoragecharge.ToListAsync();
                response.Data = result;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<mststoragecharge>();
                response.Status = false;
            }

            return response;
        }

        public async Task<AddEditResponse> AddEditGetEntry(RequestGetEntry request)
        {
            try
            {
                var result = await _db.AddEditResponse
    .FromSqlInterpolated($@"
        EXEC dbo.Sp_AddEditGetEntry 
            @EntryId = {request.EntryId},
            @CFSCode = {request.CFSCode},
            @GateInNo = {request.GateInNo},
            @EntryDateTime = {request.EntryDateTime},
            @ReferenceNo = {request.ReferenceNo},
            @ReferenceDate = {request.ReferenceDate},
            @ShippingLineId = {request.ShippingLineId},
            @ShippingLine = {request.ShippingLine},
            @CHAName = {request.CHAName},
            @ContainerNo = {request.ContainerNo},
            @Size = {request.Size},
            @Reefer = {(request.Reefer.HasValue ? (request.Reefer.Value ? 1 : 0) : (int?)null)},
            @CustomSealNo = {request.CustomSealNo},
            @ShippingLineSealNo = {request.ShippingLineSealNo},
            @VehicleNo = {request.VehicleNo},
            @ChallanNo = {request.ChallanNo},
            @CargoDescription = {request.CargoDescription},
            @CargoType = {request.CargoType},
            @NoOfPackages = {request.NoOfPackages},
            @GrossWeight = {request.GrossWeight},
            @DepositorName = {request.DepositorName},
            @Remarks = {request.Remarks},
            @TransportMode = {request.TransportMode},
            @ContainerLoadType = {request.ContainerLoadType},
            @TransportFrom = {(request.TransportFrom.HasValue ? request.TransportFrom.ToString() : null)},
            @CreatedBy = {request.CreatedBy},
            @CreatedOn = {request.CreatedOn},
            @UpdatedBy = {request.UpdatedBy},
            @UpdatedOn = {request.UpdatedOn},
            @ContainerNo1 = {request.ContainerNo1},
            @BranchId = {request.BranchId},
            @FormOneDetailId = {request.FormOneDetailId},
            @ContainerType = {request.ContainerType},
            @OperationType = {request.OperationType},
            @DisplayCfs = {request.DisplayCfs},
            @CHAId = {request.CHAId},
            @CBT = {request.CBT},
            @TPNo = {request.TPNo},
            @SystemDateTime = {request.SystemDateTime},
            @TareWeight = {request.TareWeight},
            @MsgFlag = {request.MsgFlag},
            @ActualPackages = {request.ActualPackages},
            @FileName = {request.FileName},
            @FileCode = {request.FileCode}
            ")
            .AsNoTracking()
            .ToListAsync();

                var response = result.FirstOrDefault();

                return response ?? new AddEditResponse { Response = "No response" };
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("Failed to execute Sp_AddEditGetEntry", ex);
            }
        }

        public async Task<Response<List<GetEntry>>> GetAllEntries()
        {
            var response = new Response<List<GetEntry>>();

            try
            {
                var result = await _db.GetEntryList.ToListAsync();
                response.Data = result;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<GetEntry>();
                response.Status = false;
            }

            return response;
        }


        public async Task<Response<List<MstOperation>>> GetMstOperation()
        {
            var response = new Response<List<MstOperation>>();

            try
            {
                var result = await _db.GetMstOperationList.ToListAsync();
                response.Data = result;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<MstOperation>();
                response.Status = false;
            }

            return response;
        }
        public async Task<Response<MstSac>> GetMstSacByOperation(int SacId)
        {

            var response = new Response<MstSac>();

            try
            {
                //var resultOpsList = await _db.GetMstOperationList.ToListAsync();
                //int SacId = resultOpsList.Where(x => x.OperationId == OperationId).Select(x=>x.SacId).FirstOrDefault();

                var resultSacList = await _db.GetMstSac.ToListAsync();
                var result = resultSacList.Where(x => x.SacId == SacId).FirstOrDefault();

                response.Data = result;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new MstSac();
                response.Status = false;
            }

            return response;
        }

        public async Task<Response<List<MstSac>>> GetMstSacAll()
        {
            var response = new Response<List<MstSac>>();

            try
            {
                
                response.Data = await _db.GetMstSac.ToListAsync();
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<MstSac>();
                response.Status = false;
            }

            return response;
        }
        public async Task<Response<List<MstCommodity>>> GetMstCommodityAll()
        {
            var response = new Response<List<MstCommodity>>();

            try
            {

                response.Data = await _db.GetMstCommodity.ToListAsync();
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<MstCommodity>();
                response.Status = false;
            }

            return response;
        }
       
        public async Task<Response<List<MstReferenceNo>>> GetReferenceNoAll()
        {
            var response = new Response<List<MstReferenceNo>>();

            try
            {
                response.Data = await _db.GetMstReferenceNo.ToListAsync();
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<MstReferenceNo>();
                response.Status = false;
            }

            return response;
        }
   
        public async Task<Response<List<MstShippingLine>>> GetShippingLineAll()
        {
            var response = new Response<List<MstShippingLine>>();

            try
            {
                response.Data = await _db.GetMstShippingLine.ToListAsync();
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<MstShippingLine>();
                response.Status = false;
            }

            return response;
        }

        public async Task<Response<List<MstCHA>>> GetCHAAll()
        {
            var response = new Response<List<MstCHA>>();

            try
            {
                response.Data = await _db.GetMstCHA.ToListAsync();
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<MstCHA>();
                response.Status = false;
            }

            return response;
        }
       

        public async Task<AddEditResponse> AddHTCharge(RequestHTCharge HTCharge)
        {
            var response = new AddEditResponse();
            try
            {
                var result = await _db.AddEditResponse
                    .FromSqlInterpolated($@"
                EXEC SP_AddHTCharge 
                    {HTCharge.HTChargesID},
                    {HTCharge.OperationId},
                    {HTCharge.SacCodeId},
                    {HTCharge.Size},
                    {HTCharge.Rate},
                    {HTCharge.EffectiveDate},
                    {HTCharge.CreatedBy},
                    {HTCharge.UpdatedBy}
            ").ToListAsync();

                response.Response = result.FirstOrDefault()?.Response ?? "No response";
            }
            catch (Exception ex)
            {
                response.Response = "Some error occurred";
            }

            return response;
        }
        public async Task<Response<List<ResponseHTCharge>>> GetHTCharge(int? HTChargesID)
        {
            var response = new Response<List<ResponseHTCharge>>();

            try
            {
                var result = await _db.GetHTChargesResponse
                    .FromSqlInterpolated($@"
                EXEC SP_GetHTChargeList 
                {HTChargesID}
                ").ToListAsync();

                response.Data = result;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<ResponseHTCharge>();
                response.Status = false;
            }

            return response;
        }
        #region GroundRentCharge
        public async Task<AddEditResponse> AddGroundRentCharge(RequestGroundRentCharge GRCharge)
        {
            var response = new AddEditResponse();
            try
            {
                var result = await _db.AddEditResponse
                    .FromSqlInterpolated($@"
                EXEC SP_AddGroundRentCharge 
                    {GRCharge.GroundRentId},
                    {GRCharge.EffectiveDate},
                    {GRCharge.SacCodeId},
                    {GRCharge.DaysRangeFrom},
                    {GRCharge.DaysRangeTo},
                    {GRCharge.ContainerType},
                    {GRCharge.CommodityType},
                    {GRCharge.Size},
                    {GRCharge.FclLcl},
                    {GRCharge.RentAmount},
                    {GRCharge.OperationType},
                    {GRCharge.CreatedBy},
                    {GRCharge.UpdatedBy}
            ").ToListAsync();

                response.Response = result.FirstOrDefault()?.Response ?? "No response";
            }
            catch (Exception ex)
            {
                response.Response = "Some error occurred";
            }

            return response;
        }

        public async Task<Response<List<ResponseGroundRentCharge>>> GetGroundRentCharge(int? GroundRentId)
        {
            var response = new Response<List<ResponseGroundRentCharge>>();

            try
            {
                var result = await _db.GetGroundRentChargesResponse
                    .FromSqlInterpolated($@"
                EXEC SP_GetGroundRentChargeList 
                {GroundRentId}
                ").ToListAsync();

                response.Data = result;
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = new List<ResponseGroundRentCharge>();
                response.Status = false;
            }

            return response;
        }
        #endregion

        #region ReeferCharge
        public async Task<AddEditResponse> AddReeferCharge(RequestReeferCharge RFCharge)
        {
            var response = new AddEditResponse();

            try
            {
                var result = await _db.AddEditResponse
                    .FromSqlInterpolated($@"
                EXEC SP_AddEditReeferCharge 
                    {RFCharge.ReeferChrgId},
                    {RFCharge.SacCodeId},
                    {RFCharge.EffectiveDate},
                    {RFCharge.Hours},
                    {RFCharge.Size},
                    {RFCharge.Rate},
                    {RFCharge.CreatedBy},
                    {RFCharge.UpdatedBy}")
                    .ToListAsync();

                response.Response = result.FirstOrDefault()?.Response ?? "No response from stored procedure.";
            }
            catch (Exception ex)
            {
                // Optional: Log the exception
                // _logger.LogError(ex, "SP_AddHTCharge failed");
                response.Response = "An unexpected error occurred while processing the request.";
            }

            return response;
        }

        public async Task<Response<List<ResponseReeferCharge>>> GetReeferCharge(int? ReeferChrgId)
        {
            var response = new Response<List<ResponseReeferCharge>>();
            try
            {
                var data = await _db.GetReeferChargesResponse
                    .FromSqlInterpolated($"EXEC SP_GetReeferChargeList {ReeferChrgId}")
                    .ToListAsync();

                return new Response<List<ResponseReeferCharge>>
                {
                    Data = data,
                    Status = true
                };
            }
            catch (Exception ex)
            {
                return new Response<List<ResponseReeferCharge>>
                {
                    Data = [],
                    Status = false
                };
            }
        }
        #endregion

        #region MISCCharge
        public async Task<AddEditResponse> AddMISCCharge(RequestMISCCharge MISCCharge)
        {
            var response = new AddEditResponse();

            try
            {
                var result = await _db.AddEditResponse
                    .FromSqlInterpolated($@"
                EXEC Sp_AddEditMiscCharge 
                    {MISCCharge.MiscellaneousId},
                    {MISCCharge.EffectiveDate},
                    {MISCCharge.SacCodeId},
                    {MISCCharge.OperationId},
                    {MISCCharge.Size},
                    {MISCCharge.Rate},
                    {MISCCharge.CreatedBy},
                    {MISCCharge.UpdatedBy}")
                    .ToListAsync();

                response.Response = result.FirstOrDefault()?.Response ?? "No response from stored procedure.";
            }
            catch (Exception ex)
            {
                // Optional: Log the exception
                // _logger.LogError(ex, "SP_AddHTCharge failed");
                response.Response = "An unexpected error occurred while processing the request.";
            }

            return response;
        }

        public async Task<Response<List<ResponseMISCCharge>>> GetMISCCharge(int? MiscellaneousId)
        {
            var response = new Response<List<ResponseMISCCharge>>();
            try
            {
                var data = await _db.GetMISCChargesResponse
                    .FromSqlInterpolated($"EXEC SP_GetMISCChargeList {MiscellaneousId}")
                    .ToListAsync();

                return new Response<List<ResponseMISCCharge>>
                {
                    Data = data,
                    Status = true
                };
            }
            catch (Exception ex)
            {
                return new Response<List<ResponseMISCCharge>>
                {
                    Data = [],
                    Status = false
                };
            }
        }
        #endregion

        #region PreArrivalNotification
  
        public async Task<AddEditResponse> AddPreArrivalNotification(RequestPreArrivalNotification PreArr)
        {
            var response = new AddEditResponse();
            try
            {
                var result = await _db.AddEditResponse
                    .FromSqlInterpolated($@"
                EXEC SP_AddPreArrivalNotification 
                    {PreArr.PreArrivalNotificationId},
                    {PreArr.PreArrivalDate},
                    {PreArr.PreArrivalNo},
	                {PreArr.ContainerNo},
	                {PreArr.Size},
	                {PreArr.Type},
	                {PreArr.WTKg},
	                {PreArr.Value},
	                {PreArr.Commodity},
	                {PreArr.ExpectedArrivalDate},
	                {PreArr.ExpectedArrivalTime},
                    {PreArr.CreatedBy},
                    {PreArr.UpdatedBy}
					
            ").ToListAsync();

                response.Response = result.FirstOrDefault()?.Response ?? "No response";
            }
            catch (Exception ex)
            {
                response.Response = "Some error occurred";
            }

            return response;
        }

        public async Task<Response<List<ResponsePreArrivalNotification>>> GetPreArrivalNotification(int? PreArrivalNotificationId)
        {
            var response = new Response<List<ResponsePreArrivalNotification>>();

            try
            {

                var data = await _db.GetPreArrivalNotificationResponse
                   .FromSqlInterpolated($"EXEC SP_GetPreArrivalNotificationList {PreArrivalNotificationId}")
                   .ToListAsync();


                return new Response<List<ResponsePreArrivalNotification>>
                {
                    Data = data,
                    Status = true
                };

               
            }
            catch (Exception ex)
            {
                response.Data = new List<ResponsePreArrivalNotification>();
                response.Status = false;
            }

            return response;
        }
        #endregion

        #region GetIn
        public async Task<AddEditResponse> AddGateIn(RequestGetIn getIn)
        {
            var response = new AddEditResponse();
            try
            {
                var result = await _db.AddEditResponse
                    .FromSqlInterpolated($@"
                EXEC SP_AddGetIn 
                    {getIn.GetInId} ,
	                {getIn.CFSCode} ,
	                {getIn.RefNo} ,
	                {getIn.EntryDate},
	                {getIn.EntryTime},
	                {getIn.SystemDate},
	                {getIn.SystemTime},
	                {getIn.ContainerNo},
	                {getIn.CustomSealNo},
	                {getIn.Size},
	                {getIn.ShippingLine},
	                {getIn.CHA},
                    {getIn.CreatedBy},
                    {getIn.UpdatedBy}
					
            ").ToListAsync();

                response.Response = result.FirstOrDefault()?.Response ?? "No response";
            }
            catch (Exception ex)
            {
                response.Response = "Some error occurred";
            }

            return response;
        }

        public async Task<Response<List<ResponseGetIn>>> GETGateInList(int? PreArrivalNotificationId)
        {
            var response = new Response<List<ResponseGetIn>>();

            try
            {

                var data = await _db.GetGetIn
                   .FromSqlInterpolated($"EXEC SP_GetGetinList {PreArrivalNotificationId}")
                   .ToListAsync();


                return new Response<List<ResponseGetIn>>
                {
                    Data = data,
                    Status = true
                };


            }
            catch (Exception ex)
            {
                response.Data = new List<ResponseGetIn>();
                response.Status = false;
            }

            return response;
        }
        #endregion
        
    }
}
