using System;
using System.Threading.Tasks;

namespace BlocksCore.Loader.Abstractions.Modules.Services
{
    public class TimeZoneSelectorResult
    {
        public int Priority { get; set; }
        public Func<Task<string>> TimeZoneId { get; set; }
    }
}
