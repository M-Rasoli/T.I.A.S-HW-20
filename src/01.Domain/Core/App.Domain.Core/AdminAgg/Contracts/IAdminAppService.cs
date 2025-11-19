using App.Domain.Core._Common.Entities;
using App.Domain.Core.AdminAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AdminAgg.Contracts
{
    public interface IAdminAppService
    {
        Result<LoginUserDto> Login(string userName, string password);
    }
}
