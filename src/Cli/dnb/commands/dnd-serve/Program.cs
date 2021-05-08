using System;
using System.CommandLine.Parsing;

namespace DotNetBlog.Cli.Commands.Serve
{
    public class ServeTopCommand : CommandBase
    {
        protected override string CommandName => "serve";

        public ServeTopCommand(ParseResult parseResult) : base(parseResult)
        {
        }

        public static int Run(string[] args)
        {
            var command = new ServeTopCommand(Parser.Instance.Parse(args.GetCommandParameter()));
            return command.Execute();
        }

        public override int Execute()
        {
            return 0;
        }
    }
}