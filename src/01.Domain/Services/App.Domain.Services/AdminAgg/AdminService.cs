using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.AdminAgg.Contracts;
using App.Domain.Core.AdminAgg.Dtos;

namespace App.Domain.Services.AdminAgg
{
    public class AdminService(IAdminRepository adminRepository) : IAdminService
    {
        public LoginUserDto Login(string userName)
        {
            return adminRepository.Login(userName);
        }
    }
}
