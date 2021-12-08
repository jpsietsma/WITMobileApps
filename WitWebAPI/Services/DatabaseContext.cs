using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WacMobile.Models.Farm;
using WacMobile.Models.Participant;
using WitWebAPI.Models;

namespace WitWebAPI.Services
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<SiteUserModel> SiteUser { get; set; }
        public virtual DbSet<ParticipantDetailsViewModel> Contact { get; set; }
        public virtual DbSet<FarmDetailsViewModel> Farm { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
