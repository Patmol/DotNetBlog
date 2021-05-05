using DotLiquid;

namespace DotNetBlog.Cli.Tools.Build.Model
{
    [LiquidType("*")]
    public class Page
    {
        /// <summary>
        /// Gets or sets the title of the blog post.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Url for the blog post.
        /// </summary>
        /// <value></value>
        public string Url
        {
            get
            {
                return $"{this.Title.Replace(' ', '-').ToLower()}.html";
            }
        }

        /// <summary>
        /// Gets or sets the content, in HTML format (from Markdown)
        /// </summary>
        public string Content { get; set; }
    }
}