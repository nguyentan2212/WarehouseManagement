namespace WarehouseManagement.Domain.Entities
{
    public class RecordItem : EntityBase<int>
    {
        public int Quantity { get; set; }
        public float Discount { get; set; }

        public Record Record { get; set; }
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}