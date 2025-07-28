using RuneTools.Compiler.Scanner;

namespace RuneTools.Compiler.Parser
{
    internal class RunicParser
    {
        private readonly List<RunicToken> _tokens;
        private int _current;

        public RunicParser(List<RunicToken> tokens)
        {
            _tokens = tokens;
            _current = 0;
        }

        public SyntaxTree Parse()
        {
            SyntaxTree tree = new();

            while (!IsAtEnd())
            {
                IRunicExpression expression = ParseSceneExpression();
                tree.Expressions.Add(expression);
            }

            return tree;
        }

        private SceneExpression ParseSceneExpression()
        {

        }

        #region Helper Methods
        private bool MatchKeyword(string word)
        {
            return IsType(RunicTokenType.Keyword) && Peek().Value.ToLower() == word.ToLower();
        }

        private void ConsumeKeyword(string word)
        {
            if (MatchKeyword(word))
            {
                Advance();
            }
        }

        private RunicToken Peek()
        {
            return _tokens[_current];
        }

        private void Advance()
        {
            if (!IsAtEnd())
            {
                ++_current;
            }
        }

        private bool IsType(RunicTokenType type)
        {
            return !IsAtEnd() && Peek().Type == type;
        }

        private bool IsAtEnd()
        {
            return _current >= _tokens.Count;
        }
        #endregion
    }
}
