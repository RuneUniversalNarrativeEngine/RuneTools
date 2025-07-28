using RuneTools.Compiler.Parser;

namespace RuneTools.Compiler.Generator
{
    internal class RunicGenerator
    {
        private readonly List<IRunicExpression> _expressions;

        public RunicGenerator(List<IRunicExpression> expressions)
        {
            _expressions = expressions;
        }

        public string Generate()
        {
            throw new NotImplementedException("RunicGenerator.Generate method is not implemented yet.");
        }
    }
}
