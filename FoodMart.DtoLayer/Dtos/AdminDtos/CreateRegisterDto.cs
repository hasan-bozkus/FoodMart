using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.DtoLayer.Dtos.AdminDtos
{
    public class CreateRegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
