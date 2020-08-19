using System.Collections.Generic;
using firstDemo.Common;

namespace firstDemo.Persistence.Entities
{
    public class Product:Entity
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public void SetId(string id){
            Id=id;
        }
    }
}