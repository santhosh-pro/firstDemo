using System;

namespace firstDemo.Common
{
    public class AuditLog
    {
        public string Id { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}