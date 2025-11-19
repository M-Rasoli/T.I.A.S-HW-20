using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.AdminAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EfCore.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.UserName).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Password).IsRequired().HasMaxLength(200);

            builder.HasData(new List<Admin>()
            {
                new Admin(){Id = 1 , UserName = "mmd", Password = "123" , CreatedAt = new DateTime(2024,12,12,12,12,12,12,DateTimeKind.Local)},
            });
        }
    }
}
