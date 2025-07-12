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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public async Task TCreateAsync(Feature entity)
        {
            await _featureDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(string id)
        {
            await _featureDal.DeleteAsync(id);
        }

        public async Task<Feature> TGetByIdAsync(string id)
        {
            return await _featureDal.GetByIdAsync(id);
        }

        public async Task<List<Feature>> TGetListAllAsync()
        {
            return await _featureDal.GetListAllAsync();
        }

        public async Task TUpdateAsync(Feature entity)
        {
            await _featureDal.UpdateAsync(entity);
        }
    }
}
