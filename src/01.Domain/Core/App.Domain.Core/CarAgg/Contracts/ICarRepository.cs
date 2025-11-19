using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CarAgg.Dtos;

namespace App.Domain.Core.CarAgg.Contracts
{
    public interface ICarRepository
    {
        List<CarModelsDto> GetAll();
        GetCarCompanyDto GetCompany(int carId);
    }
}
