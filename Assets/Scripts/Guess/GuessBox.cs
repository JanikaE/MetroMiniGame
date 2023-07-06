using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess
{
    internal class GuessBox
    {
        public int num;
        public int cnt;
        public const int limit = 8;
        public int rangeTop;
        public int rangeBottom;

        public GuessBox() 
        {
        }

        public void Init()
        {
            Random random = new();
            num = random.Next(0, 500);
        }
         
        public int Compare(int guessNum)
        {
            if (guessNum == num)
            {
                return 0;
            }
            else if (guessNum > num)
            {
                if (guessNum > rangeBottom && guessNum < rangeTop)
                {
                    rangeBottom  = guessNum + 1;
                }
                return 1;
            }
            else
            {
                if (guessNum > rangeBottom && guessNum < rangeTop)
                {
                    rangeTop = guessNum - 1;
                }
                return -1;
            }
        }

        public string GetRange()
        {
            return rangeBottom.ToString() + "--->" +rangeTop.ToString();
        }
    }
}
