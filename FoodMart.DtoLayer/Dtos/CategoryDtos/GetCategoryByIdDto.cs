using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DtoLayer.Dtos.CategoryDtos
{
    public class GetCategoryByIdDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string IconUrl { get; set; }
    }
}
