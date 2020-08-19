using firstDemo.Common.Abstractions;

namespace firstDemo.Common
{
    public class BaseEntity: IBaseEntity<string>
    {
        public string Id { get; set; }
    }
}