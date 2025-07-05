
using Azure;
using Microsoft.EntityFrameworkCore;
using DpeApi.Model;
using DpeApi.Model.DBModels;
using DpeApi.Model.Response;

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
        
        public DbSet<ResponseHTCharge> GetHTChargesResponse { get; set; }

        public DbSet<ResponseGroundRentCharge> GetGroundRentChargesResponse { get; set; }

        public DbSet<ResponseReeferCharge> GetReeferChargesResponse { get; set; }

        public DbSet<ResponseMISCCharge> GetMISCChargesResponse { get; set; } 

    }
}
