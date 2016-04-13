using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Parser.App.Logic;
using Parser.App.Models;

namespace Parser.App
{
    internal class Program
    {
        private const string DefaultPath = @"Content\input.txt";
        private const string ResultPath = @"Content\output.txt";

        private static void Main(string[] args)
        {
            var filePath = args.Length > 0 ? args[0] : DefaultPath;

            try
            {
                var parser = new WordParser();
                parser.Parse(filePath);

                Console.WriteLine("Total words: {0}. Different words: {1}", parser.Result.TotalWordsCount, parser.Result.DifferentWordsCount);
                Console.WriteLine("Least used word: '{0}'. Usages count: {1}", parser.Result.LeastUsedWord.Word, parser.Result.LeastUsedWord.UsagesCount);
                Console.WriteLine("Most used word: '{0}'. Usages count: {1}", parser.Result.MostUsedWord.Word, parser.Result.MostUsedWord.UsagesCount);

                SaveResultToFile(ResultPath, parser.Result);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File '{0}' could not be found. Please specify path to existing file or use 'Content\\input.txt' file", ex.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        private static void SaveResultToFile(string path, ParseResult result)
        {
            Console.WriteLine("\nSaving usages for each word to file...");

            var fileContent = new List<string>
            {
                string.Format("Total words: {0}. Different words: {1}", result.TotalWordsCount, result.DifferentWordsCount)
            };

            var resultLines = result.WordUsages.Select(u => string.Format("Word: '{0}'. Usages count: {1}", u.Word, u.UsagesCount));
            fileContent.AddRange(resultLines);

            File.WriteAllLines(path, fileContent);
            Console.WriteLine("Full result has been saved to 'Content\\output.txt' file");
        }
    }
}
