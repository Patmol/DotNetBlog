
using DotLiquid;
using YamlDotNet.Serialization;

namespace DotNetBlog.Cli.Tools.Build.Model
{
    [LiquidType("*")]
    public class Configuration
    {        
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        
        [YamlMember(typeof(Page), Alias = "page_details")]
        public Page PageDetails { get; set; }

        public class Page 
        {
            public bool Tags { get; set; }
            public bool Categories { get; set; }
        }
    }
}