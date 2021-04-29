namespace DotNetBlog.Cli.Utils
{
    public class Product
    {
        public static string LongName => "DotNetBlog";
        public static readonly string Version = GetProductVersion();

        private static string GetProductVersion()
        {
            return "0.0.1";
        }
    }
}