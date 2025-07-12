using FoodMart.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMart.DtoLayer.Dtos.ProductDtos;

namespace FoodMart.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    }
}
