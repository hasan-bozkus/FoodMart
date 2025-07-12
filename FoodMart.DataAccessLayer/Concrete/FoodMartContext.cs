using FoodMart.DataAccessLayer.Settings;
using FoodMart.EntityLayer.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DataAccessLayer.Concrete
{
    public class FoodMartContext
    {
        private readonly IMongoDatabase _database;
        private readonly DatabaseSettingsKey _databaseSettingsKey;

        public FoodMartContext(IOptions<DatabaseSettingsKey> databaseSettingsKey)
        {
            _databaseSettingsKey = databaseSettingsKey.Value;
            var client = new MongoClient(databaseSettingsKey.Value.ConnectionStrings);
            _database = client.GetDatabase(databaseSettingsKey.Value.DatabaseName);
        }

        public string ConnectionStrings => _databaseSettingsKey.ConnectionStrings.ToString();
        public string DatabaseName => _databaseSettingsKey.DatabaseName.ToString();

        public IMongoCollection<Category> Categories => _database.GetCollection<Category>(_databaseSettingsKey.CategoryCollectionName);
        public IMongoCollection<Product> Products => _database.GetCollection<Product>(_databaseSettingsKey.ProductCollectionName);
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>(_databaseSettingsKey.CustomerCollectionName);
        public IMongoCollection<Feature> Features => _database.GetCollection<Feature>(_databaseSettingsKey.FeatureCollectionName);
        public IMongoCollection<Discount> Discounts => _database.GetCollection<Discount>(_databaseSettingsKey.DiscountCollectionName);
        public IMongoCollection<PeopleViewing> PeopleViewings => _database.GetCollection<PeopleViewing>(_databaseSettingsKey.PeopleViewingCollectionName);
        public IMongoCollection<AppUser> Admins => _database.GetCollection<AppUser>(_databaseSettingsKey.AdminCollectionName);
    }
}
