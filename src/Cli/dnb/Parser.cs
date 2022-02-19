using System.CommandLine;
using System.CommandLine.Builder;
using DotNetBlog.Cli.Commands.Build;

namespace DotNetBlog.Cli
{
    public static class Parser
    {
        public static readonly Option HelpOption = new Option<string>(new [] { "--help" });

        private static readonly RootCommand rootCommand = new();

        private static readonly Command[] commands = new []
        {
            BuildCommandParser.GetCommand(),
            ServeCommandParser.GetCommand()
        };

        private static Command ConfigureCommandLine(Command rootCommand)
        {
            // Add commands
            foreach (var command in commands)
            {
                rootCommand.AddCommand(command);
            }

            rootCommand.AddOption(HelpOption);

            return rootCommand;
        }

        public static System.CommandLine.Parsing.Parser Instance { get; } = 
            new CommandLineBuilder(ConfigureCommandLine(rootCommand))
                .Build();
    }
}