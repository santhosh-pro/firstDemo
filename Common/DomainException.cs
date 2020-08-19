using System;

namespace firstDemo.Common
{
    
    public class DomainException: Exception
    {
        public string BusinessMessage { get; private set; }
        public DomainException (string businessMessage) : base (businessMessage) {
            BusinessMessage = businessMessage;
        }
    }
}