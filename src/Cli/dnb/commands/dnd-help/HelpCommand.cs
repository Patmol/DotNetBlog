using DotNetBlog.Cli.Utils;
using Spectre.Console;

namespace DotNetBlog.Cli.Commands.Help
{
    public class HelpCommand
    {
        private static void PrintVersionHeader()
        {
            var version = string.IsNullOrEmpty(Product.Version) ? string.Empty : $" ({Product.Version})";
            AnsiConsole.Markup($"[bold]{Product.LongName}[/]{version}");
        }

        public static void PrintHelp()
        {
            PrintVersionHeader();
        }
    }
}