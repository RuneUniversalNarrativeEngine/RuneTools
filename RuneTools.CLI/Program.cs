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
                case ".rscene":
                    sourceFileType = SourceFileType.RunicScene;
                    break;
                case ".runic":
                    sourceFileType = SourceFileType.RunicScript;
                    break;
                default:
                    Console.WriteLine("Unsupported file type.");
                    return;
            }

            var sourceCode = File.ReadAllText(fileInfo.FullName);
            bool debugMode = false;
            if (args.Length == 3 && args[2].ToLower() == "debug")
            {
                Console.WriteLine("Debug mode enabled.");
                debugMode = true;
            }

            RunicCompiler compiler = new(sourceCode, args[1], sourceFileType, debugMode);
            compiler.Compile();
            Console.WriteLine($"Compilation of {fileInfo.Name} completed successfully.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
