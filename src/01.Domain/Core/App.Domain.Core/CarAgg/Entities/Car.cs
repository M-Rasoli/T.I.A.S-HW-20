using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CarAgg.Enums;
using App.Domain.Core.InspectionAppointmentAgg.Entities;

namespace App.Domain.Core.CarAgg.Entities
{
    public class Car
    {
        public int Id{ get; set; }
        public string CarModel { get; set; }
        public CarCompanyEnum CarBrand { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<InspectionAppointment> Appointments { get; set; }
    }
}
