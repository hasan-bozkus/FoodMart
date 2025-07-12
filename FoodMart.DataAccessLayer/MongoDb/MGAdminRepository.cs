using FoodMart.DataAccessLayer.Abstract;
using FoodMart.DataAccessLayer.Concrete;
using FoodMart.DataAccessLayer.Repositories;
using FoodMart.DataAccessLayer.Settings;
using FoodMart.EntityLayer.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DataAccessLayer.MongoDb
{
    public class MGAdminRepository : GenericRepository<AppUser>, IAdminDal
    {
        private readonly IMongoCollection<AppUser> _appUserCollection;
        private readonly FoodMartContext _context;

        public MGAdminRepository(IDatabaseSettingsKey databaseSettingsKey, FoodMartContext context) : base(databaseSettingsKey, context)
        {
            _context = context;
            var client = new MongoClient(_context.ConnectionStrings);
            var database = client.GetDatabase(_context.DatabaseName);
            _appUserCollection = database.GetCollection<AppUser>(_context.Admins.CollectionNamespace.CollectionName);
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            return user.Password == password;
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _appUserCollection.Find(x => x.Username == username).FirstOrDefaultAsync();
        }

        public async Task RegisterUserAsync(AppUser user)
        {
            await _appUserCollection.InsertOneAsync(user);
        }
    }
}
