using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._Common.Entities;
using App.Domain.Core.AdminAgg.Contracts;
using App.Domain.Core.AdminAgg.Dtos;

namespace App.Domain.AppService.AdminAgg
{
    public class AdminAppService(IAdminService adminService) : IAdminAppService
    {
        public Result<LoginUserDto> Login(string userName, string password)
        {
            var user = adminService.Login(userName);
            if (user is null)
            {
                return Result<LoginUserDto>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }

            if (user.Password != password)
            {
                return Result<LoginUserDto>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }
            else
            {
                return Result<LoginUserDto>.Success(message: "خوش آمدید", user);
            }
        }
    }
}
