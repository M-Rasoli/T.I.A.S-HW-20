using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._Common.Entities;

namespace App.Domain.Core.InspectionAppointmentAgg.Contracts
{
    public interface IInspectionAppointmentAppService
    {
        Result<bool> CreateInspectionAppointment(CreateAppointmentDto newAppointment);
    }
}
