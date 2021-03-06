using System;
using System.IO;
using System.Linq;
using System.Text;
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
                Icon = "fa-home",
                Url = "index.html"
            });

            var pageFiles = Directory.GetFiles($"{this.path}/pages");

            foreach (var pageFile in pageFiles)
            {
                if (pageFile.Contains("tags") && !this.Configuration.PageDetails.Tags)
                {
                    continue;
                }

                if (pageFile.Contains("categories") && !this.Configuration.PageDetails.Categories)
                {
                    continue;
                }

                if (pageFile.Contains("archives") && !this.Configuration.PageDetails.Archives)
                {
                    continue;
                }

                using (var stream = new StreamReader(pageFile))
                {
                    var blogFileContent = stream.ReadToEnd();

                    // Search for the meta information on the post.
                    var pageContent = blogFileContent.Split("---");

                    if (pageContent.Length < 3)
                    {
                        throw new FormatException($"The page {pageFile} is incorrectly formated");
                    }

                    var content = new StringBuilder();

                    for (int i = 2; i < pageContent.Length; i++)
                    {
                        content.Append(pageContent[i]);
                    }

                    var page = deserializer.Deserialize<Model.Page>(pageContent[1]);
                    page.Content = Template
                        .Parse(content.ToString())
                        .Render(Hash.FromAnonymousObject(new {
                            tags = this.tags.ToList(),
                            categories = this.categories.ToList(),
                            archives = this.posts
                                .GroupBy(post => post.Date.Year)
                                .Select(postGroup => new {
                                    year = postGroup.Key,
                                    posts = this.posts
                                        .Where(post => post.Date.Year == postGroup.Key)
                                        .OrderByDescending(i => i.Date)
                                        .ToList()
                                })
                        }));

                    this.pages.Add(page);
                    this.Menu.Add(new () {
                        Text = page.Title,
                        Icon = page.Icon ?? "fa-home",
                        Url = page.Url,
                        Order = page.Order
                    });
                }
            }

            return this;
        }
    }
}