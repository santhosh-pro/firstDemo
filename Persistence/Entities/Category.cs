using System.Collections.Generic;
using firstDemo.Common;

namespace firstDemo.Persistence.Entities
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public void SetId(string id){
            Id=id;
        }
    }
}