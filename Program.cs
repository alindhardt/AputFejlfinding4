using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AputFejlfinding4
{
    class Program
    {
        public static void Main(string[] args)
        {
            new Program().HandleProgram();
        }


        public bool isRunning = true;
        public List<string> list = new List<string>();

        void HandleProgram()
        {
            string label = "";

            while (isRunning)
            {
                Console.Clear();
                Console.Write(label);
                Console.Write("?>");
                string input = GetUserInput();

                switch (input)
                {
                    case "-quit":
                        label = QuitProgram();
                        break;
                    case "-list":
                        label = PrintListOfWords();
                        break;
                    case "-sort":
                        label = SortList();
                        break;
                    case "-remove":
                        label = HandleRemove();
                        break;
                    case "-change":
                        label = HandleChange();
                        break;
                    case "-add":
                        label = AddWordsToList();
                        break;
                    case "-help":
                        label = GetHelpText();
                        break;
                    default:
                        label = "Unknown Command " + input;
                        break;
                }

                label += "\n";

            }
        }

        string QuitProgram()
        {
            isRunning = false;
            Console.WriteLine("Quitting Program...");
            return "";
        }

        string AddWordsToList()
        {
            int numberOfWordsAdded = 0;
            Console.WriteLine("Write the words you want to add to the list:");
            string word = GetUserInput();
            while (word != "-done")
            {
                if (word.Length > 0)
                {
                    string[] strings = word.Split(' ');
                    foreach (string s in strings)
                    {
                        list.Add(s);
                        Console.WriteLine("\'{0}\' added to list!", s);
                        numberOfWordsAdded++;
                    }
                }
                word = GetUserInput();
            }

            return "" + numberOfWordsAdded + " words added!";
        }

        string PrintListOfWords()
        {
            Console.WriteLine("---");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("---");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return "";
        }

        string SortList()
        {
            list.Sort();
            return "";
        }

        string GetUserInput()
        {
            string userInput = Console.ReadLine();
            userInput = userInput.Trim();
            userInput = userInput.ToLower();
            return userInput;
        }

        string HandleRemove()
        {
            Console.WriteLine("What word would you like to remove?");
            string input = GetUserInput();

            int indexOfInput = list.IndexOf(input);
            if (indexOfInput >= 0)
            {
                list.RemoveAt(indexOfInput);
                return input + " removed!\n";
            }
            return input + " not found in list\n";
        }

        string HandleChange()
        {
            Console.WriteLine("What word would you like to change?");
            string input = GetUserInput();
            int indexOfWord = list.IndexOf(input);

            if (indexOfWord != -1)
            {
                return input + "not found in list\n";
            }
            Console.WriteLine("What would you like to change " + input + " to?\n");
            input = GetUserInput();
            list[indexOfWord] = input;
            return "change successful!\n";
        }

        string GetHelpText()
        {
            return @"Commands:
-add: starts adding mode, allowing the user to add words to the list.
-list: prints a list of current words in the program.
-sort: sorts the list alphabetically.
-change: allows you to change words in the list.
-remove: allows you to remove words in the list.
-help: shows this menu.
-quit: closes the program.";
        }
    }
}
