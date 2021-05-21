using System;
using System.IO;
using System.Linq;
using System.Text;
using DotLiquid;
using DotLiquid.FileSystems;
using DotNetBlog.Cli.Utils;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        private string distFolder => $"{this.path}/dist";
        private string postsFolder => $"{this.distFolder}/posts";
        private string assetsFolder => $"{this.distFolder}/assets";

        public Builder GenerateHtmlFiles()
        {
            if (this.Configuration == null)
            {
                throw new System.NullReferenceException("The configuration must be loaded");
            }

            Template.FileSystem = new LocalFileSystem($"{this.path}/includes"); 

            // Delete the /dist folder and its content
            if (Directory.Exists(distFolder))
            {
                Directory.Delete(distFolder, true);
            }
            // Create the /dist folder.
            Directory.CreateDirectory(distFolder);

            this.GenerateHtmlIndexPage();
            this.GenerateHtmlPostPages();
            this.GenerateHtmlPages();
            this.CopyAssets();

            return this;
        }

        private void GenerateHtmlIndexPage() 
        {
            using (var indexPage = new StreamReader($"{this.path}/layout/index.html"))
            {
                var index = Template
                    .Parse(
                        new StreamReader($"{this.path}/layout/index.html").ReadToEnd())
                    .Render(Hash.FromAnonymousObject(new {
                        posts = this.posts.ToList()
                    }));

                // Write the file into the dist folder.
                using (var fileStream = File.Create($"{distFolder}/index.html"))
                {
                    var byteArray = Encoding.ASCII.GetBytes(ApplyLayout(index));
                    fileStream.Write(byteArray, 0, byteArray.Length);
                }
            }
        }

        private void GenerateHtmlPostPages()
        {
            Directory.CreateDirectory(postsFolder);

            foreach (var post in this.posts)
            {
                using (var fileStream = File.Create($"{postsFolder}/{post.Url}"))
                {
                    var byteArray = Encoding.ASCII.GetBytes(ApplyLayout(post.Content));
                    fileStream.Write(byteArray, 0, byteArray.Length);
                }
            }
        }

        private void GenerateHtmlPages()
        {
            foreach (var page in this.pages)
            {
                if (!string.IsNullOrWhiteSpace(page.Folder))
                {
                    Directory.CreateDirectory($"{distFolder}/{page.Folder}");
                }

                using (var fileStream = File.Create($"{distFolder}/{page.Url}"))
                {
                    var byteArray = Encoding.ASCII.GetBytes(ApplyLayout(page.Content));
                    fileStream.Write(byteArray, 0, byteArray.Length);
                }
            }
        }

        private string ApplyLayout(string content)
        {
            return Template
                    .Parse(
                        new StreamReader($"{this.path}/layout/layout.html").ReadToEnd())
                    .Render(Hash.FromAnonymousObject(new {
                        configuration = this.Configuration,
                        menuEntries = this.Menu.OrderBy(menu => menu.Order).ToList(),
                        socialNetworks = this.Configuration.SocialNetworks,
                        latestPosts = this.posts.OrderByDescending(i => i.Date).Take(5).ToList(),
                        trendingTags = this.trendingTags.ToList(),
                        content = content
                    }));
        }
    
        private void CopyAssets()
        {
            DirectoryHelper.CopyFolder($"{this.path}/assets", assetsFolder);
        }
    }
}