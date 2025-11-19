using App.Domain.Core.CarAgg.Entities;
using App.Domain.Core.CarAgg.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.EfCore.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CarModel).IsRequired().HasMaxLength(400);
            builder.HasMany(c => c.Appointments).WithOne(ai => ai.CarModel)
                .HasForeignKey(ai => ai.CarModelId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(c => c.CarBrand).HasConversion<string>();

            builder.HasData(new List<Car>(){
                    // ایران‌خودرو
                    new Car { Id = 2, CarModel = "پژو 207", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 3, CarModel = "پژو 405", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 4, CarModel = "پژو پارس", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 5, CarModel = "سمند ال‌ایکس", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 1, CarModel = "پژو 206", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 6, CarModel = "سمند سورن", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 7, CarModel = "دنا", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 8, CarModel = "دنا پلاس", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 9, CarModel = "رانا", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 10, CarModel = "رانا پلاس", CarBrand = CarCompanyEnum.IranKhodro, CreatedAt = new DateTime(2024, 1, 1) },

                    // سایپا
                    new Car { Id = 11, CarModel = "پراید 111", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 12, CarModel = "پراید 131", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 13, CarModel = "پراید 132", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 14, CarModel = "تیبا", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 15, CarModel = "تیبا 2", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 16, CarModel = "ساینا", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 17, CarModel = "ساینا اس", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 18, CarModel = "کوییک", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 19, CarModel = "کوییک آر", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) },
                    new Car { Id = 20, CarModel = "شاهین", CarBrand = CarCompanyEnum.Saipa, CreatedAt = new DateTime(2024, 1, 1) }
                    });

        }
    }
}
