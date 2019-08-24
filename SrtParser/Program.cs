using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SrtParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"d:\torrents\The Science of Meditation (Русские субтитры)\05. The Science of Emotion and Social-Emotional Learning";
            
            string[] files = System.IO.Directory.GetFiles(path, "*.srt");

            foreach (var filePath in files)
            {
                // This text is added only once to the file.
                if (File.Exists(filePath))
                {
                    // Read Rows File
                    string[] readText = File.ReadAllLines(filePath, Encoding.UTF8);
                    var testWitoutEmpties = readText.Where(s => !string.IsNullOrEmpty(s)).ToList();
                    var count = testWitoutEmpties.Count();
                    var newText = new List<string>();
                    foreach (string s in testWitoutEmpties)
                    {
                        Console.WriteLine(s);
                        Int32 intRow;
                        if (int.TryParse(s, out intRow))
                        {
                            newText.Add(s);
                            continue;
                        }

                        if (s.StartsWith("00:"))
                        {
                            newText.Add(s);
                            continue;
                        }

                        newText.Add(s);
                        newText.Add(string.Empty);
                        newText.Add(string.Empty);
                    }

                    var newFullPath = filePath.Replace(".srt", " (1).srt");

                    File.WriteAllLines(newFullPath, newText, Encoding.UTF8);
                }
            }
        }
    }
}
