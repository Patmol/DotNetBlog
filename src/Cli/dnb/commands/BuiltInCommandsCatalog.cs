using System.Collections.Generic;
using DotNetBlog.Cli.Commands.Build;
using DotNetBlog.Cli.Commands.Serve;

namespace DotNetBlog.Cli.Commands
{
    public static class BuiltInCommandsCatalog
    {
        public static Dictionary<string, BuiltInCommandMetadata> Commands = new Dictionary<string, BuiltInCommandMetadata>
        {
            ["build"] = new BuiltInCommandMetadata()
            {
                Command = BuildTopCommand.Run
            },
            ["serve"] = new BuiltInCommandMetadata()
            {
                Command = ServeTopCommand.Run
            }
        };
    }
}