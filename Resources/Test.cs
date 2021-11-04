using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Resources
{
    public class Test
    {
        public static void PlayMastermind()
        {
            List<CodePeg> code;
            List<CodePeg> myguess;

            //Get the pegs for our codemaker
            Presentation(1);
            code = ReadPegs();

            //Pass the values to our Mastermind class for test the code
            Mastermind mastermind = new Mastermind(code);

            //Get the guess made by the codebreaker
            Presentation(2);
            string board = "\n", plays = "Hinst:\n";
            int win = 0;
            for (int i = 1; i <= 10; i++)
            {
                myguess = ReadPegs();
                List<ResultPeg> hints = mastermind.GetHints(myguess);

                board += i + ". ";
                foreach (var m in myguess)
                {
                    board += m + " | ";
                }
                board += "\n";
                foreach (var h in hints)
                {
                    plays += h + " | ";
                }
                plays += "\n";
                Console.WriteLine(board);
                Console.WriteLine(plays);

                foreach (var h in hints)
                {
                    if (h == ResultPeg.Black) win += 1;
                }

                if (win == 4)
                { 
                    Console.WriteLine("Excellent Job!!!, you just broke the code");
                    break;
                }
                else if(win < 4) { 
                  if (i == 10) Console.WriteLine("Thanks for playing, you couldn't break the code"); 
                }
                win = 0;
            }

            Console.ReadLine();
        }

        static void Presentation(int code)
        {
            if (code == 1)
            {
                Console.WriteLine("Hi codemaker, insert the code to break!!!");
                Console.WriteLine("Choose a pattern of four code pegs.\n 1.Black.\n 2.Blue.\n 3.Green.\n 4.Red.\n 5.White.\n 6.Yellow.\n");
            }
            else if (code == 2)
            {
                Console.WriteLine("\nHi codebreaker, it is time to break the code!!!");
                Console.WriteLine("\n 1.Black.\n 2.Blue.\n 3.Green.\n 4.Red.\n 5.White.\n 6.Yellow.");
            }
            else
            {
                throw new InvalidOperationException("Insert a number between 1 and 2");
            }

        }

        static List<CodePeg> ReadPegs()
        {
            int i = 1;
            List<CodePeg> result = new List<CodePeg>();
            while (i <= 4)
            {
                try
                {
                    int entry;
                    Console.Write("Write the number of the peg:");
                    entry = int.Parse(Console.ReadLine());

                    if (entry >= 1 && entry <= 6)
                    {
                        result.Add(GetPegByNumber(entry));
                        i++;
                    }
                    else Console.WriteLine("Enter a number between 1 and 6");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }

            return result;
        }

        static CodePeg GetPegByNumber(int index)
        {
            return index switch
            {
                1 => CodePeg.Black,
                2 => CodePeg.Blue,
                3 => CodePeg.Green,
                4 => CodePeg.Red,
                5 => CodePeg.White,
                6 => CodePeg.Yellow,
                _ => 0
            };
        }
    }
}