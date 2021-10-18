using System;
using System.Collections.Generic;

namespace WarehouseManagement.Domain.Entities
{
    public class Record : EntityBase<int>
    {
        public DateTime Date { get; set; }

        public PaymentType PaymentType { get; set; }
        public List<RecordItem> Items { get; set; }
        public Employee Employee { get; set; }
    }
}