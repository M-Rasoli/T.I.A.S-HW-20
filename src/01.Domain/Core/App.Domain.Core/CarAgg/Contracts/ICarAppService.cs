using App.Domain.Core._Common.Entities;
using App.Domain.Core.CarAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CarAgg.Contracts
{
    public interface ICarAppService
    {
        List<CarModelsDto> GetAll();

    }
}
