using System;
using System.Linq;

namespace Pyramid
{
    class Program
    {
        /* 
        Input
        1st line: no of test cases
        2nd line: "input string  to print" "height of pyramid" "inversePyramid" e.g., abc 4 1 or abcdefg 4 -1
        Output: Print string in reverse order every line

            abc 4 1

               a
              acb
             bcabc
            acbacba

           =============

           abc 4 -1

           abcabca
            cbacb
             abc
              a

        */
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter no of test cases");
            var noOfTestCases = int.Parse(Console.ReadLine());
            while (noOfTestCases-- > 0)
            {
                Console.WriteLine("\"Enter string to display\" \"height of pyramid\" \"inverse pyramid or not\"");
                var nextInput = Console.ReadLine().Split(" ");
                var inputString = nextInput[0];// "abc";
                var heightOfPyramid = int.Parse(nextInput[1]); //4;
                var pyramidDirection = int.Parse(nextInput[2]); //1;               
                PrintDisplay(heightOfPyramid, inputString, pyramidDirection!=1);
            }
            Console.ReadKey();
        }

        private static void PrintDisplay(int heightOfPyramid, string inputString, bool reversePyramid)
        {
            var inputStringLength = inputString.Length;
            var totalCharacters = heightOfPyramid * heightOfPyramid;
            var repeatString = totalCharacters / inputStringLength;
            var noOfExtraCharacters = totalCharacters % inputStringLength;
            var finalString = string.Concat(Enumerable.Repeat(inputString, repeatString)) + inputString.Substring(0, noOfExtraCharacters);
            var lastLineLength = (heightOfPyramid * 2) - 1;
            var lastIndex = 0;
            var isReverse = true;
            int lineNo = 1;
            int increment = 1;
            int ctr = 1;
            if (reversePyramid)
            {
                lineNo = heightOfPyramid;
                increment = -1;
            }
            while (ctr <= heightOfPyramid)
            {
                var noOfCharsToPrint = lineNo + (lineNo - 1);
                var printString = finalString.Substring(lastIndex, noOfCharsToPrint);
                var charArray = printString.ToCharArray();
                Array.Reverse(charArray);
                isReverse = !isReverse;
                printString = $"{(isReverse ? new string(charArray) : printString)}";
                var padLength = (lastLineLength - printString.Length) / 2;
                var printLine = printString.PadLeft(lastLineLength - padLength).PadRight(lastLineLength);
                lastIndex += noOfCharsToPrint;
                Console.WriteLine(printLine);
                lineNo += increment;
                ctr++;
            }

        }
    }
}
