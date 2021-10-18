using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Interfaces.Services
{
    public interface IProductUnitService
    {
        Task<IList<ProductUnit>> GetAll();

        Task<ProductUnit> GetOne(int unitId);

        Task Update(ProductUnit unit);

        Task Add(ProductUnit unit);

        Task Delete(int unitId);
    }
}