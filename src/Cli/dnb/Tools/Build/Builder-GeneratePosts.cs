using System;
using System.IO;
using Markdig;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        public Builder GeneratePosts()
        {
            if (this.configuration == null)
            {
                throw new System.NullReferenceException("The configuration must be loaded");
            }

            var blogFiles = Directory.GetFiles($"{this.path}/posts");

            foreach (var blogFile in blogFiles)
            {
                using (var stream = new StreamReader(blogFile))
                {
                    var blogFileContent = stream.ReadToEnd();

                    // Search for the meta information on the post.
                    var blogContent = blogFileContent.Split("---");

                    if (blogContent.Length != 3)
                    {
                        throw new FormatException($"The post {blogFile} is incorrectly formated");
                    }

                    var post = deserializer.Deserialize<Model.Post>(blogContent[1]);
                    post.Content = Markdown.ToHtml(blogContent[2], pipeline);

                    this.posts.Add(post);
                }
            }

            return this;
        }
    }
}