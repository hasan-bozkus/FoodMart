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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task TCreateAsync(Customer entity)
        {
            await _customerDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(string id)
        {
            await _customerDal.DeleteAsync(id);
        }

        public async Task<Customer> TGetByIdAsync(string id)
        {
            return await _customerDal.GetByIdAsync(id);
        }

        public async Task<List<Customer>> TGetListAllAsync()
        {
            return await _customerDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Customer entity)
        {
            await _customerDal.UpdateAsync(entity);
        }
    }
}
