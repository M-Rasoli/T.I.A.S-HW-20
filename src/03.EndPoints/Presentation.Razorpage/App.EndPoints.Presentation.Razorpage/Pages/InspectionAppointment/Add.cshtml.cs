using System.Runtime.InteropServices.JavaScript;
using App.Domain.Core.CarAgg.Contracts;
using App.Domain.Core.CarAgg.Dtos;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using App.EndPoints.Presentation.MVC.Tools;
using App.EndPoints.Presentation.Razorpage.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.Razorpage.Pages.InspectionAppointment
{
    public class AddModel(IInspectionAppointmentAppService appointmentAppService , ICarAppService carAppService) : PageModel
    {
        [BindProperty]
        public CreateAppointmentDto Model { get; set; }
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
            var result = appointmentAppService.CreateInspectionAppointment(Model);
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
