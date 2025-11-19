using App.Domain.Core.CarAgg.Entities;
using App.Domain.Core.InspectionAppointmentAgg.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.InspectionAppointmentAgg.Entities
{
    public class InspectionAppointment
    {
        public int Id{ get; set; }
        public string OwnersNationalCode { get; set; }
        public string LicensePlate { get; set; }
        public Car CarModel { get; set; }
        public int CarModelId { get; set; }
        public string MobileNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public string YearOfManufactureShamsi { get; set; }
        public DateTime TurnTime { get; set; }
        public string TurnTimeShamsi { get; set; }
        public string Address { get; set; }
        public bool IsValidRequests { get; set; }
        public string? RejectionReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public AppointmentStatusEnum Status { get; set; } 
    }
}
