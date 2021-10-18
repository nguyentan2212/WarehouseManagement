using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Interfaces.Services;

namespace WarehouseManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductUnitController : ControllerBase
    {
        private IProductUnitService _productUnitService;

        public ProductUnitController(IProductUnitService productUnitService)
        {
            _productUnitService = productUnitService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductUnit>>> GetAll()
        {
            IList<ProductUnit> result = await _productUnitService.GetAll();
            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductUnit unit)
        {
            await _productUnitService.Add(unit);

            return Ok();
        }
    }
}