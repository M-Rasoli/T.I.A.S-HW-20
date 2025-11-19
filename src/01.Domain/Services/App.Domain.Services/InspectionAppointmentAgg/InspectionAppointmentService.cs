using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;

namespace App.Domain.Services.InspectionAppointmentAgg
{
    public class InspectionAppointmentService(IInspectionAppointmentRepository appointmentRepository) : IInspectionAppointmentService
    {
        public int CreateInspectionAppointment(CreateAppointmentDto newAppointment)
        {
            return appointmentRepository.CreateInspectionAppointment(newAppointment);
        }

        public bool IsPlateRequestedInThisYear(string plate)
        {
            return appointmentRepository.IsPlateRequestedInThisYear(plate);
        }

        public int NumberOfRequestsOfPerDay(string turnDate)
        {
            return appointmentRepository.NumberOfRequestsOfPerDay(turnDate);
        }
    }
}
