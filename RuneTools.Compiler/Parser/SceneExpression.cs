namespace RuneTools.Compiler.Parser
{
    internal class SceneExpression : IRunicExpression
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Painting { get; set; }
        public Dictionary<string, string> Exits { get; set; } = new();
    }
}
