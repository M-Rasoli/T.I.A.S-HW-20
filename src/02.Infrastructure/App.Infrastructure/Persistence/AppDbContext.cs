using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.AdminAgg.Entities;
using App.Domain.Core.CarAgg.Entities;
using App.Domain.Core.ImageAgg.Entities;
using App.Domain.Core.InspectionAppointmentAgg.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<InspectionAppointment> Appointments { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
    }
}
