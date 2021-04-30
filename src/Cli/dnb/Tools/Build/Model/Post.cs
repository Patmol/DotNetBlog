using System;
using System.Collections.Generic;

namespace DotNetBlog.Cli.Tools.Build.Model
{
    public class Post
    {
        /// <summary>
        /// Gets or sets the title of the blog post.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the Url for the blog post.
        /// </summary>
        /// <value></value>
        public string Url { 
            get
            {
                return $"{this.Title.Replace(' ', '-').ToLower()}.html";
            } 
        }
        
        /// <summary>
        /// Gets or sets the publication of the post.
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Gets or sets the list of categories
        /// </summary>
        public IEnumerable<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the list of tags
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the content, in HTML format (from Markdown)
        /// </summary>
        public string Content { get; set; }
    }
}