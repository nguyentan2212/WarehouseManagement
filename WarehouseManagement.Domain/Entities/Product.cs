using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Domain.Entities
{
    public class Product : EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public float Discount { get; set; }
        public int UnitPrice { get; set; }
        public float UnitWeight { get; set; }
        public int UnitsInStock { get; set; }

        public ProductUnit Unit { get; set; }
        public List<RecordItem> OrderItems { get; set; }
    }
}
