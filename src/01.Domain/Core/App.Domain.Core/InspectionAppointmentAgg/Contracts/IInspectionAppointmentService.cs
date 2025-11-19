using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.InspectionAppointmentAgg.Contracts
{
    public interface IInspectionAppointmentService
    {
        int CreateInspectionAppointment(CreateAppointmentDto newAppointment);
        int NumberOfRequestsOfPerDay(string turnDate);
        bool IsPlateRequestedInThisYear(string plate);
    }
}
