using System;
using System.Collections.Generic;

namespace Palindrome
{
    class Palindrome
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> cleanedArgs = new Dictionary<string, string>();
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if(arg.Contains("-"))
                {
                    string optionValue = args[i + 1];
                    if (!string.IsNullOrEmpty(optionValue) && !optionValue.Contains("-"))
                    {
                        cleanedArgs[arg.Replace("-","").ToLower()] = optionValue;
                    }
                }
            }

            // Check for the required command line arguments
            if (!cleanedArgs.ContainsKey("i"))
            {
                Console.WriteLine($@"Format for the input: -i ""racecar""");
                return;
            }

            // Get the value for the -i CLI option
            string palindrome = cleanedArgs["i"];

            if (string.IsNullOrEmpty(palindrome))
            {
                Console.WriteLine($@"Pass in a word to test for a palindrome");
                return;
            }

            DateTime a1 = DateTime.Now;
            bool isDrome = TestForPalindromeWithLoop(palindrome);
            DateTime a2 = DateTime.Now;

            double time1 = (a2 - a1).TotalSeconds;

            DateTime b1 = DateTime.Now;
            bool isDrome2 = TestForPalindromeWithLists(palindrome);
            DateTime b2 = DateTime.Now;

            double time2 = (b2 - b1).TotalSeconds;


            Console.WriteLine($@"Test for {palindrome} with Array and idx implementation: returned: {isDrome}");
            Console.WriteLine($@"Execution time was {time1} seconds");

            Console.WriteLine($@"Test for {palindrome} with List and reversed List implementation: returned: {isDrome2}");
            Console.WriteLine($@"Execution time was {time2} seconds");
        }


        static bool TestForPalindromeWithLoop(string palindrome)
        {
            char[] charsInPalindrome = palindrome.ToCharArray();
            int forwardIdx = 0;
            int backwardIdx = charsInPalindrome.Length - 1;

            while (forwardIdx <= backwardIdx)
            {
                if (charsInPalindrome[forwardIdx] != charsInPalindrome[backwardIdx])
                {
                    return false;
                }
                forwardIdx++;
                backwardIdx--;
            }
            return true;
        }

        static bool TestForPalindromeWithLists(string palindrome)
        {
            char[] charsInPalindrome = palindrome.ToCharArray();
            List<char> forward = new List<char>(charsInPalindrome);
            List<char> reverse = new List<char>(charsInPalindrome);
            reverse.Reverse();

            int middleOrALittleOver = forward.Count / 2;
            for (int i = 0; i <= middleOrALittleOver; i++)
            { 
                if(forward[i] != reverse[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
