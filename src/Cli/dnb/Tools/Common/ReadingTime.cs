namespace dnb.Tools.Common
{
    public static class ReadingTime
    {
        private static int wordsByMinute = 200;

        public static int CalculateReadingTime(string text)
        {
            var numberOfWords = text.Split(' ').Length;

            return (numberOfWords / wordsByMinute) + 1;
        }
    }
}