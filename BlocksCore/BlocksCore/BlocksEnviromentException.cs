using BlocksCore.Exception;

namespace BlocksCore
{
    public class BlocksEnviromentException : BlocksException
    {
        public BlocksEnviromentException(string message) : base(message)
        {
        }

        public BlocksEnviromentException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}