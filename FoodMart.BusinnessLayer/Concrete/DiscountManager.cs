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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public async Task TCreateAsync(Discount entity)
        {
            await _discountDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(string id)
        {
            await _discountDal.DeleteAsync(id);
        }

        public async Task<Discount> TGetByIdAsync(string id)
        {
            return await _discountDal.GetByIdAsync(id);
        }

        public async Task<List<Discount>> TGetListAllAsync()
        {
            return await _discountDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Discount entity)
        {
            await _discountDal.UpdateAsync(entity);
        }
    }
}
