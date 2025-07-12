using FoodMart.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.BusinnessLayer.Abstract
{
    public interface IAdminService : IGenericService<AppUser>
    {
        Task TRegisterUserAsync(AppUser user);
        Task<AppUser> TGetUserByUsernameAsync(string username);
        Task<bool> TCheckPasswordAsync(AppUser user, string password);
    }
}
