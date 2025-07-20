using RuneTools.Compiler;
using RuneTools.Compiler.Helpers;

namespace RuneTools.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo fileInfo = new(args[0]);
            SourceFileType sourceFileType;
            switch (fileInfo.Extension.ToLower())
            {
                case ".rmap":
                    sourceFileType = SourceFileType.RunicMap;
                    break;
                case ".runic":
                    sourceFileType = SourceFileType.RunicScript;
                    break;
                default:
                    Console.WriteLine("Unsupported file type.");
                    return;
            }

            var sourceCode = File.ReadAllText(fileInfo.FullName);
            RunicCompiler compiler = new(sourceCode, args[1], sourceFileType);
            compiler.Compile();
        }
    }
}
