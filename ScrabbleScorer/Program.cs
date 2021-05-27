using System;
using System.Collections.Generic;

namespace ScrabbleScorer
{
    class Program
    {
        public static Dictionary<int, string> oldScoreKeeper = new Dictionary<int, string>()
        {
            {1, "a, e, i, o, u, l, n, r, s, t"},
            {2, "d, g"},
            {3, "b, c, m, p" },
            {4, "f, h, v, w, y" },
            {5, "k" },
            {8, "j, x" },
            {10, "q, z" }
        };

        public static Dictionary<char, int> Transform()
        {
            Dictionary<char, int> newDict = new Dictionary<char, int>();

            foreach (KeyValuePair<int, string> oSK in oldScoreKeeper)
            {
                string[] strChar = oSK.Value.Split(", ");  //deliminator is a string
                foreach (string str in strChar)
                {
                    char ch = Convert.ToChar(str);
                    newDict.Add(ch, oSK.Key);
                }
            }
            return newDict;
        }


        public static void ScrabbleScorer(string word)
        {
            Dictionary<char, int> newScoreKeeper = Transform();  //using my new dictionary thanks to this method

            int totalScore = 0;  

            foreach (KeyValuePair<char, int> score in newScoreKeeper)
            {
                foreach (char ch in word)
                {
                    if (score.Key == ch)
                    {
                        totalScore += score.Value;
                    }
                }
            }

            Console.WriteLine($"Your word: {word} is worth {totalScore}");
            Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
        }


        public static void SimpleScorer(string word)
        {
            int totalScore = word.Length;

            Console.WriteLine($"Your word: {word} is worth {totalScore}");
            Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
        }

        public static void BonusVowels(string word)
        {
            int totalScore = 0;
            foreach (char ch in word)
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                {
                    totalScore += 3;
                }
                else
                {
                    totalScore += 1;
                }
            }
            Console.WriteLine($"Your word: {word} is worth {totalScore}");
            Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
        }

        //was InitialPrompt()
        public static void StartProgram()
        {
            Console.WriteLine($"How do you wish to score your scrabble words?" +
                "\n 1: Scrabble - the traditional score method" +
                "\n 2: Simple Score - each letter is worth 1 point " +
                "\n 3: Bonus Vowels - vowels are worth 3 points, consonants 1 point each");

            string inputOption = Console.ReadLine();
            int inputPoints = int.Parse(inputOption);

            Console.WriteLine("Please type in your word followed by enter.  If you wish to end your session type: STOP");

            SelectOption(inputPoints);
        }


        public static void SelectOption(int option)
        {
            bool done = false;

            while (done == false)
            {
                string userWord = Console.ReadLine();
                string lowerWord = userWord.ToLower();

                if (lowerWord == "stop")
                {
                    Console.WriteLine("Thank you for playing"); //for my testing
                    done = true;
                }
                else
                {

                    if (option == 1)
                    {
                        ScrabbleScorer(lowerWord);
                    }

                    else if (option == 2)
                    {
                        SimpleScorer(lowerWord);
                    }

                    else if (option == 3)
                    {
                        BonusVowels(lowerWord);
                    }

                }

            }
        }


        //public static void RunProgram()
        //{
        //    InitialPrompt();
        //}



        static void Main(string[] args)
        {
            Dictionary<char, int> testDictionary = Transform();

            foreach(KeyValuePair<char,int> test in testDictionary)
            {
                Console.WriteLine($"{test.Key} + {test.Value}");
                    }

            Console.WriteLine(testDictionary['a']);
            Console.WriteLine(testDictionary['j']);

            StartProgram();
          // RunProgram();
        } 
    } 
}
