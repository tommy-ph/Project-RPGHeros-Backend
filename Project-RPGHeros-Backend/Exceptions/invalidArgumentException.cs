using System.Runtime.Serialization;

namespace Project_RPGHeros_Backend.Exceptions
{
    [Serializable]
    internal class invalidArgumentException : Exception
    {
        public invalidArgumentException()
        {
        }

        public invalidArgumentException(string? message) : base(message)
        {
        }

        public invalidArgumentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected invalidArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}