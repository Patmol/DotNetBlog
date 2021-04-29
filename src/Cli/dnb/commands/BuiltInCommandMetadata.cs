using System;

namespace DotNetBlog.Cli.Commands
{
    public class BuiltInCommandMetadata
    {
        public Func<string[], int> Command { get; set; }
    }
}