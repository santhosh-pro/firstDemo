using firstDemo.Common;

namespace firstDemo.Persistence.Entities
{
    public class OrderItem : Entity
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public void SetId(string id)
        {
            Id = id;
        }

        public void SetProductName(string productName)
        {
            ProductName = productName;
        }

        public void SetUnitPrice(double unitPrice)
        {
            UnitPrice = unitPrice;
        }

        public void AddTotalPrice() {
            TotalPrice = UnitPrice * Quantity;
        }
    }
}
