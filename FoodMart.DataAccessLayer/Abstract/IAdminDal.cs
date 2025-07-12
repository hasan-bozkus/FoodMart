using FoodMart.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DataAccessLayer.Abstract
{
    public interface IAdminDal : IGenericDal<AppUser>
    {
        Task RegisterUserAsync(AppUser user);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
    }
}
