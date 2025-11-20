using App.Domain.Core.CarAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.InspectionAppointmentAgg.Dtos
{
    public class ShowRejectedAppointmentDto
    {
        public int Id { get; set; }
        public string OwnersNationalCode { get; set; }
        public string LicensePlate { get; set; }
        public string CarModel { get; set; }
        public CarCompanyEnum CarCompany { get; set; }
        public string MobileNumber { get; set; }
        public string YearOfManufactureShamsi { get; set; }
        public string TurnTimeShamsi { get; set; }
        public string Address { get; set; }
        public bool IsValidRequests { get; set; }
        public string? RejectionReason { get; set; }
    }
}
