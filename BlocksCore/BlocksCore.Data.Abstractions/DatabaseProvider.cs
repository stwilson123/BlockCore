namespace BlocksCore.Data.Abstractions
{
    public class DatabaseProvider
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool HasConnectionString { get; set; }
        public bool HasTablePrefix { get; set; }
        public bool IsDefault { get; set; }
    }
}