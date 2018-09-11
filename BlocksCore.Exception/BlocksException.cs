using System;

namespace BlocksCore.Exception
{
    [Serializable]
    public class BlocksException : System.Exception
    {
        public string Code { protected set; get; }
        public object Content { protected set; get; }
        public string  Message { get; }
        public System.Exception InnerException { get; }
        public BlocksException(string message)
            : base(message)
        {
            Message = message;
        }
        public BlocksException(string message,System.Exception innerException)
            : base(message,innerException)
        {
            Message = message;
        }
    }
}