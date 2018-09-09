using System;

namespace BlocksCore.Module.Abstractions.ModuleDescription
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class ModuleRegisterAttribute : Attribute
    {
        public ModuleRegisterAttribute(string name)
        {
            this.Name = name;   
        }
        public string Name { get; set; }

    }
}