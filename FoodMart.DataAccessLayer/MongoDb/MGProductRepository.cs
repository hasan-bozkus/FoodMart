using AutoMapper;
using FoodMart.DataAccessLayer.Abstract;
using FoodMart.DataAccessLayer.Concrete;
using FoodMart.DataAccessLayer.Repositories;
using FoodMart.DataAccessLayer.Settings;
using FoodMart.DtoLayer.Dtos.ProductDtos;
using FoodMart.EntityLayer.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DataAccessLayer.MongoDb
{
    public class MGProductRepository : GenericRepository<Product>, IProductDal
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly FoodMartContext _context;
        private readonly IMapper _mapper;

        public MGProductRepository(IDatabaseSettingsKey databaseSettingsKey, FoodMartContext context, IMapper mapper) : base(databaseSettingsKey, context)
        {
            _context = context;
            var client = new MongoClient(_context.ConnectionStrings);
            var database = client.GetDatabase(_context.DatabaseName);
            _productCollection = database.GetCollection<Product>(_context.Products.CollectionNamespace.CollectionName);
            _categoryCollection = database.GetCollection<Category>(_context.Categories.CollectionNamespace.CollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();

            foreach(var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstOrDefaultAsync();
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }
    }
}
