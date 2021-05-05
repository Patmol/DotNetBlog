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

            return this;
        }
    }
}