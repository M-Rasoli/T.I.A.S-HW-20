using App.Domain.Core.InspectionAppointmentAgg.Contracts;
using App.Domain.Core.InspectionAppointmentAgg.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.Razorpage.Pages.Admin
{
    public class RejectedRequestsModel(IInspectionAppointmentAppService appointmentAppService) : PageModel
    {
        public List<ShowRejectedAppointmentDto> ShowRejectedAppointment { get; set; }
        public IActionResult OnGet()
        {
            ShowRejectedAppointment = appointmentAppService.GetRejectedAppointment();
            return Page();
        }
    }
}
