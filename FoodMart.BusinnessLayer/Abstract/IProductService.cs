using FoodMart.DtoLayer.Dtos.ProductDtos;
using FoodMart.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.BusinnessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Task<List<ResultProductWithCategoryDto>> TGetAllProductWithCategoryAsync();
    }
}
