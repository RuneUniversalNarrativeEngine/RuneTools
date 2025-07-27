namespace RuneTools.Compiler.Scanner
{
    internal enum RunicTokenType
    {
        Keyword, // scene, description, to, painting
        Identifier, // north, south, east, west
        PathLiteral, // "path/to/scene_painting.rpainting",
        StringLiteral, // "scene name", "scene description"
        Whitespace, // whitespace characters, tabs, etc.
        NewLine, // '\n'
    }
}
