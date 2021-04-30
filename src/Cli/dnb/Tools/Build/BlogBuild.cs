using System;
using Spectre.Console;

namespace DotNetBlog.Cli.Tools.Build
{
    public  class BlogBuild
    {
        private string path;

        public BlogBuild(string path)
        {
            this.path = path;
        }

        public int Execute()
        {
            AnsiConsole.Markup($"[bold]Start building blog ({this.path})[/]");

            new Builder(this.path)
                .LoadConfiguration()
                .GeneratePosts()
                .GenerateHtmlFiles();

            return 0;
        }
    }
}