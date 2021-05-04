using System;
using System.Collections.Generic;

namespace DotNetBlog.Cli.Tools.Build.Model
{
    public class Post : Page
    {    
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
    }
}