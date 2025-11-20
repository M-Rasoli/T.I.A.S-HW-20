using App.Domain.Core.CarAgg.Contracts;
using App.Domain.Core.CarAgg.Dtos;
using App.Domain.Core.CarAgg.Enums;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using App.Domain.Core.InspectionAppointmentAgg.Enum;
using App.EndPoints.Presentation.MVC.Tools;
using App.EndPoints.Presentation.Razorpage.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices.JavaScript;
using App.Infrastructure.FileService.Contracts;

namespace App.EndPoints.Presentation.Razorpage.Pages.InspectionAppointment
{
    public class CreateAppointmentModel
    {
        public string OwnersNationalCode { get; set; }
        public string LicensePlate { get; set; }
        public int CarModelId { get; set; }
        public CarCompanyEnum CarCompany { get; set; }
        public string MobileNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public int YearOfManufactureShamsi { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public DateTime TurnTime { get; set; }
        public string TurnTimeShamsi { get; set; }
        public string Address { get; set; }
    } 
    public class AddModel
    (IInspectionAppointmentAppService appointmentAppService 
        , ICarAppService carAppService
        , IFileService fileService)
        : PageModel
    {
        [BindProperty]
        public CreateAppointmentModel Model { get; set; }
        [BindProperty]
        public List<IFormFile> Images { get; set; } = new();
        public List<CarModelsDto> CarModels { get; set; }
        public string Messege { get; set; }
        public string Rejected { get; set; }
        public IActionResult OnGet()
        {
            CarModels = carAppService.GetAll();
            return Page();
        }

        public IActionResult OnPost()
        {
            var checkInputMobile = InputValidation.IsValidMobileNumber(Model.MobileNumber);
            if (!checkInputMobile.IsSuccess)
            {
                CarModels = carAppService.GetAll();
                Rejected = checkInputMobile.Message;
                return Page();
            }
            var checkInputNC = InputValidation.IsValidNationalCode(Model.OwnersNationalCode);
            if (!checkInputNC.IsSuccess)
            {
                CarModels = carAppService.GetAll();
                Rejected = checkInputNC.Message;
                return Page();
            }
            Model.TurnTime = PersianDateToGregorian.ConvertPersianDateToGregorian(Model.TurnTimeShamsi);
            Model.YearOfManufacture = Model.YearOfManufactureShamsi + 621;

            List<string> images = new List<string>();
            if(Images != null || Images.Count > 0)
            {
                foreach (var file in Images)
                {
                    var image = fileService.Upload(file, "CarImage");
                    images.Add(image);
                }
            }
            
            CreateAppointmentDto appointment = new CreateAppointmentDto()
            {
                OwnersNationalCode = Model.OwnersNationalCode,
                LicensePlate = Model.LicensePlate,
                CarModelId = Model.CarModelId,
                MobileNumber = Model.MobileNumber,
                YearOfManufacture = Model.YearOfManufacture,
                YearOfManufactureShamsi = Model.YearOfManufactureShamsi,
                TurnTime = Model.TurnTime,
                TurnTimeShamsi = Model.TurnTimeShamsi,
                Address = Model.Address,
                ImgUrl = images
            };
            

            var result = appointmentAppService.CreateInspectionAppointment(appointment);
            if (result.IsSuccess)
            {
                CarModels = carAppService.GetAll();
                Messege = result.Message;
                return Page();
            }
            else
            {
                CarModels = carAppService.GetAll();
                Rejected = result.Message;
                return Page(); 
            }
        }
    }
}
