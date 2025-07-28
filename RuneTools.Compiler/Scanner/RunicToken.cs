namespace RuneTools.Compiler.Scanner
{
    internal class RunicToken
    {
        public RunicTokenType Type { get; set; }
        public string Value { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }

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
