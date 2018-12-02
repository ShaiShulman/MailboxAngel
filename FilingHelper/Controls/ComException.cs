using System;
using System.Runtime.Serialization;

namespace FilingHelper.Controls
{
    [Serializable]
    internal class ComException : Exception
    {
        public ComException()
        {
        }

        public ComException(string message) : base(message)
        {
        }

        public ComException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ComException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}