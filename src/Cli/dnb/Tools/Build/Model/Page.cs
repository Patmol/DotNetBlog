using System;
using System.Web;
using DotLiquid;

namespace DotNetBlog.Cli.Tools.Build.Model
{
    [LiquidType("*")]
    public class Page
    {
        /// <summary>
        /// Gets the title without space and in lower case.
        /// </summary>
        /// <value></value>
        private string titleEscapeSpace
        {
            get
            {
                return this.Title.Replace(' ', '-').ToLower();
            }
        }

        /// <summary>
        /// Gets or sets the title of the blog post.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Url for the blog post.
        /// </summary>
        public string Filename
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Folder))
                {
                    return $"{titleEscapeSpace}.html";
                }
                else
                {
                    return $"{this.Folder}/{titleEscapeSpace}.html";
                }
            }
        }

        /// <summary>
        /// Gets or sets the Url for the blog post.
        /// </summary>
        public string Url
        {
            get
            {
                var title = HttpUtility.UrlEncode(titleEscapeSpace);

                if (string.IsNullOrWhiteSpace(this.Folder))
                {
                    return $"{title}.html";
                }
                else
                {
                    return $"{this.Folder}/{title}.html";
                }
            }
        }

        /// <summary>
        /// Gets or sets he author of the post.
        /// </summary>
        public string Author { get; set; }

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