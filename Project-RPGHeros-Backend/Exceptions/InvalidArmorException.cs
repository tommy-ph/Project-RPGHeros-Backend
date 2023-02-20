using System.Runtime.Serialization;

namespace Project_RPGHeros_Backend.Exceptions
{
    [Serializable]
    internal class InvalidArmorException : Exception
    {
        public InvalidArmorException()
        {
        }

        public InvalidArmorException(string? message) : base(message)
        {
        }

        public InvalidArmorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidArmorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}