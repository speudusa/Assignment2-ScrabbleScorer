using System;
using System.Collections.Generic;

namespace ScrabbleScorer
{
    class Program
    {
        //ORIGINAL DICTIONARY OBJECT
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


        public static int NewDictionaryScorer(string word, Dictionary<char,int>) //UPDATE DICTIONARY
        {
           

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
                return totalScore += i;
            }
        }

        static void Main(string[] args)
        {
            bool done = false;




            //SELECT HOW TO SCORE
            Console.WriteLine("How do you wish to score your scrabble words?" +
                "\n 1: Scrabble - the traditional score method" +
                "\n 2: Simple Score - each letter is worth 1 point " +
                "\n 3: Bonus Vowles - vowels are worth 3 points, consonants 1 point each");

            string inputPoints = Console.ReadLine();   //user types which one -- these are strings

            //directions, including how to stop
            Console.WriteLine("Please type in your word followed by enter.  If you wish to end your session type: STOP");


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

            //1 - SCRABBLE SCORING
                    if(inputPoints == "1")
                    {
                        Dictionary<char, int> newScoreKeeper = new Dictionary<char, int>();
                        //static method - must be held in variable
                        //returns score
                        int totalScore = NewDictionaryScorer(lowerWord);

                        Console.ForegroundColor = ConsoleColor.DarkCyan;  //color change for my testing purposes
                        //passing score here
                        Console.WriteLine($"Your word: {userWord} is worth {totalScore}");  
                        Console.ResetColor(); 
                        Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");

                    }//IF

                    else if(inputPoints == "2")
                    {
                        int totalScore = 0;
                        foreach(char ch in lowerWord)
                        {
                            totalScore += 1;
                        }
                        Console.ForegroundColor = ConsoleColor.DarkCyan;  
                        Console.WriteLine($"Your word: {userWord} is worth {totalScore}");
                        Console.ResetColor();
                        Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");

                    }//ELSE IF # 1

                    else if(inputPoints == "3")
                    {
                        int totalScore = 0;
                        foreach(char ch in lowerWord)
                        {
                            if(ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                            {
                                totalScore += 3;
                            }
                            else
                            {
                                totalScore += 1;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"Your word: {userWord} is worth {totalScore}");
                        Console.ResetColor();
                        Console.WriteLine("Please enter your word.  If you with to exit the app, type 'STOP'.");

                    }//ELSE IF #2

                }
                
            }


        } //MAIN
    } //PROGRAM
}// NAMESPACE
