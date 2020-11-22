using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace vezbe_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Press X to exit the program.. or any other key to continue");

            while (Console.ReadKey().Key != ConsoleKey.X) //Check for the key if it's anything different than X
            {
                Console.WriteLine("Enter a binary string(only zeros and ones)");
                String str = Console.ReadLine(); //Read our input

                if (IsValidPattern(str)) //check if it's valid regex pattern
                {
                    Console.WriteLine($"The binary number in decimal is {ConvertBinaryToDecimal(str)}"); //call our function to convert it to decimal number
                }
                else
                {
                    Console.WriteLine("You didn't enter a valid binary number, please try again"); //error message that the string contained something else as well
                }
            }
            //If the key is X exit the program

            Console.WriteLine("\nYou have exited the program!");
            Console.ReadLine();
        }

        private static int ConvertBinaryToDecimal(string str)
        {
            //int sum = 0; //initial sum is 0
            //char[] array = str.ToCharArray(); //convert to string to a char array
            //Array.Reverse(array); //reverse that array so we start from the end

            //for (int i = 0; i < array.Length; i++) //go through every character (0 or 1)
            //{
            //    if (array[i].Equals('1'))
            //    {
            //        sum += (int)Math.Pow(2, i); //if it's 1 than raise 2 to the current index and add it to sum
            //    }
            //}

            //return sum; //return the sum(converted number)

            //LINQ EXPRESSION

            return str.ToCharArray().Reverse().Select((character, index) =>
            {
                return character.Equals('1') ? (int)Math.Pow(2, index) : 0;
            }).Sum();

            //return str.Select((c, i) => (int)Math.Pow(2 * (c - 48), str.Length - i - 1)).Sum();
        }

        private static bool IsValidPattern(string strToValidate)
        {
            Regex rgx = new Regex("^[01]+$"); //^ is the start of the string and & is the end. Accept only
            return rgx.IsMatch(strToValidate);
        }
    }
}