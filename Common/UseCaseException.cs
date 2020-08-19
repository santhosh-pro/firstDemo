using System;

namespace firstDemo.Common {
    public class UseCaseException : Exception {
        public string BusinessMessage { get; private set; }
        public UseCaseException (string businessMessage) : base (businessMessage) {
            BusinessMessage = businessMessage;
        }
    }
}