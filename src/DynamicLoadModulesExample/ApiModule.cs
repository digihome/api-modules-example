namespace DynamicLoadModulesExample
{
    public class ApiModule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Loaded { get; set; } = false;
        public string Version { get; set; }
        public string Compilation { get; set; }
        public string Error { get; set; }
        public string Path { get; internal set; }
    }
}