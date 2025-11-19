using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CarAgg.Enums;

namespace App.Domain.Core.CarAgg.Dtos
{
    public class GetCarCompanyDto
    {
        public CarCompanyEnum CarCompany { get; set; }
    }
}
