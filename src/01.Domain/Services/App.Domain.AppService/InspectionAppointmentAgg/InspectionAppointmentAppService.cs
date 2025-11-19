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

namespace App.Domain.AppService.InspectionAppointmentAgg
{
    public class InspectionAppointmentAppService(IInspectionAppointmentService appointmentService , ICarService carService) : IInspectionAppointmentAppService
    {
        public Result<bool> CreateInspectionAppointment(CreateAppointmentDto newAppointment)
        {

            if (!CheckLifespanOfCar(newAppointment.YearOfManufacture))
            {
                newAppointment.IsValidRequests = false;
                newAppointment.RejectionReason = "طول عمر خودرو بیشتر از 5 سال.";

                return Result<bool>.Failure(message: "طول عمر ماشین شما بیشتر از 5 سال است.");
            }
            if (appointmentService.IsPlateRequestedInThisYear(newAppointment.LicensePlate))
            {
                return Result<bool>.Failure(message: "هر پلاک فقط یکبار در سال می تواند در خواست معاینه فنی بدهد.");
            }

            var dayOfWeek = CheckTurnDate(newAppointment.TurnTimeShamsi);
            var carCompany = carService.GetCompany(newAppointment.CarModelId);

            if (dayOfWeek == "Friday")
            {
                return Result<bool>.Failure(message:"روز جمعه مجموعه تعطیل می باشد.");
            }
            if (dayOfWeek == "Odd" && carCompany.CarCompany == CarCompanyEnum.IranKhodro)
            {
                return Result<bool>.Failure(message:"ماشین های شرکت ایرانخودرو فقط در روز های زوج پذیرش می شوند.");
            }
            if (dayOfWeek == "Even" && carCompany.CarCompany == CarCompanyEnum.Saipa)
            {
                return Result<bool>.Failure(message: "ماشین های شرکت سایپا فقط در روز های فرد پذیرش می شوند.");
            }

            var numberOfRequests = appointmentService.NumberOfRequestsOfPerDay(newAppointment.TurnTimeShamsi);
            if (numberOfRequests >= 10 && dayOfWeek == "Odd")
            { 
                return Result<bool>.Failure(message:"در روز های فرد بیشتر از 10 ماشین پذیرش نمی شوند.");
            }
            if (numberOfRequests >= 15 && dayOfWeek == "Even")
            {
                return Result<bool>.Failure(message: "در روز های زوج بیشتر از 15 ماشین پذیرش نمی شوند.");
            }


            newAppointment.IsValidRequests = true;
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

        private bool CheckLifespanOfCar(int yearOfManufacture)
        {
            var Lifespan = DateTime.Now.Year - yearOfManufacture;//2002-2004
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

            int persianDayIndex = ((int)dt.DayOfWeek + 1) % 7;
            // حالا:
            // 0 = شنبه
            // 1 = یکشنبه
            // 2 = دوشنبه
            // 3 = سه‌شنبه
            // 4 = چهارشنبه
            // 5 = پنجشنبه
            // 6 = جمعه

            return persianDayIndex switch
            {
                0 => "Even",    // شنبه → زوج؟ نه! برعکسش کنی یا طبق منطقت
                1 => "Odd",   // یکشنبه
                2 => "Even",    // دوشنبه
                3 => "Odd",   // سه‌شنبه
                4 => "Even",    // چهارشنبه
                5 => "Odd",   // پنجشنبه
                6 => "Friday", // جمعه
                _ => "Friday"
            };
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
