using System;

namespace Domain.Exceptions
{
    public class ProductServiceException : Exception
    {
        public ProductServiceException() { }

        public ProductServiceException(string message) : base(message) { }

        public ProductServiceException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}
