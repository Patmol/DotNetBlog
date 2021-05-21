using DotLiquid;

namespace dnb.Tools.Build.Model
{
    [LiquidType("*")]
    public class Category
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; }
    }
}