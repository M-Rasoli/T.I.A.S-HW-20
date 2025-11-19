using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.AdminAgg.Contracts;
using App.Domain.Core.AdminAgg.Dtos;
using App.Infrastructure.Persistence;

namespace App.Infrastructure.EfCore.Repositories.AdminAgg
{
    public class AdminRepository(AppDbContext _context) : IAdminRepository
    {
        public LoginUserDto Login(string userName)
        {
            return _context.Admins.Where(u => u.UserName.ToLower() == userName.ToLower())
                .Select(x => new LoginUserDto()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password

                }).FirstOrDefault();
        }

    }
}
