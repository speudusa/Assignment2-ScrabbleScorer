using System;
using System.Collections.Generic;

namespace ScrabbleScorer
{
    class Program
    {
        public static Dictionary<int, string> oldPointStructure = new Dictionary<int, string>()
        {
            {1, "A, E, I, O, U, L, N, R, S, T"},
            {2, "D, G"},
            {3, "B, C, M, P" },
            {4, "F, H, V, W, Y" },
            {5, "K" },
            {8, "J, X" },
            {10, "Q, Z" }
        };



//TRANSFORM
        public static Dictionary<char, int> Transform()
        {
            Dictionary<char, int> newDict = new Dictionary<char, int>();

            foreach (KeyValuePair<int, string> oSK in oldPointStructure)
            {
                string[] strChar = oSK.Value.Split(", ");  
                foreach (string str in strChar)
                {
                    char ch = Convert.ToChar(str.ToLower());
                    newDict.Add(ch, oSK.Key);
                }
            }
            return newDict;
        }



//SCORE OPTIONS
    //1
        public static void ScrabbleScorer(string word, string userWord)
        {
            Dictionary<char, int> newPointStructure = Transform();  //using my new dictionary thanks to this method

            int totalScore = 0;  

            foreach (KeyValuePair<char, int> score in newPointStructure)
            {
                foreach (char ch in word)
                {
                    if (score.Key == ch)
                    {
                        totalScore += score.Value;
                    }
                }
            }

            Console.WriteLine($"Your score for \"{userWord}\": {totalScore}");
        }

    //2
        public static void SimpleScorer(string word, string userWord)
        {
            int totalScore = word.Length;

            Console.WriteLine($"Your score for \"{userWord}\": {totalScore}");
        }

    //3
        public static void BonusVowels(string word, string userWord)
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
            Console.WriteLine($"Your score for \"{userWord}\": {totalScore}");
        }



//INITIAL-PROMPT
        public static void InitialPrompt()
        {
            Console.WriteLine($"How do you wish to score your scrabble words?" +
            "\n\t1: Scrabble - the traditional score method" +
            "\n\t2: Simple Score - each letter is worth 1 point " +
            "\n\t3: Bonus Vowels - vowels are worth 3 points, consonants 1 point each" +
            "\n\n Enter 1, 2, or 3:\n");

        }
        
        

//SCORING-ALGORITHMS
        public static void ScoringAlgorithms(int option, string lowerWord, string userWord)
        {
             if (option == 2)
            {
                SimpleScorer(lowerWord, userWord);   
            }

            else if (option == 3)
            {
                BonusVowels(lowerWord, userWord);
            }
            else
            {
                ScrabbleScorer(lowerWord, userWord);
            }
        }


//RUN PROGRAM
        public static void RunProgram()
        {
            InitialPrompt();
            string inputOption = Console.ReadLine();
            int inputPoints = int.Parse(inputOption);

            bool done = false;
            while (done == false)
            {
                Console.WriteLine("Enter a word to be scored, or 'Stop' to quit:");

                string userWord = Console.ReadLine();
                string lowerWord = userWord.ToLower();

                if (lowerWord == "stop")
                {
                    done = true;
                }
                ScoringAlgorithms(inputPoints, lowerWord, userWord);
            }
        }


// ----------  MAIN  -------------
        static void Main(string[] args)
        {
            RunProgram();
        }
    } 
}
