using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace OOP_Assignment
{
    // Абстрактный класс
    public abstract class Assignments
    {
        protected string input;
        protected object output;

        public Assignments(string input)
        {
            this.input = input;
        }

        public abstract void Solve();

        public override string ToString()
        {
            return $"Вход: {input}\nВыход: {output}";
        }
    }

    // Класс-наследник 
    public class Assignment1 : Assignments
    {
        public Assignment1(string input) : base(input) { }

        public override void Solve()
        {
            string[] words = input.Split(' ');
            HashSet<char> commonChars = new HashSet<char>();

            foreach (char c in words[0].ToLower())
            {
                if (words[1].ToLower().Contains(c))
                {
                    commonChars.Add(c);
                }
            }

            output = string.Join(",", commonChars);
        }
    }

    // Класс-наследник 
    public class Assignment2 : Assignments
    {
        public Assignment2(string input) : base(input) { }

        public override void Solve()
        {
            string[] words = input.Split();
            int totalSyllables = 0;

            foreach (string word in words)
            {
                int syllables = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (i > 0 && word[i] == word[i - 1])
                    {
                        continue;
                    }
                    else if ("AEIOUaeiou".Contains(word[i]))
                    {
                        syllables++;
                    }
                }
                totalSyllables += syllables;
            }

            output = ((double)totalSyllables / words.Length).ToString("0.00");
        }
    }

    class Program
    {
        // Создание папки и файлов
        public static void CreateFiles()
        {
            string folderPath = @"C:\Users\" + Environment.UserName + @"\m2315398_solution\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            File.WriteAllText(folderPath + @"task_1.json", "");
            File.WriteAllText(folderPath + @"task_2.json", "");
        }

        static void Main(string[] args)
        {
            Assignments assignment1 = new Assignment1(Console.ReadLine());
            Assignments assignment2 = new Assignment2(Console.ReadLine());

            assignment1.Solve();
            assignment2.Solve();

            Console.WriteLine(assignment1);
            Console.WriteLine(assignment2);

            string folderPath = @"C:\Users\" + Environment.UserName + @"\m2315398_solution\";

            string data1 = File.Exists(folderPath + @"task_1.json") ? File.ReadAllText(folderPath + @"task_1.json") : "{}";
            string data2 = File.Exists(folderPath + @"task_2.json") ? File.ReadAllText(folderPath + @"task_2.json") : "{}";

            if (data1 != "{}")
            {
                Assignment1 loadedAssignment1 = JsonSerializer.Deserialize<Assignment1>(data1);
                Console.WriteLine("\nЗадание 1 из файла:\n" + loadedAssignment1);
            }
            if (data2 != "{}")
            {
                Assignment2 loadedAssignment2 = JsonSerializer.Deserialize<Assignment2>(data2);
                Console.WriteLine("\nЗадание 2 из файла:\n" + loadedAssignment2);
            }

            string json1 = JsonSerializer.Serialize(assignment1);
            string json2 = JsonSerializer.Serialize(assignment2);
            File.WriteAllText(folderPath + @"task_1.json", json1);
            File.WriteAllText(folderPath + @"task_2.json", json2);
        }
    }
}