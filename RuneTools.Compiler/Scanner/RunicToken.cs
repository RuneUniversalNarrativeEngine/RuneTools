namespace RuneTools.Compiler.Scanner
{
    internal class RunicToken
    {
        RunicTokenType Type { get; set; }
        string Value { get; set; }
        int Line { get; set; }
        int Column { get; set; }

        public RunicToken(RunicTokenType type, string value, int line, int column)
        {
            Type = type;
            Value = value;
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Type}({Value}) at {Line}:{Column}";
        }
    }
}
