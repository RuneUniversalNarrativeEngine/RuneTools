namespace RuneTools.Compiler.Scanner
{
    internal class RunicScanner
    {
        private string _sourceCode;
        private int _index;
        private int _line;

        public RunicScanner(string sourceCode)
        {
            _sourceCode = sourceCode;
            _index = 0;
            _line = 1;
        }

        public List<RunicToken> Scan()
        {
            List<RunicToken> tokens = new();
            while (!IsAtEndOfFile())
            {
                SkipWhitespace();
                if (IsAtEndOfFile())
                {
                    break;
                }

                var token = IdentifierOrKeyword() ?? StringLiteralOrPathLiteral() ?? null;
                if (token != null)
                {
                    tokens.Add(token);
                }
            }

            return tokens;
        }

        private RunicToken? IdentifierOrKeyword()
        {
            int start = _index;
            int startColumn = _index;
            if (!char.IsLetter(Peek()))
            {
                return null;
            }

            while (!IsAtEndOfFile() && char.IsLetter(Peek())) 
            {
                Advance();
            }

            string word = _sourceCode.Substring(start, _index - start);
            if (RunicLexicon.Keywords.Contains(word))
            {
                return new RunicToken(RunicTokenType.Keyword, word, _line, startColumn);
            }

            if (RunicLexicon.Identifiers.Contains(word))
            {
                return new RunicToken(RunicTokenType.Identifier, word, _line, startColumn);
            }

            return null;
        }

        private RunicToken? StringLiteralOrPathLiteral()
        {
            int start = _index;
            int startColumn = _index;
            if (Peek() != '"')
            {
                return null; // Not a string or path literal
            }

            Advance(); // Skip the opening quote
            while (!IsAtEndOfFile() && Peek() != '"')
            {
                Advance();
            }

            string literal = _sourceCode.Substring(start + 1, _index - start - 1);
            if (!IsAtEndOfFile())
            {
                Advance(); // Skip the closing quote
            }

            if (literal.EndsWith(".rpainting"))
            {
                return new RunicToken(RunicTokenType.PathLiteral, literal, _line, startColumn);
            }
            else
            {
                return new RunicToken(RunicTokenType.StringLiteral, literal, _line, startColumn);
            }
        }

        private void SkipWhitespace()
        {
            while (!IsAtEndOfFile() && IsWhitespace(Peek()))
            {
                Advance();
            }
        }

        #region Helper Methods
        private char Peek()
        {
            return _sourceCode[_index];
        }

        private void Advance()
        {
            if (IsNewLine(Peek()))
            {
                ++_line;
            }

            ++_index;
        }

        private bool IsWhitespace(char c)
        {
            return char.IsWhiteSpace(c) || c == '\t';
        }

        private bool IsNewLine(char c)
        {
            return c == '\n' || c == '\r';
        }

        private bool IsAtEndOfFile()
        {
            return _index >= _sourceCode.Length;
        }
        #endregion
    }
}
