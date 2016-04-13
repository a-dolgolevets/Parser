using System.Collections.Generic;
using System.Linq;

namespace Parser.App.Models
{
    public class ParseResult
    {
        public ParseResult(IEnumerable<WordUsage> usages)
        {
            WordUsages = usages.OrderBy(u => u.UsagesCount);

            TotalWordsCount = WordUsages.Sum(u => u.UsagesCount);
            DifferentWordsCount = WordUsages.Count();
            LeastUsedWord = WordUsages.First();
            MostUsedWord = WordUsages.Last();
        }

        public int TotalWordsCount { get; set; }

        public int DifferentWordsCount { get; set; }

        public WordUsage LeastUsedWord { get; set; }

        public WordUsage MostUsedWord { get; set; }

        public IEnumerable<WordUsage> WordUsages { get; set; }
    }
}