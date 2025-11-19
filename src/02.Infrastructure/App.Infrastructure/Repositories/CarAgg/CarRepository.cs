using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CarAgg.Contracts;
using App.Domain.Core.CarAgg.Dtos;
using App.Infrastructure.Persistence;

namespace App.Infrastructure.EfCore.Repositories.CarAgg
{
    public class CarRepository(AppDbContext _context) : ICarRepository
    {
        public List<CarModelsDto> GetAll()
        {
            return _context.Cars.Select(x => new CarModelsDto()
            {
                Id = x.Id,
                CarModel = x.CarModel,
                CarBrand = x.CarBrand
                
            }).ToList();
        }

        public GetCarCompanyDto GetCompany(int carId)
        {
            return _context.Cars.Where(c => c.Id == carId)
                .Select(x => new GetCarCompanyDto()
                {
                    CarCompany = x.CarBrand
                }).FirstOrDefault();
        }
    }
}
