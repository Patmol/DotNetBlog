using System.Collections.Generic;
using System.Linq;
using dnb.Tools.Build.Model;
using DotLiquid;
using DotNetBlog.Cli.Tools.Build.Model;
using Markdig;
using Markdig.SyntaxHighlighting.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DotNetBlog.Cli.Tools.Build
{
    [LiquidType(nameof(path), nameof(tags), nameof(trendingTags), nameof(categories))]
    public partial class Builder
    {
        private string path;
        private ICollection<Page> pages;
        private ICollection<Post> posts;
        private IEnumerable<string> tags => this.posts.SelectMany(post => post.Tags).Distinct();
        private IEnumerable<string> trendingTags => this.tags
            .Select(tag => new {
                tag = tag,
                count = this.posts.SelectMany(post => post.Tags).Count(t => t == tag)
            })
            .OrderBy(tag => tag.count)
            .Take(5)
            .Select(tag => tag.tag);
            
        private IEnumerable<Category> categories => this.posts
            .SelectMany(post => post.Categories)
            .Distinct()
            .Select(category => new Category {
                Name = category,
                Count = this.posts.SelectMany(post => post.Categories).Count(c => c == category)
            });
        
        public Configuration Configuration { get; private set; }
        public ICollection<Menu> Menu { get; private set; }

        private MarkdownPipeline pipeline = new MarkdownPipelineBuilder()
                    .UseAdvancedExtensions()
                    .UseSyntaxHighlighting(true)
                    .Build();

        private IDeserializer deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)  
                    .Build();

        public Builder(string path)
        {
            this.path = path;
            this.posts = new List<Post>();
            this.pages = new List<Page>();
            this.Menu = new List<Menu>();
        }
    }
}