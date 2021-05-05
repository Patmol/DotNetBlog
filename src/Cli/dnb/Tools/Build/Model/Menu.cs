using DotLiquid;

namespace dnb.Tools.Build.Model
{
    [LiquidType("*")]
    public class Menu
    {
        public string Text { get; set; }
        public string Url { get; set; }
    }
}