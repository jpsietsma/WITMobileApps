using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WacMobileModels.Address;
using WacMobileModels.Authentication;
using WacMobileModels.Farm;
using WacMobileModels.Participant;

namespace WitWebAPI.Services
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<SiteUserModel> SiteUser { get; set; }
        public virtual DbSet<ParticipantDetailsViewModel> Contact { get; set; }
        public virtual DbSet<FarmDetailsViewModel> Farm { get; set; }
        public virtual DbSet<AddressModel> Address { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Section: Address Modelbuilder Entries
            modelBuilder.Entity<AddressModel>().HasKey(a => a.addID);
            #endregion

            #region Section: Farm ModelBuilder Entries
            modelBuilder.Entity<FarmDetailsViewModel>()
                .HasOne(a => a.farmPrimaryAddress);

            modelBuilder.Entity<FarmDetailsViewModel>()
                .HasOne(p => p.farmParticipantProducer);

            #endregion

            #region Section: Participant/Contact ModelBuilder Entries
            modelBuilder.Entity<ParticipantDetailsViewModel>()
                .HasOne(a => a.conAddress);
            #endregion
        }
    }
}
