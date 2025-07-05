using DpeApi.Model.DBModels;
using DpeApi.Model.Request;
using DpeApi.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace DpeApi.Services
{
    public interface IServices 
    {
        Task AddTest(test product);
        Task<AddEditResponse> AddMststorageCharge(RequestMststorageCharge mststorageCharge);
        Task<Response<List<mststoragecharge>>> GetMststorageCharge();
        Task<AddEditResponse> AddEditGetEntry(RequestGetEntry request);
        Task<Response<List<GetEntry>>> GetAllEntries();
        Task<Response<List<MstOperation>>> GetMstOperation();
        Task<Response<MstSac>> GetMstSacByOperation(int SacId);//
        Task<Response<List<MstSac>>> GetMstSacAll();
        Task<Response<List<MstCommodity>>> GetMstCommodityAll();
        Task<Response<List<MstReferenceNo>>> GetReferenceNoAll();
        Task<Response<List<MstShippingLine>>> GetShippingLineAll();

        Task<Response<List<MstCHA>>> GetCHAAll();
        Task<Response<List<MstCFSCode>>> GetCFSCodeAll();


        Task<Response<List<MstLoadType>>> GetLoadTypeAll();
        Task<Response<List<MstCargoType>>> GetCargoTypeAll();
        Task<Response<List<MstPackageType>>> GetPackageTypeAll();
        Task<Response<List<MstEquipmentSealType>>> GetEquipmentSealTypeAll();
        Task<Response<List<MstEquipmentStatus>>> GetEquipmentStatusAll();
        Task<Response<List<MstEquipmentQUC>>> GetEquipmentQUCAll();
        Task<Response<List<MstPackUQC>>> GetPackUQCAll();
       
        Task<AddEditResponse> AddHTCharge(RequestHTCharge HTCharge);
        Task<Response<List<ResponseHTCharge>>> GetHTCharge(int? HTChargesID);

        #region GroundRentCharge
        Task<AddEditResponse> AddGroundRentCharge(RequestGroundRentCharge GRCharge);
        Task<Response<List<ResponseGroundRentCharge>>> GetGroundRentCharge(int? GroundRentID);
        #endregion

        #region ReeferCharge
        Task<AddEditResponse> AddReeferCharge(RequestReeferCharge RFCharge);
        Task<Response<List<ResponseReeferCharge>>> GetReeferCharge(int? ReeferChrgId);
        #endregion

        #region MISCCharge
        Task<AddEditResponse> AddMISCCharge(RequestMISCCharge MISCCharge);
        Task<Response<List<ResponseMISCCharge>>> GetMISCCharge(int? MiscellaneousId);
        #endregion

        #region PreArrivalNotification
        Task<AddEditResponse> AddPreArrivalNotification(RequestPreArrivalNotification PreArr);
        Task<Response<List<ResponsePreArrivalNotification>>> GetPreArrivalNotification(int? PreArrID);
        #endregion

        #region GetIN
        Task<AddEditResponse> AddGateIn(RequestGetIn PreArr);
        Task<Response<List<ResponseGetIn>>> GETGateInList(int? PreArrID);
        #endregion

        #region CCINEntry
        Task<AddEditResponse> AddCCINEntry(RequestCCINEntry CCINEntry);
        Task<Response<List<ResponseCCINEntry>>> GETCCINEntryList(int? CCINEntryId);
        #endregion

    }
}
