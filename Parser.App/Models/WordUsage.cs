namespace Parser.App.Models
{
    public class WordUsage
    {
        public WordUsage(string word, int usagesCount)
        {
            Word = word;
            UsagesCount = usagesCount;
        }

        public string Word { get; private set; }

        public int UsagesCount { get; private set; }
    }
}