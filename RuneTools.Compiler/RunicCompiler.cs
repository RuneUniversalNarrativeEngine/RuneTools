using RuneTools.Compiler.Generator;
using RuneTools.Compiler.Helpers;
using RuneTools.Compiler.Parser;
using RuneTools.Compiler.Scanner;

namespace RuneTools.Compiler
{
    public class RunicCompiler
    {
        private readonly string _sourceCode;
        private readonly string _outputDirectory;
        private SourceFileType _sourceFileType;
        private bool _isDebugMode;

        public RunicCompiler(string sourceCode, string outputDirectory, SourceFileType sourceFileType, bool isDebugMode = false)
        {
            _isDebugMode = isDebugMode;
            _sourceCode = sourceCode ?? throw new ArgumentNullException(nameof(sourceCode));
            _outputDirectory = outputDirectory ?? throw new ArgumentNullException(nameof(outputDirectory));
            _sourceFileType = sourceFileType;
        }

        public void Compile()
        {
            var tokens = Scan();
            var expressions = Parse(tokens);
            //GenerateCode(expressions);
            if (_isDebugMode)
            {
                DebugLog(tokens);
            }
        }

        private List<RunicToken> Scan()
        {
            RunicScanner scanner = new RunicScanner(_sourceCode);
            var tokens = scanner.Scan();
            return tokens;
        }

        private List<IRunicExpression> Parse(List<RunicToken> tokens)
        {
            RunicParser parser = new RunicParser(tokens);
            var expressions = parser.Parse();
            return expressions;
        }

        private void GenerateCode(List<IRunicExpression> expressions)
        {

            RunicGenerator runicGenerator = new RunicGenerator(expressions);
            runicGenerator.Generate();
        }

        private void DebugLog(List<RunicToken> tokens)
        {
            string debugInfo = $"Debug Log:\n";
            debugInfo += $"Source File Type: {_sourceFileType}\n";
            debugInfo += $"Source Code Length: {_sourceCode.Length}\n";
            debugInfo += $"Number of Tokens: {tokens.Count}\n";
            debugInfo += "Tokens:\n";
            foreach (var token in tokens)
            {
                debugInfo += $"{token.ToString()}\n";
            }

            File.AppendAllText($"{_outputDirectory}/debug.log", debugInfo);
            Console.WriteLine("Debug information logged to debug.log");
            Console.WriteLine(debugInfo);
        }
    }
}
