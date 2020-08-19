using System.Runtime.Serialization;
using System.Collections.Generic;

namespace firstDemo.UseCases.OrderUseCases
{
    public class OrderBase
    {
        public string Description { get; set; }
        public List<OrderItemBase> OrderItems { get; set; }
    }

    public class OrderItemBase
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
    }
}