using DotNetBlog.Cli.Tools.Build.Model;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        private string path;
        private Configuration configuration;

        public Builder(string path)
        {
            this.path = path;
        }
    }
}