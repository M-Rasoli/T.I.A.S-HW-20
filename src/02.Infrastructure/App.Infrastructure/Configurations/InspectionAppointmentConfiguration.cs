using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.InspectionAppointmentAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EfCore.Configurations
{
    public class InspectionAppointmentConfiguration : IEntityTypeConfiguration<InspectionAppointment>
    {
        public void Configure(EntityTypeBuilder<InspectionAppointment> builder)
        {
            builder.HasKey(ia => ia.Id);

            builder.Property(ia => ia.LicensePlate).IsRequired().HasMaxLength(20);
            builder.Property(ia => ia.OwnersNationalCode).IsRequired().HasMaxLength(100);
            builder.Property(ia => ia.MobileNumber).IsRequired().HasMaxLength(20);
            builder.Property(ia => ia.YearOfManufacture).IsRequired().HasMaxLength(20);
            builder.Property(ia => ia.CarModelId).IsRequired();
            builder.Property(ia => ia.TurnTime).IsRequired();
            builder.Property(ia => ia.YearOfManufacture).IsRequired();

            builder.Property(ia => ia.Status).HasConversion<string>();

            builder.HasMany(a => a.CarImages).WithOne(i => i.Appointment)
                .HasForeignKey(i => i.AppointmentId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
