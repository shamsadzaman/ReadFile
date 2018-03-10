using System;
using System.Collections.Generic;
using System.IO;

namespace ReadFile
{
    public class FileHandler
    {
        private readonly string[] _fileDirectories;

        public Dictionary<string, int> WordCountDictionary { get; private set; }

        public FileHandler(string[] fileDirectories)
        {
            _fileDirectories = fileDirectories;
            if (WordCountDictionary == null)
            {
                WordCountDictionary = new Dictionary<string, int>();
            }
        }

        public void WriteDictionaryData()
        {
            foreach (var word in WordCountDictionary)
            {
                Console.WriteLine($"{word.Key}\t\t: {word.Value}");
            }
        }

        public void Start()
        {
            foreach (var fileDirectory in _fileDirectories)
            {
                if (!Directory.Exists(fileDirectory))
                {
                    Console.WriteLine("ERROR: File doesn't exist");
                    continue;
                }

                var dir = new DirectoryInfo(fileDirectory);

                var files = dir.GetFiles("*.txt");

                foreach (var file in files)
                {
                    using (var streamReader = File.OpenText(file.FullName))
                    {
                        Console.Write($"Processing: {file.FullName}.....");
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            var words = line.Split(' ', ',', '.');

                            foreach (var word in words)
                            {
                                if (WordCountDictionary.ContainsKey(word))
                                {
                                    WordCountDictionary[word]++;
                                }
                                else
                                {
                                    WordCountDictionary.Add(word, 1);
                                }
                            }
                        }
                        Console.WriteLine("..Done");
                    }
                }
            }
        }
    }
}