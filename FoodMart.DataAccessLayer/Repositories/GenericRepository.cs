using FoodMart.DataAccessLayer.Abstract;
using FoodMart.DataAccessLayer.Concrete;
using FoodMart.DataAccessLayer.Settings;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly FoodMartContext _context;
        private readonly IMongoCollection<T> _mongoCollection;

        public GenericRepository(IDatabaseSettingsKey databaseSettingsKey, FoodMartContext context)
        {
            _context = context;
            var client = new MongoClient(_context.ConnectionStrings);
            var database = client.GetDatabase(_context.DatabaseName);
            // typeof(CozaStoreContext) içindeki tüm public property'lere bak
            var collectionProperty = typeof(FoodMartContext)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(prop =>
                    prop.PropertyType.IsGenericType &&
                    prop.PropertyType.GetGenericTypeDefinition() == typeof(IMongoCollection<>) &&
                    prop.PropertyType.GetGenericArguments()[0] == typeof(T)
                );

            if (collectionProperty == null)
                throw new Exception($"CozaStoreContext içinde {typeof(T).Name} için IMongoCollection<{typeof(T).Name}> bulunamadı.");

            // IMongoCollection<T>'yi context'ten al
            _mongoCollection = (IMongoCollection<T>)collectionProperty.GetValue(context);

            if (_mongoCollection == null)
                throw new Exception($"{collectionProperty.Name} property'si null döndü. Koleksiyon tanımı doğru yapılandırılmış mı?");
        }

        public async Task CreateAsync(T entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await _mongoCollection.DeleteOneAsync(filter);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            var value = await _mongoCollection.Find<T>(filter).FirstOrDefaultAsync();
            return value;
        }

        public async Task<List<T>> GetListAllAsync()
        {
            var values = await _mongoCollection.Find<T>(x => true).ToListAsync();
            return values;
        }

        public async Task UpdateAsync(T entity)
        {
            var document = entity.ToBsonDocument();
            var idValue = document.GetValue("_id", null);
            var filter = Builders<T>.Filter.Eq("_id", idValue);
            await _mongoCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
