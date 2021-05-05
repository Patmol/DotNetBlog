using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DotNetBlog.Cli.Tools.Build
{
    public partial class Builder
    {
        public Builder LoadConfiguration()
        {
            using (var stream = new StreamReader($"{this.path}/config.yml"))
            {
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .Build();

                this.Configuration = deserializer.Deserialize<Model.Configuration>(stream);
            }

            return this;
        }
    }
}