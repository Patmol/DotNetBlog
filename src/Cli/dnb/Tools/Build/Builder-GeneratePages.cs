using System;
using System.IO;
using System.Linq;
using DotLiquid;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        public Builder GeneratePages()
        {
            if (this.Configuration == null)
            {
                throw new System.NullReferenceException("The configuration must be loaded");
            }

            // Add the Home page menu entry
            this.Menu.Add(new () {
                Text = "Home",
                Url = "index.html"
            });

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
                            tags = this.tags.ToList(),
                            categories = this.categories.ToList()
                        }));

                    this.pages.Add(page);
                    this.Menu.Add(new () {
                        Text = page.Title,
                        Url = page.Url
                    });
                }
            }

            return this;
        }
    }
}