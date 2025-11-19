using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using App.Domain.Core.InspectionAppointmentAgg.Entities;
using App.Domain.Core.InspectionAppointmentAgg.Enum;
using App.Infrastructure.Persistence;

namespace App.Infrastructure.EfCore.Repositories.InspectionAppointmentAgg
{
    public class InspectionAppointmentRepository(AppDbContext _context) : IInspectionAppointmentRepository
    {
        public int CreateInspectionAppointment(CreateAppointmentDto newAppointment)
        {
            var appointment = new InspectionAppointment()
            {
                OwnersNationalCode = newAppointment.OwnersNationalCode,
                LicensePlate = newAppointment.LicensePlate,
                CarModelId = newAppointment.CarModelId,
                MobileNumber = newAppointment.MobileNumber,
                YearOfManufacture = newAppointment.YearOfManufacture,
                YearOfManufactureShamsi = newAppointment.YearOfManufactureShamsi.ToString(),
                TurnTime = newAppointment.TurnTime,
                TurnTimeShamsi = newAppointment.TurnTimeShamsi,
                Address = string.IsNullOrEmpty(newAppointment.Address) ? "-" : newAppointment.Address,
                IsValidRequests = newAppointment.IsValidRequests,
                RejectionReason = newAppointment.RejectionReason,
                CreatedAt = DateTime.Now,
                Status = AppointmentStatusEnum.Pending
            };
            _context.Appointments.Add(appointment);
            return _context.SaveChanges();

        }

        public bool IsPlateRequestedInThisYear(string plate)
        {
            return _context.Appointments
                .Any(a => a.LicensePlate == plate
                                                  && a.TurnTime.Year == DateTime.Now.Year);
        }

        public int NumberOfRequestsOfPerDay(string turnDate)
        {
            return _context.Appointments.Where(a => a.TurnTimeShamsi == turnDate).Count();
        }
    }
}
