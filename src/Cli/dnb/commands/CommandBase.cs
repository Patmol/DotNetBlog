using System;
using System.CommandLine;
using System.CommandLine.Parsing;

namespace DotNetBlog.Cli.Commands
{
    public abstract class CommandBase
    {
        protected abstract string CommandName { get; }
        protected ParseResult ParseResult { get; private set; }

        protected CommandBase(ParseResult parseResult)
        {
            ParseResult = parseResult;
        }

        public abstract int Execute();
    }
}