using System.CommandLine;

namespace DotNetBlog.Cli.Commands.Build
{
    internal static class BuildCommandParser
    {
        public static readonly Option PathOption = new Option<string>(new [] { "--path", "-p" });

        public static Command GetCommand()
        {
            var command = new Command("build");

            command.AddOption(PathOption);

            return command;
        }
    }
}