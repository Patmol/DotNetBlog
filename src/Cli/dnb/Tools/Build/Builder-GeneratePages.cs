using System;
using System.IO;
using DotLiquid;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        public Builder GeneratePages()
        {
            if (this.configuration == null)
            {
                throw new System.NullReferenceException("The configuration must be loaded");
            }

            var pageFiles = Directory.GetFiles($"{this.path}/pages");

            foreach (var pageFile in pageFiles)
            {
                using (var stream = new StreamReader(pageFile))
                {
                    var blogFileContent = stream.ReadToEnd();

                    // Search for the meta information on the post.
                    var pageContent = blogFileContent.Split("---");

                    if (pageContent.Length != 3)
                    {
                        throw new FormatException($"The page {pageFile} is incorrectly formated");
                    }

                    var page = deserializer.Deserialize<Model.Page>(pageContent[1]);
                    page.Content = Template
                        .Parse(pageContent[2])
                        .Render(Hash.FromAnonymousObject(new {
                            tags = this.tags,
                            categories = this.categories
                        }));

                    this.pages.Add(page);
                }
            }


            return this;
        }
    }
}