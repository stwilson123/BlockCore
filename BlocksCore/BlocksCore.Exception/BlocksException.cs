using System;

namespace BlocksCore.Exception
{
    [Serializable]
    public class BlocksException : System.Exception
    {
        public string Code { protected set; get; }
        public object Content { protected set; get; }
        public BlocksException(string message)
            : base(message)
        {
            
        }
        public BlocksException(string message,System.Exception innerException)
            : base(message,innerException)
        {
          
        }
    }
}