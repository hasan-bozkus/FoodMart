using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DataAccessLayer.Abstract;
using FoodMart.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.BusinnessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public async Task<bool> TCheckPasswordAsync(AppUser user, string password)
        {
            return await _adminDal.CheckPasswordAsync(user, password);
        }

        public async Task TCreateAsync(AppUser entity)
        {
            await _adminDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(string id)
        {
            await _adminDal.DeleteAsync(id);
        }

        public async Task<AppUser> TGetByIdAsync(string id)
        {
            return await _adminDal.GetByIdAsync(id);
        }

        public async Task<List<AppUser>> TGetListAllAsync()
        {
            return await _adminDal.GetListAllAsync();
        }

        public async Task<AppUser> TGetUserByUsernameAsync(string username)
        {
            return await _adminDal.GetUserByUsernameAsync(username);
        }

        public async Task TRegisterUserAsync(AppUser user)
        {
            await _adminDal.RegisterUserAsync(user);
        }

        public async Task TUpdateAsync(AppUser entity)
        {
            await _adminDal.UpdateAsync(entity);
        }
    }
}
