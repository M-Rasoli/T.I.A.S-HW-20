using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CarAgg.Enums;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using App.Domain.Core.InspectionAppointmentAgg.Enum;

namespace App.Domain.Services.InspectionAppointmentAgg
{
    public class InspectionAppointmentService(IInspectionAppointmentRepository appointmentRepository) : IInspectionAppointmentService
    {
        public int ChangeAppointmentStatus(int requestId, AppointmentStatusEnum status)
        {
            return appointmentRepository.ChangeAppointmentStatus(requestId, status);
        }

        public int CreateInspectionAppointment(CreateAppointmentDto newAppointment)
        {
            return appointmentRepository.CreateInspectionAppointment(newAppointment);
        }

        public List<ShowAcceptedAppointmentDto> GetAcceptedAppointment(string? dayFilter, CarCompanyEnum? companyFilter)
        {
            return appointmentRepository.GetAcceptedAppointment(dayFilter, companyFilter);
        }

        public List<ShowRejectedAppointmentDto> GetRejectedAppointment()
        {
            return appointmentRepository.GetRejectedAppointment();
        }

        public List<string> GetReserveDays()
        {
            return appointmentRepository.GetReserveDays();
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
