using System.IO;
using System.Linq;
using DotLiquid;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        public Builder GenerateTagPages()
        {
            if (!this.Configuration.PageDetails.Tags)
            {
                return this;
            }

            using (var tagPage = new StreamReader($"{this.path}/layout/tag.html"))
            {
                foreach (var tag in this.tags)
                {
                    this.pages.Add(new Model.Page()
                    {
                        Content = Template
                            .Parse(tagPage.ReadToEnd())
                            .Render(Hash.FromAnonymousObject(new {
                                tag = tag,
                                posts = this.posts.ToList()
                            })),
                        Folder = "tags",
                        Title = $"{tag}",
                    });
                }
            }

            return this;
        }
    }
}