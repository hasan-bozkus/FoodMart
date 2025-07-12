using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DtoLayer.Dtos.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public string FeatureId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
