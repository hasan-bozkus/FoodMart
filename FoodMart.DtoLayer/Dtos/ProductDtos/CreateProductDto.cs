using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DtoLayer.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
    }
}
