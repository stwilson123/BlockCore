using BlocksCore.Exception;

namespace BlocksCore.Localization.Abstractions
{
    public class LocalizationException : BlocksException
    {
        public LocalizationException(string message) : base(message)
        {
        }

        public LocalizationException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}