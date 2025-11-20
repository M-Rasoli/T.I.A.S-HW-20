using App.Domain.Core._Common.Entities;
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
    public interface IInspectionAppointmentAppService
    {
        Result<bool> CreateInspectionAppointment(CreateAppointmentDto newAppointment);
        List<ShowAcceptedAppointmentDto> GetAcceptedAppointment(string? dayFilter, CarCompanyEnum? companyFilter);
        Result<bool> ChangeAppointmentStatus(int requestId, AppointmentStatusEnum status);
        List<string> GetReserveDays();
        List<ShowRejectedAppointmentDto> GetRejectedAppointment();
    }
}
