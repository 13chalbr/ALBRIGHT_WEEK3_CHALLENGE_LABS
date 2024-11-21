using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System;
using System.Security.Claims;

namespace ALBRIGHT_WEEK3_CHALLENGE_LABS
{
    /* MSSA CCAD16
     * WEEK 3 CHALLENGE LABS
     * CHRIS ALBRIGHT
     */

    internal class Program
    {
        // 3.1 Method (palindrome)
        static bool PalindromeChecker(string inputString)
        {
            int leftPointer = 0;
            int rightPointer = inputString.Length - 1;

            while (leftPointer < rightPointer)
            {
                if (char.ToLower(inputString[leftPointer]) != char.ToLower(inputString[rightPointer]))
                {
                    return false;
                }
                leftPointer++;
                rightPointer--;
            }
            return true;
        }
        // 3.3 Method
        static bool SumToTarget(double[] array, double target)
        {
            var checkedNumbers = new List<double>();
            foreach (var number in array)
            {
                double complement = target - number;
                if (checkedNumbers.Contains(complement))
                {
                    Console.WriteLine($"\nPair found! {complement} + {number} = {target}");
                    return true;
                }
                checkedNumbers.Add(number);
            }
            return false;
        }
        // 3.3 Method discussed in class using nested for loops:
        static int[] SumToTarget2(double[] array, double target)
        {
            Console.WriteLine("\nUtilizing discussed class Method of nested for loops:");

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == target)
                    {
                        return new int[] { i, j };
                        break;
                    }
                }
            }
            return null;
        }

        static void Main(string[] args)
        {
            // 3.1C
            // Given a string, write a method that checks if it is a palindrome (is read the same backward as forward).
            // Assume that string may consist only of lower-case letters.

            Console.WriteLine("3.1C: Welcome to Palindrome Checker!");
            char hold1;
            do
            {                
                Console.WriteLine("\nPlease enter a word for palindromic check:");
                string inputString = Console.ReadLine();
                if (PalindromeChecker(inputString) == true)
                {
                    Console.WriteLine($"\n{inputString} is a Palindrome!");
                }
                else
                {
                    Console.WriteLine($"\n{inputString} is not a Palindrome...");
                }
                Console.WriteLine("\nDo you want to go again? (Y/N): ");
                hold1 = Convert.ToChar(Console.ReadLine().ToLower());
            }
            while (hold1 == 'y');
            Console.WriteLine("\n====================================================================================");
            //=======================================================================================================
            // 3.2C
            // Given a string, write a method which returns sum of all digits in that string. Assume that string contains
            // only single digits.

            Console.WriteLine("3.2C: Welcome to String Summer!");
            char hold2;
            do
            {
                int sumTotal = 0;
                Console.WriteLine("\nPlease enter your string with some numbers thrown into it:");
                string inputString2 = Console.ReadLine();
                int stringLength = inputString2.Length;

                for (int i = 0; i < stringLength; i++)
                {
                    if ((inputString2[i] >= '0') && (inputString2[i] <= '9')) //ascii values 48-57
                    {
                        sumTotal += (inputString2[i] - '0'); // subtracting the ascii value for 0 (48)
                    }
                }

                Console.WriteLine($"\nThe sum of all numbers in the inputted string is: {sumTotal}");
                Console.WriteLine("\nDo you want to go again? (Y/N): ");
                hold2 = Convert.ToChar(Console.ReadLine().ToLower());
            }
            while (hold2 == 'y');
            Console.WriteLine("\n====================================================================================");
            //=======================================================================================================
            // 3.3C
            // Given an array of integers nums and an integer target, return indices of the two numbers such that they
            // add up to target. You may assume that each input would have exactly one solution, and you may not use the
            // same element twice.

            Console.WriteLine("\n3.3C: Welcome to Array Target Search");
            char hold3;
            do
            {
                Console.WriteLine("\nEnter the number of elements you'd like in your array:");
                int n = int.Parse(Console.ReadLine());
                double[] array = new double[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\nEnter array element: " + (i + 1));
                    array[i] = double.Parse(Console.ReadLine());
                }

                Console.WriteLine("\nYour entered array is as follows:");
                foreach (var item in array)
                {
                    Console.Write(item + ", ");
                }

                Console.Write("\nPlease enter the target sum value:");
                double targetInput = double.Parse(Console.ReadLine());

                SumToTarget(array, targetInput);

                if (SumToTarget(array, targetInput) == false)
                {
                    Console.WriteLine("No pair found...");
                }

                // Method discussed in Class with nested for loops:

                int[] result = SumToTarget2(array, targetInput);

                if (result != null)
                {
                    Console.WriteLine($"\nThe indicies of the above points are [{result[0]} , {result[1]}]");
                }
                else
                {
                    Console.WriteLine("No pair found...");
                }

                Console.WriteLine("\nDo you want to go again? (Y/N): ");
                hold3 = Convert.ToChar(Console.ReadLine().ToLower());
            }
            while (hold3 == 'y');

            Console.WriteLine("\n====================================================================================");
            //=======================================================================================================
            // 3.4C
            // You are given a string s consisting only of uppercase English letters.You can apply some operations to this
            // string where, in one operation, you can remove any occurrence of one of the substrings "AB" or "CD" from s.
            // Return the minimum possible length of the resulting string that you can obtain.
            // Note: the string concatenates after removing the substring and could produce new "AB" or "CD" substrings.

            Console.WriteLine("\n3.4C: Welcome to string \"AB\" and \"CD\" remover: ");
            char hold4;
            do
            {
                Console.WriteLine("\nEnter a string \"s\" consisting of all UPPERCASE letters:");
                string stringOriginal = Console.ReadLine();
                Console.WriteLine($"\nYour string is \"{stringOriginal}\" with an initial length of :{stringOriginal.Length}");
                string stringMod = stringOriginal;
                string stringLoopStart = stringOriginal;
                string stringRemoved1 = "AB";
                string stringRemoved2 = "CD";
                do
                {
                    stringLoopStart = stringMod;
                    stringMod = stringMod.Replace(stringRemoved1, "");
                    stringMod = stringMod.Replace(stringRemoved2, "");
                    Console.WriteLine($"Revison try: {stringMod}");
                }
                while (stringLoopStart != stringMod);
                Console.WriteLine($"\nFinal revison: \"{stringMod}\" with final length of : {stringMod.Length}");

                if (stringOriginal == stringMod)
                {
                    Console.WriteLine("\nCannot conduct any revison operations...");
                }
                Console.WriteLine("\nDo you want to go again? (Y/N): ");
                hold4 = Convert.ToChar(Console.ReadLine().ToLower());
            }
            while (hold4 == 'y');

            Console.WriteLine("\nSee ya later!\n ");
        }
    }
}
