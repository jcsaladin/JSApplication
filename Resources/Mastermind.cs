using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Resources
{
    public class Mastermind
    {
        private readonly List<CodePeg> code;

        public Mastermind(List<CodePeg> code)
        {
            this.code = code;
        }

        public List<ResultPeg> GetHints(List<CodePeg> guess)
        {
            List<ResultPeg> result = new List<ResultPeg>();
            List<ResultPeg> aux = new List<ResultPeg>();

            for (int i = 0; i < guess.Count; i++)
            {
                if (guess[i] == code[i])
                {
                    aux.Add(ResultPeg.Black);
                }else
                {
                    if (code.Contains(guess[i])) aux.Add(ResultPeg.White);
                }
            }

            ResultPeg[] allpegs = aux.ToArray();
            var sortedPegs = allpegs.OrderBy(l => l.ToString());

            foreach(var s in sortedPegs)
            {
                result.Add(s);
            }
           
            return result;
        }
    }

    public enum CodePeg
    {
        Black,
        Blue,
        Green,
        Red,
        White,
        Yellow,
    }

    public enum ResultPeg
    {
        Black,
        White,
    }
}
