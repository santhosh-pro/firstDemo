using System.Collections.Generic;
using firstDemo.Common;

namespace firstDemo.Persistence.Entities
{
    public class OrderStatus : IntBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderTrack> OrderTracks { get; set; }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}