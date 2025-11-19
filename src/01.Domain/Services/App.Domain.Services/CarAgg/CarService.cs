using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CarAgg.Contracts;
using App.Domain.Core.CarAgg.Dtos;

namespace App.Domain.Services.CarAgg
{
    public class CarService(ICarRepository carRepository) : ICarService
    {
        public List<CarModelsDto> GetAll()
        {
            return carRepository.GetAll();
        }

        public GetCarCompanyDto GetCompany(int carId)
        {
            return carRepository.GetCompany(carId);
        }
    }
}
