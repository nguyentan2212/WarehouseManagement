using System.Collections.Generic;

namespace WarehouseManagement.Domain.Entities
{
    public class Supplier : EntityBase<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<RecordItem> Items { get; set; }
    }
}