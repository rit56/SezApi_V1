
using Azure;
using Microsoft.EntityFrameworkCore;
using DpeApi.Model;
using DpeApi.Model.DBModels;
using DpeApi.Model.Response;
using DpeApi.Model.Request;

namespace DpeApi.Data
{
    public class DpeApiDbContext : DbContext
    {
        public DpeApiDbContext(DbContextOptions<DpeApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<test> test { get; set; }
        public DbSet<mststoragecharge> mststoragecharge { get; set; }
        public DbSet<AddEditResponse> AddEditResponse { get; set; }   
        public DbSet<GetEntry> GetEntryList { get; set; }
        public DbSet<MstOperation> GetMstOperationList { get; set; }
        public DbSet<MstSac> GetMstSac { get; set; }
        public DbSet<MstCommodity> GetMstCommodity { get; set; }
        public DbSet<MstReferenceNo> GetMstReferenceNo { get; set; }
        public DbSet<MstShippingLine> GetMstShippingLine { get; set; }
        public DbSet<MstCHA> GetMstCHA { get; set; }
        public DbSet<MstCFSCode> GetCFSCode { get; set; }
        public DbSet<MstCargoType> GetCargoType { get; set; }
        public DbSet<MstLoadType> GetLoadType { get; set; }
        public DbSet<MstPackageType> GetPackageType { get; set; }
        public DbSet<MstEquipmentSealType> GetEquipmentSealType { get; set; }
        public DbSet<MstEquipmentStatus> GetEquipmentStatus { get; set; }
        public DbSet<MstEquipmentQUC> GetEquipmentQUC { get; set; }
        public DbSet<MstPackUQC> GetPackUQC { get; set; }





        public DbSet<ResponseHTCharge> GetHTChargesResponse { get; set; }
        public DbSet<ResponseGroundRentCharge> GetGroundRentChargesResponse { get; set; }
        public DbSet<ResponseReeferCharge> GetReeferChargesResponse { get; set; }
        public DbSet<ResponseMISCCharge> GetMISCChargesResponse { get; set; }
        public DbSet<ResponsePreArrivalNotification> GetPreArrivalNotificationResponse { get; set; }
        public DbSet<ResponseGetIn> GetGetIn { get; set; }
        public DbSet<ResponseCCINEntry> GetCCINEntry { get; set; }

    }
}
