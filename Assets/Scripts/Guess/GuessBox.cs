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
        public const int limit = 10;

        public GuessBox()
        {
        }

        public void Init()
        {
            Random random = new();
            num = random.Next(100, 1000);
        }

        public string Compare(int guessNum)
        {
            if (guessNum == num)
            {
                return "0";
            }
            else if (guessNum < 100 || guessNum > 999)
            {
                return "输入不合法";
            }
            else
            {
                int[] guess = ToArray(guessNum);
                int[] target = ToArray(num);
                return GetAB(guess, target);
            }
        }

        public int[] ToArray(int num)
        {
            int[] result = new int[3];
            int i = 0;
            while (num > 0)
            {
                result[i++] = num % 10;
                num /= 10;
            }
            return result;
        }

        public string GetAB(int[] a, int[] b)
        {
            return "A" + GetA(a, b) + "B" + GetB(a, b);
        }

        public int GetA(int[] a, int[] b)
        {
            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    result++;
                }
            }
            return result;
        }

        public int GetB(int[] a, int[] b)
        {
            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j] && i != j)
                    {
                        result++;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
