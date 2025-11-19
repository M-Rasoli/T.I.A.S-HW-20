using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._Common.Entities;
using App.Domain.Core.CarAgg.Contracts;
using App.Domain.Core.CarAgg.Dtos;

namespace App.Domain.AppService.CarAgg
{
    public class CarAppService(ICarService carService) : ICarAppService
    {
        public List<CarModelsDto> GetAll()
        {
            return carService.GetAll();
            
        }
    }
}
