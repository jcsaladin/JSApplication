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
            Dictionary<int, CodePeg> aux_guess = new Dictionary<int, CodePeg>();
            Dictionary<int, CodePeg> aux_code = new Dictionary<int, CodePeg>();
            int count = guess.Count;

            //Fill our Dictionary of guess
            for (int i = 0; i < guess.Count; i++) aux_guess.Add(i, guess[i]);

            //Fill our Dictionary of code
            for (int i = 0; i < code.Count; i++) aux_code.Add(i, code[i]);

            //Black Hints 
            for (int i = 0; i < count; i++)
            {
                if (aux_guess[i] == aux_code[i])
                {
                    result.Add(ResultPeg.Black);
                    aux_guess.Remove(i);
                    aux_code.Remove(i);
                }
            }

            //White Hints 
            foreach (var aux in aux_guess)
            {
                    if (aux_code.ContainsValue(aux.Value))
                    {
                        result.Add(ResultPeg.White);
                    }
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
