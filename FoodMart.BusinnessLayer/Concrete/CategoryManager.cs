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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task TCreateAsync(Category entity)
        {
            await _categoryDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(string id)
        {
            await _categoryDal.DeleteAsync(id);
        }

        public async Task<Category> TGetByIdAsync(string id)
        {
            return await _categoryDal.GetByIdAsync(id);
        }

        public async Task<List<Category>> TGetListAllAsync()
        {
            return await _categoryDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Category entity)
        {
            await _categoryDal.UpdateAsync(entity);
        }
    }
}
