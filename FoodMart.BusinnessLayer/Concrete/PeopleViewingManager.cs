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
    public class PeopleViewingManager : IPeopleViewingService
    {
        private readonly IPeopleViewingDal _peopleViewingDal;

        public PeopleViewingManager(IPeopleViewingDal peopleViewingDal)
        {
            _peopleViewingDal = peopleViewingDal;
        }

        public async Task TCreateAsync(PeopleViewing entity)
        {
            await _peopleViewingDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(string id)
        {
            await _peopleViewingDal.DeleteAsync(id);
        }

        public async Task<PeopleViewing> TGetByIdAsync(string id)
        {
            return await _peopleViewingDal.GetByIdAsync(id);
        }

        public async Task<List<PeopleViewing>> TGetListAllAsync()
        {
            return await _peopleViewingDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(PeopleViewing entity)
        {
            await _peopleViewingDal.UpdateAsync(entity);
        }
    }
}
