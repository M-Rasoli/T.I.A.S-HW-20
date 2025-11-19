using App.Domain.Core.AdminAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.AdminAgg.Contracts
{
    public interface IAdminService
    {
        LoginUserDto Login(string userName);
    }
}
