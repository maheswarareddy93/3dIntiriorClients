using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CustomerInfo> customerInfo { get; set; }
        public DbSet<AdminsInfo> AdminsInfo { get; set; }
        public DbSet<ProjectDataInfo> ProjectDataInfo { get; set; }

        public DbSet<PropertyTypes> PropertyTypes { get; set; }

        public DbSet<GallaryImages> GallaryImages { get; set; }

        public DbSet<RoomTypes> RoomTypes { get; set; }
    }
}
