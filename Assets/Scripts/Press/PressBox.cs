using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Press
{
    internal class PressBox
    {
        public const int rage = 3;
        public bool[] light = new bool[rage];

        public int cnt;
        public const int tar = 10;

        public PressBox() { }

        public void Init()
        {
            InitArray(ref light);
            cnt = 0;
        }

        public void SwitchLight()
        {
            InitArray(ref light);
            Random random = new();
            light[random.Next(rage)] = true;
        }

        public string GetTip()
        {
            return $"target:{cnt}/{tar}";
        }

        public void InitArray(ref bool[] bools)
        {
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] = false;
            }
        }
    }
}
