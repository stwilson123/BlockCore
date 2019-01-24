namespace BlocksCore.Localization.Abstractions.Source
{
    public class TranslationsNotFoundException : LocalizationException
    {
        public TranslationsNotFoundException(string message) : base(message)
        {
        }

        public TranslationsNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}