using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace File_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Which file you'd like to parse?");
            JsonObject obj = new JsonObject();
            obj.fileName = Console.ReadLine().Trim();   
            try
            {
                using (StreamReader sr = new StreamReader(obj.fileName, System.Text.Encoding.Default))
                {
                    string line;
                    string pattern1 = @"\W+|(\w+-\w+)";         
                    string pattern2 = @"(\W+)|(\d+,\d+)|(\d+\.\d+)";        

                    obj.fileSize = sr.BaseStream.Length;

                    while ((line = sr.ReadLine()) != null)
                    {
                        obj.linesCount++;
                        obj.punctuation += Regex.Matches(line, @"\.|,|:|;|'|""").Count(); 
                        obj.digitsCount += Regex.Matches(line, @"\d").Count();

                        var someWords = Regex.Split(line, pattern1, RegexOptions.IgnoreCase).Where(a =>
                        {
                            foreach (char z in a) if (!char.IsLetter(z) && z != '-') return false;
                            return true;
                        }).Where(z => z != "");
                        foreach (string z in someWords)
                        {
                            if (!obj.words.ContainsKey(z)) obj.words.Add(z, 1);
                            else obj.words[z]++;
                            if (z.Contains('-')) obj.wordsWithHyphen++;
                        }
                        obj.wordsCount += someWords.Count();

                        foreach (char z in line)
                        {
                            if (char.IsLetter(z) && !obj.letters.ContainsKey(z)) obj.letters.Add(z, 1);
                            else if (char.IsLetter(z)) obj.letters[z]++;
                        }

                        obj.numbersCount += Regex.Split(line, pattern2, RegexOptions.IgnoreCase).Where(a =>
                        {
                            foreach (char z in a) if (!char.IsDigit(z) && z != '.' && z != ',') return false;
                            return true;
                        }).Where(z => z != "").Count();

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return;
            }

            obj.lettersCount = obj.letters.Values.Sum();
            obj.letters = obj.letters.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value); ;
            obj.words = obj.words.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            obj.longestWord = obj.words.Keys.Where(k => k.Length == (obj.words.Keys.Select(key => key.Length).Max())).First();

            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                IgnoreNullValues = true,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize<JsonObject>(obj, options);

            try
            {
                File.WriteAllText($"{obj.fileName}.json", json);
                Console.WriteLine(@$"Resulting JSON file can be found in the project folder (<project name>\bin\Debug\net5.0\{obj.fileName}.json)");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error aborting\n{e.Message}");
            }
        }
    }
}
