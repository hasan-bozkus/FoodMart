using FoodMart.DataAccessLayer.Abstract;
using FoodMart.DataAccessLayer.Concrete;
using FoodMart.DataAccessLayer.Repositories;
using FoodMart.DataAccessLayer.Settings;
using FoodMart.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DataAccessLayer.MongoDb
{
    public class MGPeopleViewingRepository : GenericRepository<PeopleViewing>, IPeopleViewingDal
    {
        public MGPeopleViewingRepository(IDatabaseSettingsKey databaseSettingsKey, FoodMartContext context) : base(databaseSettingsKey, context)
        {
        }
    }
}
