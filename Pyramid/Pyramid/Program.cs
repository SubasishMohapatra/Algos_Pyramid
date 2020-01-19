using System;
using System.Linq;

namespace Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var nextInput = Console.ReadLine().Split(" ");
                var s = nextInput[0];// "abc";
                var h = int.Parse(nextInput[1]); //4;
                var pyramidDirection = int.Parse(nextInput[2]); //1;
                var inputStringLength = s.Length;
                var totalCharacters = h * h;
                var repeatString = totalCharacters / inputStringLength;
                var noOfExtraCharacters = totalCharacters % inputStringLength;
                var finalString = string.Concat(Enumerable.Repeat(s, repeatString)) + s.Substring(0, noOfExtraCharacters);
                //Console.WriteLine(finalString);
                var lastIndex = 0;
                var lastLineLength = (h * 2) - 1;
                var isReverse = true;
                if (pyramidDirection == 1)
                {
                    for (int lineNo = 1; lineNo <= h; lineNo++)
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
                    }
                }
                else
                {
                    lastIndex = 0;
                    for (int lineNo = h; lineNo >= 1; lineNo--)
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
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
