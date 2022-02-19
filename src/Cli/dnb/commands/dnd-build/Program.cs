using System;
using System.CommandLine.Parsing;
using System.IO;
using DotNetBlog.Cli.Tools.Build;
using DotNetBlog.Cli.Tools.Common;

namespace DotNetBlog.Cli.Commands.Build
{
    public class BuildTopCommand : CommandBase
    {
        protected override string CommandName => "build";

        public BuildTopCommand(ParseResult parseResult) : base(parseResult)
        {
        }

        public static int Run(string[] args)
        {
            var command = new BuildTopCommand(Parser.Instance.Parse(args.GetCommandParameter()));
            return command.Execute();
        }

        public override int Execute()
        {
            return new BlogBuild(
                BlogPath.GetBlogPath(ParseResult),
                BlogPath.GetBlogOutputPath(ParseResult))
                .Execute();
        }
    }
}