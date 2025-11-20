using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.InspectionAppointmentAgg.Entities;

namespace App.Domain.Core.ImageAgg.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public InspectionAppointment Appointment { get; set; }
        public int AppointmentId { get; set; }
        public string ImgUrl { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
