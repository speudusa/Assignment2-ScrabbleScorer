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

        public static void ScrabbleScorer(string word)
        { 
            Dictionary<char, int> newScoreKeeper = new Dictionary<char, int>();

            foreach (KeyValuePair<int, string> oSK in oldScoreKeeper)
            {
                string[] strChar = oSK.Value.Split(", ");
                foreach (string str in strChar)
                {
                    char ch = Convert.ToChar(str);
                    newScoreKeeper.Add(ch, oSK.Key);
                }
            }

            List<int> letterScore = new List<int>();
            foreach (KeyValuePair<char, int> score in newScoreKeeper)
            {
                foreach (char ch in word)
                {
                    if (score.Key == ch)
                    {
                        letterScore.Add(score.Value);
                    }
                }
            }

            int totalScore = 0;

            foreach (int i in letterScore)
            {
                totalScore += i;
            }
            Console.WriteLine($"Your word: {word} is worth {totalScore}");
            Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");
        }

        public static void SimpleScorer(string word)
        {
            int totalScore = 0;
            foreach (char ch in word)
            {
                totalScore += 1;
            }

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

        public static void WelcomeToProgram()
        {
            Console.WriteLine("How do you wish to score your scrabble words?" +
                "\n 1: Scrabble - the traditional score method" +
                "\n 2: Simple Score - each letter is worth 1 point " +
                "\n 3: Bonus Vowles - vowels are worth 3 points, consonants 1 point each");

            string inputPoints = Console.ReadLine();
            Console.WriteLine("Please type in your word followed by enter.  If you wish to end your session type: STOP");

            ScoreProgram(inputPoints);
        }

        public static void ScoreProgram(string option)
        {
            bool done = false;
            while (done == false)
            {
                string userWord = Console.ReadLine();

                if (userWord == "STOP")
                {
                    Console.WriteLine("Thank you for playing");
                    done = true;
                }
                else
                {
                    string lowerWord = userWord.ToLower();

                    if (option == "1")
                    {
                        ScrabbleScorer(lowerWord);
                    }

                    else if (option == "2")
                    {
                        SimpleScorer(lowerWord);
                    }

                    else if (option == "3")
                    {
                        BonusVowels(lowerWord);
                    }

                }

            }
        }

        static void Main(string[] args)
        { 
           WelcomeToProgram();
        } 
    } 
}
