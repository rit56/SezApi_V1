﻿
using Azure;
using Microsoft.EntityFrameworkCore;
using SezApi.Model;
using SezApi.Model.DBModels;
using SezApi.Model.Response;

namespace SezApi.Data
{
    public class SezApiDbContext : DbContext
    {
        public SezApiDbContext(DbContextOptions<SezApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<test> test { get; set; }
        public DbSet<mststoragecharge> mststoragecharge { get; set; }
        public DbSet<AddEditResponse> AddEditResponse { get; set; }
     
        public DbSet<GetEntry> GetEntryList { get; set; }
        public DbSet<MstOperation> GetMstOperationList { get; set; }
        public DbSet<MstSac> GetMstSac { get; set; }

        public DbSet<ResponseHTCharge> GetHTChargesResponse { get; set; }

        public DbSet<ResponseGroundRentCharge> GetGroundRentChargesResponse { get; set; }

        public DbSet<ResponseReeferCharge> GetReeferChargesResponse { get; set; }

        public DbSet<ResponseMISCCharge> GetMISCChargesResponse { get; set; } 

    }
}
