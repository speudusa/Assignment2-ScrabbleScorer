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


        static void Main(string[] args)
        {
            //this is my switch for the while loop - until STOP is given, will keep taking user words
            bool done = false;  //part of While/Repeat system

            //UPDATE DICTIONARY

            Dictionary<char, int> newScoreKeeper = new Dictionary<char, int>();

            //loop through old dictionary
            foreach(KeyValuePair<int, string> oSK in oldScoreKeeper)
            {
                //split old value string into single letter strings
                string[] strChar = oSK.Value.Split(", ");
                foreach (string str in strChar)
                {
                    //convert to chars AND set as keys
                    char ch = Convert.ToChar(str);
                    newScoreKeeper.Add(ch, oSK.Key);
                }
            }


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
                //user word comes in right here
                string userWord = Console.ReadLine();

                //check our exit point
                if (userWord == "STOP")
                {
                    Console.WriteLine("Thank you for playing");
                    //if STOP, update while condition and end loop
                    done = true;
                }
                //everything else is possible if NOT STOP
                else
                {
                    //remove case issues
                    string lowerWord = userWord.ToLower();

            //1 - SCRABBLE SCORING
                //uses oldScoreKeeper via newScoreKeeper
                    if(inputPoints == "1")
                    {
                        //list to hold each int value associated with ch
                            //could also use array, but would need to set length based on length of word (extra code)
                        List<int> letterScore = new List<int>();
                        foreach (KeyValuePair<char, int> score in newScoreKeeper)
                        {
                            foreach (char ch in lowerWord)
                            {
                                if (score.Key == ch)
                                {
                                    //this ONLY puts each int into the list - no math
                                    letterScore.Add(score.Value);
                                }
                            }
                        }

                        //UPDATE score total by adding each int value within the list
                   
                        int totalScore = 0;

                        foreach(int i in letterScore)
                        {
                            totalScore += i;
                        }

                        
                        Console.ForegroundColor = ConsoleColor.DarkCyan;  //color change for my testing purposes
                        //print word and score - referring back to original word user provided
                        //this specific formatting is optional
                        Console.WriteLine($"Your word: {userWord} is worth {totalScore}");  
                        Console.ResetColor(); //for my testing

                        //ask question once again here based on while loop
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
