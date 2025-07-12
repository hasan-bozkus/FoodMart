using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DtoLayer.Dtos.ProductDtos
{
    public class GetProductByIdDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal StockCount { get; set; }
        public string ProductImageUrl { get; set; }
        public string CategoryId { get; set; }
    }
}
