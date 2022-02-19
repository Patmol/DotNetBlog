using System;
using Spectre.Console;

namespace DotNetBlog.Cli.Tools.Build
{
    public  class BlogBuild
    {
        private string path;
        private string outputPath;

        public BlogBuild(string path, string outputPath = null)
        {
            this.path = path;
            this.outputPath = outputPath;
        }

        public int Execute()
        {
            AnsiConsole.Markup($"[bold]Start building blog from {this.path}\n[/]");

            var builder = new Builder(this.path, this.outputPath)
                .LoadConfiguration()
                .GeneratePosts()
                .GeneratePages()
                .GenerateTagPages()
                .GenerateCategoryPages()
                .GenerateHtmlFiles();

            AnsiConsole.Markup($"Build finish. Files available in [bold]{builder.DistFolder}[/]\n");

            return 0;
        }
    }
}