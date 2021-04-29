using System.CommandLine;

namespace DotNetBlog.Cli.Commands.Build
{
    internal class ServeCommandParser
    {
        public static Command GetCommand()
        {
            var command = new Command("serve");
            return command;
        }
    }
}