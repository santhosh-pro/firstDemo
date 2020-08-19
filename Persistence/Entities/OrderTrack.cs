using System;
using firstDemo.Common;

namespace firstDemo.Persistence.Entities
{
    public class OrderTrack:Entity
    {
        public string OrderId { get; set; }
        public DateTime TrackingDate { get; set; }
        public int OrderStatusId { get; set; }
        public Order Order { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public void SetId(string id){
            Id=id;
        }
    }
}