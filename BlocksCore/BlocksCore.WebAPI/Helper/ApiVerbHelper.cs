using System;
using BlocksCore.Web.Abstractions.HttpMethod;

namespace BlocksCore.WebAPI.Helper
{
    internal class ApiVerbHelper
    {
        public  static HttpVerb GetConventionalVerbForMethodName(string methodName)
        {
            if (methodName.StartsWith("Get", StringComparison.InvariantCultureIgnoreCase))
            {
                return HttpVerb.Get;
            }

            if (methodName.StartsWith("Put", StringComparison.InvariantCultureIgnoreCase) || 
                methodName.StartsWith("Update", StringComparison.InvariantCultureIgnoreCase))
            {
                return HttpVerb.Put;
            }

            if (methodName.StartsWith("Patch", StringComparison.InvariantCultureIgnoreCase))
            {
                return HttpVerb.Patch;
            }

            if (methodName.StartsWith("Delete", StringComparison.InvariantCultureIgnoreCase) ||
                methodName.StartsWith("Remove", StringComparison.InvariantCultureIgnoreCase))
            {
                return HttpVerb.Delete;
            }

            if (methodName.StartsWith("Post", StringComparison.InvariantCultureIgnoreCase) || 
                methodName.StartsWith("Create", StringComparison.InvariantCultureIgnoreCase) ||
                methodName.StartsWith("Insert", StringComparison.InvariantCultureIgnoreCase))
            {
                return HttpVerb.Post;
            }

            return GetDefaultHttpVerb();
        }

        public static HttpVerb GetDefaultHttpVerb()
        {
            return HttpVerb.Post;
        }
    }
}