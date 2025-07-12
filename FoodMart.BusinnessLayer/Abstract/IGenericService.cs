using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.BusinnessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> TGetListAllAsync();
        Task TCreateAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(string id);
        Task<T> TGetByIdAsync(string id);
    }
}
