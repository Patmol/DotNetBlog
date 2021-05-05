
using DotLiquid;
using YamlDotNet.Serialization;

namespace DotNetBlog.Cli.Tools.Build.Model
{
    [LiquidType("*")]
    public class Configuration
    {
        /// <summary>
        /// Gets or sets the title of the blog.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the subtitle of the blog.
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the description of the blog.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the logo of the blog.
        /// </summary>
        public string Logo { get; set; }
        
        /// <summary>
        /// Gets or sets whether the details page must be generated or not.
        /// </summary>
        [YamlMember(typeof(Page), Alias = "page_details")]
        public Page PageDetails { get; set; }

        public class Page 
        {
            /// <summary>
            /// The tags page.
            /// </summary>
            public bool Tags { get; set; }
            
            /// <summary>
            /// The categories page.
            /// </summary>
            public bool Categories { get; set; }
        }
    }
}