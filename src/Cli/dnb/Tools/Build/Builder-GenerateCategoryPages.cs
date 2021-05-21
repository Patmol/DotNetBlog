using System.IO;
using System.Linq;
using DotLiquid;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        public Builder GenerateCategoryPages()
        {
            if (!this.Configuration.PageDetails.Categories)
            {
                return this;
            }

            foreach (var category in this.categories)
            {
                using (var categoryPage = new StreamReader($"{this.path}/layout/category.html"))
                {
                    this.pages.Add(new Model.Page()
                    {
                        Content = Template
                            .Parse(categoryPage.ReadToEnd())
                            .Render(Hash.FromAnonymousObject(new
                            {
                                category = category,
                                posts = this.posts.Where(i => i.Categories.Contains(category.Name)).ToList()
                            })),
                        Folder = "categories",
                        Title = $"{category.Name}",
                    });
                }
            }

            return this;
        }
    }
}