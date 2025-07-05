using DpeApi.Model.DBModels;
using DpeApi.Model.Request;
using DpeApi.Model.Response;

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

    }
}
