using Microsoft.Extensions.Localization;
using System;

namespace BlocksCore.Localization.Abstractions
{
    public interface IModularLocalizer<T> : IStringLocalizer<T>
    {
    }
}