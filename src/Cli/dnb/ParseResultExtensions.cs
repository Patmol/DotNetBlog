using System.CommandLine.Parsing;
using System.Linq;

namespace DotNetBlog.Cli
{
    public  static class ParseResultExtensions
    {
        public static string GetRootCommand(this ParseResult parseResult)
        {
            var symbol = parseResult.RootCommandResult.Children?.
                Select(child => child.Symbol)
                .FirstOrDefault();

            return symbol?.Name ?? string.Empty;
        }

        public static string[] GetCommandParameter(this string[] args)
        {
            var subargs = args.ToList();
            subargs.RemoveAt(0);
            return args;
        }
    }
}