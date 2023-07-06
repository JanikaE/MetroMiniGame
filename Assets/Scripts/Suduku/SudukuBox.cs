using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Suduku
{
    internal class SudukuBox
    {
        public const int rage = 4;
        public int[,] originMap = { {2, 1, 3, 4},
                                    {4, 3, 1, 2},
                                    {1, 4, 2, 3},
                                    {3, 2, 4, 1} };
        public bool[,] isBlank = { {false, false, false, false},
                                    {false, false, false, false},
                                    {false, false, false, false},
                                    {false, false, false, false} };
        public int[,] playMap = new int[4, 4];

        public int ChooseX { get; set; }
        public int ChooseY { get; set; }

        public SudukuBox()
        {

        }

        public void Init()
        {
            Copy(ref playMap, originMap);
            System.Random random = new();
            for (int i = 0; i < 4; i++)
            {
                int x, y;
                while (true)
                {
                    x = random.Next(rage);
                    y = random.Next(rage);
                    if (playMap[x, y] != 0)
                    {
                        break;
                    }
                }
                playMap[x, y] = 0;
                isBlank[x, y] = true;
            }
            ChooseX = 0;
            ChooseY = 0;
        }

        public bool Check(int index)
        {
            int x = index % rage;
            int y = index / rage;
            return Check(x, y);
        }

        public bool Check(int x, int y)
        {
            // 检查在行列中是否有重复
            for (int i = 0; i < rage; i++)
            {
                if (playMap[x, y] == playMap[x, i] && y != i)
                {
                    return false;
                }
                if (playMap[x, y] == playMap[i, y] && x != i)
                {
                    return false;
                }
            }
            // 检查在宫格中是否有重复
            int[] Box = GetSmallBox(x, y, out int index);
            for (int i = 0; i < rage; i++)
            {
                if (playMap[x, y] == Box[i] && index != i)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckVictory()
        {
            for (int i = 0; i < rage; i++)
            {
                for (int j = 0; j < rage; j++)
                {
                    if (playMap[i, j] == 0)
                    {
                        return false;
                    }
                    if (!Check(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int GetValue(int index)
        {
            int x = index % rage;
            int y = index / rage;
            return playMap[x, y];
        }

        public bool IsBlank(int index)
        {
            int x = index % rage;
            int y = index / rage;
            return isBlank[x, y];
        }

        public void SetChoose(int index)
        {
            int x = index % rage;
            int y = index / rage;
            if (isBlank[x, y])
            {
                ChooseX = x;
                ChooseY = y;
            }
        }

        /// <summary>
        /// 获取小格其所在的宫格
        /// </summary>
        /// <param name="index">此小格在宫格内的下标</param>
        private int[] GetSmallBox(int x, int y, out int index)
        {
            int[] returns = new int[rage];
            int k = 0;
            int startX = x / 2 * 2 ;
            int startY = y / 2 * 2;
            for (int i = startY; i < startY + 2; i++)
            {
                for (int j = startX; j < startX + 2; j++)
                {
                    returns[k++] = playMap[j, i];
                }
            }
            index = (y - startY) * 2 + x - startX;
            return returns;
        }

        private void Copy(ref int[,] nums1, int[,] nums2)
        {
            for (int i = 0; i < rage; i++)
            {
                for (int j = 0; j < rage; j++)
                {
                    nums1[i, j] = nums2[i, j];
                }
            }
        }
    }
}
