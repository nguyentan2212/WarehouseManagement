namespace WarehouseManagement.Domain.Entities
{
    public class PaymentType : EntityBase<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}