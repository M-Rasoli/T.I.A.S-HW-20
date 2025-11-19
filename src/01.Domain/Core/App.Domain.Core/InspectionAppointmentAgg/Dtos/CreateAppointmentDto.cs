using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CarAgg.Enums;

namespace App.Domain.Core.InspectionAppointmentAgg.Dtos
{
    public class CreateAppointmentDto
    {
        public string OwnersNationalCode { get; set; }
        public string LicensePlate { get; set; }
        public int CarModelId { get; set; }
        public CarCompanyEnum CarCompany { get; set; }
        public string MobileNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public int YearOfManufactureShamsi { get; set; }
        public DateTime TurnTime { get; set; }
        public string TurnTimeShamsi { get; set; }
        public string DayOfWeekShamsi { get; set; }
        public string Address { get; set; }
        public bool IsValidRequests { get; set; }
        public string? RejectionReason { get; set; }

    }
}
