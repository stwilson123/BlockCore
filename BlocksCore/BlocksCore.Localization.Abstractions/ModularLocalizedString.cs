namespace BlocksCore.Localization.Core
{
    public class ModularLocalizedString : Microsoft.Extensions.Localization.LocalizedString
    {
        private readonly string _source;

        public ModularLocalizedString(string name, string value) : base(name, value)
        {
            
        }

        public ModularLocalizedString(string name, string value, bool resourceNotFound) : base(name, value, resourceNotFound)
        {
        }

        public ModularLocalizedString(string name, string value, bool resourceNotFound, string searchedLocation) : base(name, value, resourceNotFound, searchedLocation)
        {
        }

        public ModularLocalizedString(string source,string name,string value,bool resourceNotFound,string searchedLocation) : base(name, value, resourceNotFound, searchedLocation)
        {
            _source = source;
        }
        
    }
}