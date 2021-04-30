using System;
using System.Collections.Generic;
using System.IO;
using DotLiquid;
using DotLiquid.FileSystems;
using DotNetBlog.Cli.Tools.Build.Model;
using Markdig;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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

            var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)  
                    .Build();

            var blogFiles = Directory.GetFiles($"{this.path}/posts");
            var blogPosts = new List<Post>();

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
                    post.Content = Markdown.ToHtml(blogContent[2]);

                    blogPosts.Add(post);
                }
            }
            

            // Generate the layout page
            var template = Template
                .Parse(
                    new StreamReader($"{this.path}/layout/layout.html").ReadToEnd())
                .Render(Hash.FromAnonymousObject(new {
                    configuration = this.configuration
                }));

            return this;
        }
    }
}