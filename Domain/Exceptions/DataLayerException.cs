using System;

namespace Domain.Exceptions
{
    public class DataLayerException : Exception
    {

        public DataLayerException() { }

        public DataLayerException(string message) : base(message) { }

        public DataLayerException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}
