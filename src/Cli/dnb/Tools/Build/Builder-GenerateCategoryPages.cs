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

            return this;
        }
    }
}