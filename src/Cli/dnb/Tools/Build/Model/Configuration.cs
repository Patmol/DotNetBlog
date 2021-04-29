
using DotLiquid;

namespace DotNetBlog.Cli.Tools.Build.Model
{
    [LiquidType("*")]
    public class Configuration
    {        
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
    }
}