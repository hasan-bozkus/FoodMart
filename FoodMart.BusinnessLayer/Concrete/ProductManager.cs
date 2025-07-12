using FoodMart.BusinnessLayer.Abstract;
using FoodMart.DataAccessLayer.Abstract;
using FoodMart.DtoLayer.Dtos.ProductDtos;
using FoodMart.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.BusinnessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task TCreateAsync(Product entity)
        {
            await _productDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(string id)
        {
            await _productDal.DeleteAsync(id);
        }

        public async Task<List<ResultProductWithCategoryDto>> TGetAllProductWithCategoryAsync()
        {
            return await _productDal.GetAllProductWithCategoryAsync();
        }

        public async Task<Product> TGetByIdAsync(string id)
        {
            return await _productDal.GetByIdAsync(id);
        }

        public async Task<List<Product>> TGetListAllAsync()
        {
            return await _productDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Product entity)
        {
            await _productDal.UpdateAsync(entity);
        }
    }
}
