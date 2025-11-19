using App.Domain.Core.AdminAgg.Dtos;

namespace App.Domain.Core.AdminAgg.Contracts
{
    public interface IAdminRepository
    {
        LoginUserDto Login(string userName);
    }
}
