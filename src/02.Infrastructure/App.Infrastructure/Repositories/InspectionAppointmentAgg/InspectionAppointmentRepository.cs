using App.Domain.Core.CarAgg.Enums;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using App.Domain.Core.InspectionAppointmentAgg.Entities;
using App.Domain.Core.InspectionAppointmentAgg.Enum;
using App.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.ImageAgg.Entities;

namespace App.Infrastructure.EfCore.Repositories.InspectionAppointmentAgg
{
    public class InspectionAppointmentRepository(AppDbContext _context) : IInspectionAppointmentRepository
    {
        public int ChangeAppointmentStatus(int requestId, AppointmentStatusEnum status)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.Id == requestId);
            appointment.Status = status;
            return _context.SaveChanges();
        }

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
                Status = newAppointment.Status,
                CarImages = newAppointment.ImgUrl.Select(url => new CarImage()
                {
                    ImgUrl = url
                }).ToList(),
            };
            _context.Appointments.Add(appointment);
            return _context.SaveChanges();

        }

        public List<ShowAcceptedAppointmentDto> GetAcceptedAppointment(string? dayFilter, CarCompanyEnum? companyFilter)
        {
            var appointments = _context.Appointments.Where(a => a.IsValidRequests == true)
                .Select(x => new ShowAcceptedAppointmentDto()
                {
                    Id = x.Id,
                    OwnersNationalCode = x.OwnersNationalCode,
                    LicensePlate = x.LicensePlate,
                    CarModel = x.CarModel.CarModel,
                    CarCompany = x.CarModel.CarBrand,
                    MobileNumber = x.MobileNumber,
                    TurnTimeShamsi = x.TurnTimeShamsi,
                    YearOfManufactureShamsi = x.YearOfManufactureShamsi,
                    Status = x.Status,
                    Address = x.Address

                });
            if (!string.IsNullOrWhiteSpace(dayFilter))
            {
                appointments = appointments.Where(a => a.TurnTimeShamsi == dayFilter);
            }

            if (companyFilter.HasValue)
            {
                appointments = appointments.Where(a => a.CarCompany == companyFilter);
            }
            

            return appointments.ToList();
        }

        public List<ShowRejectedAppointmentDto> GetRejectedAppointment()
        {
            return _context.Appointments.Where(a => a.IsValidRequests == false)
                .Select(x => new ShowRejectedAppointmentDto()
                {
                    Id = x.Id,
                    OwnersNationalCode = x.OwnersNationalCode,
                    LicensePlate = x.LicensePlate,
                    RejectionReason = x.RejectionReason,
                    CarModel = x.CarModel.CarModel,
                    CarCompany = x.CarModel.CarBrand,
                    MobileNumber = x.MobileNumber,
                    TurnTimeShamsi = x.TurnTimeShamsi,
                    YearOfManufactureShamsi = x.YearOfManufactureShamsi,
                    Address = x.Address
                }).ToList();
        }

        public List<string> GetReserveDays()
        {
            return _context.Appointments
                .Where(a => a.IsValidRequests == true)
                .Select(x => x.TurnTimeShamsi)
                .Distinct().ToList();
        }

        public bool IsPlateRequestedInThisYear(string plate)
        {
            return _context.Appointments
                .Any(a => a.LicensePlate == plate
                                                  && a.TurnTime.Year == DateTime.Now.Year
                                                  && a.IsValidRequests == true);
        }

        public int NumberOfRequestsOfPerDay(string turnDate)
        {
            return _context.Appointments.Where(a => a.TurnTimeShamsi == turnDate 
                                                    && a.IsValidRequests == true).Count();
        }
    }
}
