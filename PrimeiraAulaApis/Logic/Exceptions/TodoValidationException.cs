using System.Runtime.Serialization;

namespace PrimeiraAulaApis.Logic.Exceptions
{
    [Serializable]
    public class TodoValidationException : Exception
    {
        public TodoValidationException() { }
        public TodoValidationException(string message) : base(message) { }
        public TodoValidationException(string message, Exception innerException) : base(message, innerException) { }
        protected TodoValidationException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

        internal static void ThrowWhenIsDifferent<T>(T first, T second, string message)
        {
            if (first?.ToString() != second?.ToString())
                throw new TodoValidationException(message);
        }
    }
}
