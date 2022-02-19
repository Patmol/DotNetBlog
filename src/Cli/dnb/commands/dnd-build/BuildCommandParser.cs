using System.CommandLine;

namespace DotNetBlog.Cli.Commands.Build
{
    internal static class BuildCommandParser
    {
        public static readonly Option PathOption = new Option<string>(new [] { "--path", "-p" });
        public static readonly Option OutputPathOption = new Option<string>(new [] { "--out", "-o" });

        public static Command GetCommand()
        {
            var command = new Command("build");

            command.AddOption(PathOption);
            command.AddOption(OutputPathOption);

            return command;
        }
    }
}