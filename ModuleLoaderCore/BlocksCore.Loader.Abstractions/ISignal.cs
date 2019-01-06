using Microsoft.Extensions.Primitives;

namespace BlocksCore.Loader.Abstractions
{
    public interface ISignal
    {
        IChangeToken GetToken(string key);

        void SignalToken(string key);
    }
}
