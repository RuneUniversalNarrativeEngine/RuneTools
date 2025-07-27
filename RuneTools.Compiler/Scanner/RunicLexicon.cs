namespace RuneTools.Compiler.Scanner
{
    internal static class RunicLexicon
    {
        public static readonly HashSet<string> Keywords = new()
        {
            "scene",
            "description",
            "to",
            "painting",
        };

        public static readonly HashSet<string> Identifiers = new()
        {
            "north",
            "south",
            "east",
            "west",
        };
    }
}
