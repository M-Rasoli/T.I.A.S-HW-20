using App.Domain.Core.AdminAgg.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoints.Presentation.Razorpage.Pages.Account
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginModel(IAdminAppService adminAppService) : PageModel
    {
        [BindProperty]
        public LoginViewModel Model { get; set; }
        public string Messeage { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var result = adminAppService.Login(Model.UserName, Model.Password);
            if (result.IsSuccess)
            {
                return RedirectToPage("/Admin/Index");
            }
            else
            {
                Messeage = result.Message;
                return Page();
            }
        }
    }
}
