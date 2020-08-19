using System;
using firstDemo.Common.Abstractions;

namespace firstDemo.Common
{
    public class Entity:BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
    }
}