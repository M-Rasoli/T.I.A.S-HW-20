using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;

namespace App.Domain.Core.InspectionAppointmentAgg.Contracts
{
    public interface IInspectionAppointmentRepository
    {
        int CreateInspectionAppointment(CreateAppointmentDto newAppointment);
        int NumberOfRequestsOfPerDay(string turnDate);
        bool IsPlateRequestedInThisYear(string plate);
    }
}
