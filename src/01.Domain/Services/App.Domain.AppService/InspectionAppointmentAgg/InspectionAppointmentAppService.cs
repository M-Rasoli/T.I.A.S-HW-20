using App.Domain.Core._Common.Entities;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CarAgg.Contracts;
using App.Domain.Core.CarAgg.Enums;
using App.Domain.Core.InspectionAppointmentAgg.Enum;

namespace App.Domain.AppService.InspectionAppointmentAgg
{
    public class InspectionAppointmentAppService(
        IInspectionAppointmentService appointmentService 
        , ICarService carService) :
        IInspectionAppointmentAppService
    {
        public Result<bool> ChangeAppointmentStatus(int requestId, AppointmentStatusEnum status)
        {
            var result = appointmentService.ChangeAppointmentStatus(requestId, status);
            if (result > 0)
            {
                return Result<bool>.Success(message: "وضعیت با موفقیت تغییر یافت .");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده لحظاتی بعد تلاش کنید.");
            }
        }

        public Result<bool> CreateInspectionAppointment(CreateAppointmentDto newAppointment)
        {

            if (!CheckLifespanOfCar(newAppointment.YearOfManufacture))
            {
                newAppointment.IsValidRequests = false;
                newAppointment.RejectionReason = "طول عمر خودرو بیشتر از 5 سال.";
                newAppointment.Status = AppointmentStatusEnum.Denied;
                var rs = appointmentService.CreateInspectionAppointment(newAppointment);
                return Result<bool>.Failure(message: "طول عمر خودرو شما بیشتر از 5 سال است.");
            }
            if (appointmentService.IsPlateRequestedInThisYear(newAppointment.LicensePlate))
            {
                newAppointment.IsValidRequests = false;
                newAppointment.RejectionReason = "درخواست دوباره معاینه فنی در یک سال .";
                newAppointment.Status = AppointmentStatusEnum.Denied;
                var rs = appointmentService.CreateInspectionAppointment(newAppointment);
                return Result<bool>.Failure(message: "هر پلاک فقط یکبار در سال می تواند در خواست معاینه فنی بدهد.");
            }

            var dayOfWeek = CheckTurnDate(newAppointment.TurnTimeShamsi);
            var carCompany = carService.GetCompany(newAppointment.CarModelId);

            if (dayOfWeek == "Friday")
            {
                newAppointment.IsValidRequests = false;
                newAppointment.RejectionReason = "درخواست نوبت در روز تعطیل.";
                newAppointment.Status = AppointmentStatusEnum.Denied;
                var rs = appointmentService.CreateInspectionAppointment(newAppointment);
                return Result<bool>.Failure(message:"روز جمعه مجموعه تعطیل می باشد.");
            }
            if (dayOfWeek == "Odd" && carCompany.CarCompany == CarCompanyEnum.IranKhodro)
            {
                newAppointment.IsValidRequests = false;
                newAppointment.RejectionReason = "درخواست معاینه فنی خودرو ,ایران خودرو در روز فرد.";
                newAppointment.Status = AppointmentStatusEnum.Denied;
                var rs = appointmentService.CreateInspectionAppointment(newAppointment);
                return Result<bool>.Failure(message:"خودرو های شرکت ایرانخودرو فقط در روز های زوج پذیرش می شوند.");
            }
            if (dayOfWeek == "Even" && carCompany.CarCompany == CarCompanyEnum.Saipa)
            {
                newAppointment.IsValidRequests = false;
                newAppointment.RejectionReason = "درخواست معاینه فنی خودرو سایپا در روز زوج.";
                newAppointment.Status = AppointmentStatusEnum.Denied;
                var rs = appointmentService.CreateInspectionAppointment(newAppointment);
                return Result<bool>.Failure(message: "خودرو های شرکت سایپا فقط در روز های فرد پذیرش می شوند.");
            }

            var numberOfRequests = appointmentService.NumberOfRequestsOfPerDay(newAppointment.TurnTimeShamsi);
            if (numberOfRequests >= 10 && dayOfWeek == "Odd")
            {
                newAppointment.IsValidRequests = false;
                newAppointment.RejectionReason = "تعداد درخواست ها در تاریخ به حداکثر رسیده است.";
                newAppointment.Status = AppointmentStatusEnum.Denied;
                var rs = appointmentService.CreateInspectionAppointment(newAppointment);
                return Result<bool>.Failure(message:"در روز های فرد بیشتر از 10 خودرو پذیرش نمی شوند.");
            }
            if (numberOfRequests >= 15 && dayOfWeek == "Even")
            {
                newAppointment.IsValidRequests = false;
                newAppointment.RejectionReason = "تعداد درخواست ها در تاریخ به حداکثر رسیده است.";
                newAppointment.Status = AppointmentStatusEnum.Denied;
                var rs = appointmentService.CreateInspectionAppointment(newAppointment);
                return Result<bool>.Failure(message: "در روز های زوج بیشتر از 15 خودرو پذیرش نمی شوند.");
            }


            newAppointment.IsValidRequests = true;
            newAppointment.Status = AppointmentStatusEnum.Pending;
            var result = appointmentService.CreateInspectionAppointment(newAppointment);
            if (result > 0)
            {
                return Result<bool>.Success(message: "درخواست شما با موفقیت ثبت شد .");
            }
            else
            {
                return Result<bool>.Failure(message: "مشکلی پیش آمده لحظاتی بعد تلاش کنید.");
            }
        }

        public List<ShowAcceptedAppointmentDto> GetAcceptedAppointment(string? dayFilter,CarCompanyEnum? companyFilter)
        {
            return appointmentService.GetAcceptedAppointment(dayFilter, companyFilter);
        }

        public List<ShowRejectedAppointmentDto> GetRejectedAppointment()
        {
            return appointmentService.GetRejectedAppointment();
        }

        public List<string> GetReserveDays()
        {
            return appointmentService.GetReserveDays();
        }

        private bool CheckLifespanOfCar(int yearOfManufacture)
        {
            var Lifespan = DateTime.Now.Year - yearOfManufacture;
            if (Lifespan > 5)
            {
                return false;
            }
            return true;
        }
        private string CheckTurnDate(string turnTimeShamsi)
        {
            var pc = new PersianCalendar();
            
            var parts = turnTimeShamsi.Split('/');
            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);
            
            DateTime dt = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
            //var ss = pc.GetDayOfWeek(dt);

            int persianDayIndex = ((int)dt.DayOfWeek + 1) % 7;
            // حالا:
            // 0 = شنبه
            // 1 = یکشنبه
            // 2 = دوشنبه
            // 3 = سه‌شنبه
            // 4 = چهارشنبه
            // 5 = پنجشنبه
            // 6 = جمعه

            switch (persianDayIndex)
            {
                case 0:
                    return "Even";
                case 1:
                    return "Odd";
                case 2:
                    return "Even";
                case 3:
                    return "Odd";
                case 4:
                    return "Even";
                case 5:
                    return "Odd";
                case 6:
                    return "Friday";
                default:
                    return "Friday";
            }

            //var dayOfWeek = dt.DayOfWeek;

            //if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Wednesday)
            //{
            //    return "Even";
            //}
            //else if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Tuesday || dayOfWeek == DayOfWeek.Thursday)
            //{
            //    return "Odd";
            //}
            //else
            //{
            //    return "Friday";
            //}
        }
    }
}
