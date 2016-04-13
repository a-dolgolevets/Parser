using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Parser.App.Models;

namespace Parser.App.Logic
{
    public class WordParser
    {
        public ParseResult Result { get; private set; }

        public void Parse(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file could not be found", filePath);
            }

            var words = Regex.Split(File.ReadAllText(filePath), @"[^a-zA-Z0-9_']+");
            var usagesList = words.GroupBy(word => word).Select(grouped => new WordUsage(grouped.Key, grouped.Count()));
            Result = new ParseResult(usagesList);
        }
    }
}