using App.Domain.Core.CarAgg.Enums;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using App.Domain.Core.InspectionAppointmentAgg.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.InspectionAppointmentAgg.Contracts
{
    public interface IInspectionAppointmentRepository
    {
        int CreateInspectionAppointment(CreateAppointmentDto newAppointment);
        int NumberOfRequestsOfPerDay(string turnDate);
        bool IsPlateRequestedInThisYear(string plate);
        List<ShowAcceptedAppointmentDto> GetAcceptedAppointment(string? dayFilter, CarCompanyEnum? companyFilter);
        List<ShowRejectedAppointmentDto> GetRejectedAppointment();
        int ChangeAppointmentStatus(int requestId, AppointmentStatusEnum status);
        List<string> GetReserveDays();
    }
}
