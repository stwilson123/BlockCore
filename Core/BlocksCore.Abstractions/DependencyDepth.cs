namespace BlocksCore.Abstractions
{
    public class DependencyDepth
    {
        public static int Infrastructure = -200;
        
        public static int System = -100;

        public static int Module = 0;

        public static int ModuleExtend = 100;

    }
}