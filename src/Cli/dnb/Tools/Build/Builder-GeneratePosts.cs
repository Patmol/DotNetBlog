using System;
using System.IO;
using System.Text;
using dnb.Tools.Common;
using DotLiquid;
using Markdig;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        public Builder GeneratePosts()
        {
            if (this.Configuration == null)
            {
                throw new System.NullReferenceException("The configuration must be loaded");
            }

            var blogFiles = Directory.GetFiles($"{this.path}/posts");

            foreach (var blogFile in blogFiles)
            {
                using (var stream = new StreamReader(blogFile))
                using (var postPage = new StreamReader($"{this.path}/layout/post.html"))
                {
                    var blogFileContent = stream.ReadToEnd();

                    // Search for the meta information on the post.
                    var blogContent = blogFileContent.Split("---");

                    if (blogContent.Length < 3)
                    {
                        throw new FormatException($"The post {blogFile} is incorrectly formated");
                    }

                    var content = new StringBuilder();

                    for (int i = 2; i < blogContent.Length; i++)
                    {
                        content.Append(blogContent[i]);
                    }

                    var post = deserializer.Deserialize<Model.Post>(blogContent[1]);
                    post.Content = Template
                            .Parse(postPage.ReadToEnd())
                            .Render(localVariables: Hash.FromAnonymousObject(new
                            {
                                title = post.Title,
                                author = post.Author,
                                date = post.Date,
                                post = Markdown.ToHtml(content.ToString(), pipeline),
                            }));
                    post.ReadingTime = ReadingTime.CalculateReadingTime(Markdown.ToPlainText(blogContent[2]));

                    if (string.IsNullOrWhiteSpace(post.Summary))
                    {
                        post.Summary = $"{Markdown.ToPlainText(blogContent[2]).Substring(0, 200)}...";
                    } 
                    else if (post.Summary.Length > 200)
                    {
                        post.Summary = $"{post.Summary.Substring(0, 200)}...";
                    }
                    
                    this.posts.Add(post);
                }
            }

            return this;
        }
    }
}