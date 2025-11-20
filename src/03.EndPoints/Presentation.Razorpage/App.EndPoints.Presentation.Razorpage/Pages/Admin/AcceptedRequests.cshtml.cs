using App.Domain.Core.CarAgg.Enums;
using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using App.Domain.Core.InspectionAppointmentAgg.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.EndPoints.Presentation.Razorpage.Pages.Admin
{
    public class AcceptedRequestsModel(IInspectionAppointmentAppService appointmentAppService) : PageModel
    {
        public List<ShowAcceptedAppointmentDto> AcceptedAppointments { get; set; }
        public List<string> ReservedDays { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DayFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public CarCompanyEnum? CompanyFilter { get; set; }
        public string Message { get; set; }
        public string error { get; set; }
        public IActionResult OnGet()
        {
            AcceptedAppointments = appointmentAppService.GetAcceptedAppointment(DayFilter, CompanyFilter);
            ReservedDays = appointmentAppService.GetReserveDays();
            return Page();
        }
        public IActionResult OnPostChangeStatus(int requestId, AppointmentStatusEnum status)
        {
            var result = appointmentAppService.ChangeAppointmentStatus(requestId, status);
            if (result.IsSuccess)
            {
                Message = result.Message;
                return RedirectToPage();
            }
            else
            {
                error = result.Message;
                return RedirectToPage();
            }
            
        }

    }
}
