using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequencyCounter
{
    class Program
    {
        private const int LIST_COUNT = 30;

        private static Dictionary<string, int> words = new Dictionary<string, int>();

        private static Regex wordCharacters = new Regex(@"\w+");

        static void Main(string[] args)
        {
            Console.WriteLine("Placez votre fichier dans le répertoire du programme et indiquez son nom :");

            string fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Nope");
            }
            else
            {
                ReadFile(fileName);
                PrintTopWords();
            }


            // Hangs until [Enter] is pressed.
            Console.ReadLine();
        }

        private static void ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    foreach(string word in line.Split(' '))
                    {
                        if (!wordCharacters.IsMatch(word))
                        {
                            Debug.WriteLine($"I don't think [{word}] is a word.");
                            continue;
                        }
                        if (word.Length < 4) // Short words are just a pollution. 
                            continue;
                    
                        
                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                        else words.Add(word, 1);
                    }
                }
            }
        }

        private static void PrintTopWords()
        {
            Console.WriteLine($"The {LIST_COUNT} most used words are :");

            List<KeyValuePair<string, int>> myList = words.ToList();

            myList.Sort(
                delegate (KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2)
                {
                    return pair2.Value.CompareTo(pair1.Value);
                }
            );

            for (int i = 0; i < LIST_COUNT; i++)
            {
                Console.WriteLine($" * {myList[i].Key} - {myList[i].Value}");
            }
        }
    }
}
