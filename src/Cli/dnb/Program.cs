using System;
using System.CommandLine.Parsing;
using DotNetBlog.Cli.Commands;
using DotNetBlog.Cli.Commands.Help;
using Spectre.Console;

namespace DotNetBlog.Cli
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var parseResult = Parser.Instance.Parse(args);

                if (parseResult.HasOption(Parser.HelpOption))
                {
                    HelpCommand.PrintHelp();
                    return 0;
                }

                int exitCode = 0;

                if (BuiltInCommandsCatalog.Commands.TryGetValue(parseResult.GetRootCommand(), out var command))
                {
                    exitCode = command.Command(args);
                }

                return exitCode;
            }
            catch (Exception e)
            {
#if DEBUG
                AnsiConsole.WriteException(e);
                AnsiConsole.WriteLine();
#endif

                AnsiConsole.Markup($"[bold red]{e.Message}[/]");
                return 1;
            }
        }
    }
}
