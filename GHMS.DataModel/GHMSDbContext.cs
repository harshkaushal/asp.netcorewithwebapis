using GHMS.DataModel.Models.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using GHMS.DataModel.Models;

namespace GHMS.DataModel.Data
{
    public class GHMSDbContext : IdentityDbContext<ApplicationUser>// IdentityDbContext // IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public GHMSDbContext(DbContextOptions<GHMSDbContext> options)
            : base(options)
        {
        }
        #region Transaction Tables
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Hospitals> Hospitals{ get; set; }
         public virtual DbSet<HospitalsAudits> HospitalsAudits { get; set; }
         public virtual DbSet<HospitalUserContacts> HospitalUserContacts { get; set; }
         public virtual DbSet<HospitalUserContactsAudits> HospitalUserContactsAudits { get; set; }
         public virtual DbSet<HospitalUserDetails> HospitalUserDetails { get; set; }
         public virtual DbSet<HospitalUserDetailsAudits> HospitalUserDetailsAudits { get; set; }
         public virtual DbSet<Address> Address { get; set; }
         public virtual DbSet<AddressAudits> AddressAudits { get; set; }
      
        #endregion

        #region Link Tables
        public virtual DbSet<LnkHospitalUserAddress> LnkHospitalUserAddress { get; set; }
        public virtual DbSet<LnkHospitalUserAddressAudits> LnkHospitalUserAddressAudits { get; set; }
        #endregion

        #region Look-UP Tables

        public virtual DbSet<LuContactTypes> LuContactTypes { get; set; }
         public virtual DbSet<LuContactTypesAudits> LuContactTypesAudits { get; set; }
         public virtual DbSet<LuCountries> LuCountries { get; set; }
         public virtual DbSet<LuCountriesAudits> LuCountriesAudits { get; set; }
         public virtual DbSet<LuStates> LuStates { get; set; }
         public virtual DbSet<LuStatesAudits> LuStatesAudits { get; set; }
         public virtual DbSet<LuCities> LuCities { get; set; }
         public virtual DbSet<LuCitiesAudits> LuCitiesAudits { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Stored Procedures
            //modelBuilder.Entity<LuContactTypes>()
            //    .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertStudent").Parameter(pm => pm.StudentName, "name").Result(rs => rs.StudentId, "Id"))
            //        .Update(sp => sp.HasName("sp_UpdateStudent").Parameter(pm => pm.StudentName, "name"))
            //        .Delete(sp => sp.HasName("sp_DeleteStudent").Parameter(pm => pm.StudentId, "Id"))
            //    );
            #endregion

            #region Default Value
            //modelBuilder.Entity<Billing>()
            //    .Property(b => b.MinAmtUsed)
            //    .HasDefaultValue(true);



            #endregion
            #region Seed Default Data

            modelBuilder.Entity<LuContactTypes>().HasData(
               new { Id = 1, Name = "Phone Number", Description = "Phone Number", IsActive = true, LastUpdateDate = DateTime.Now },
               new { Id = 2, Name = "Email", Description = "Email", IsActive = true, LastUpdateDate = DateTime.Now });
            #endregion

        }
    }
}
