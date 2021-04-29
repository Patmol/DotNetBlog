using System;
using System.IO;
using DotLiquid;
using DotLiquid.FileSystems;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        public Builder GenerateHtmlFiles()
        {
            if (this.configuration == null)
            {
                throw new System.NullReferenceException("The configuration must be loaded");
            }

            Template.FileSystem = new LocalFileSystem($"{this.path}/includes"); 

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