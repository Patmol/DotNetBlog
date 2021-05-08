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
        public string Url
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Folder))
                {
                    return $"{this.Title.Replace(' ', '-').ToLower()}.html";
                }
                else
                {
                    return $"{this.Folder}/{this.Title.Replace(' ', '-').ToLower()}.html";
                }
            }
        }

        /// <summary>
        /// Gets or sets the folder for this page.
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Gets or sets the icon used in the menu
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the order of the page
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the content, in HTML format (from Markdown)
        /// </summary>
        public string Content { get; set; }
    }
}