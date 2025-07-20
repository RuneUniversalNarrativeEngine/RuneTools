using RuneTools.Compiler.Generator;
using RuneTools.Compiler.Helpers;
using RuneTools.Compiler.Parser;
using RuneTools.Compiler.Scanner;

namespace RuneTools.Compiler
{
    public class RunicCompiler
    {
        private readonly string _sourceCode;
        private readonly string _outputFilePath;
        private SourceFileType _sourceFileType;

        public RunicCompiler(string sourceCode, string outputFilePath, SourceFileType sourceFileType)
        {
            _sourceCode = sourceCode ?? throw new ArgumentNullException(nameof(sourceCode));
            _outputFilePath = outputFilePath ?? throw new ArgumentNullException(nameof(outputFilePath));
            _sourceFileType = sourceFileType;
        }

        public void Compile()
        {
            var tokens = Scan();
            var expressions = Parse(tokens);
            GenerateCode(expressions);
        }

        private List<RunicToken> Scan()
        {
            var tokens = RunicScanner.Scan(_sourceCode);
            return tokens;
        }

        private List<RunicExpression> Parse(List<RunicToken> tokens)
        {
            var expressions = RunicParser.Parse(tokens);
            return expressions;
        }

        private void GenerateCode(List<RunicExpression> expressions)
        {
            RunicGenerator.Generate(expressions);
        }
    }
}
