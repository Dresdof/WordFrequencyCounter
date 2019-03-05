using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WordFrequencyCounter
{
    class Program
    {
        private static Dictionary<string, int> words = new Dictionary<string, int>();

        private Regex wordCharacters = new Regex(@"\w");

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
                    foreach (string word in line.Split(' '))
                    {
                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                        else words.Add(word, 1);
                    }


                }
            }
        }
    }
}
