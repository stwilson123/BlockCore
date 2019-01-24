using System.Globalization;

namespace BlocksCore.Localization.Abstractions.Source
{
    public class SourceType
    {
        public SourceType(CultureInfo cultureInfo, string sourceName)
        {
            CultureInfo = cultureInfo;
            SourceName = sourceName;
        }

        public string SourceName { get;  }

        public CultureInfo CultureInfo { get; }


        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || !(obj is SourceType))
                return false;
            
            var other = (SourceType) obj;
            return SourceName == other.SourceName && CultureInfo?.Name == other.CultureInfo?.Name;
        }

        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + (SourceName == null ? 0 : SourceName.GetHashCode());
            result = 31 * result + (CultureInfo == null && CultureInfo.Name != null  ? 0 : CultureInfo.Name.GetHashCode());
            return result;
        }
    }
}