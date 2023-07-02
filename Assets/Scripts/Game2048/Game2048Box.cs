using System;

namespace Game2048
{
    internal class Game2048Box
    {
        public int[,] nums;
        public int[,] nums_old;

        /// <summary>
        /// 四个方向的操作
        /// </summary>
        public enum Op
        {
            Up, Down, Left, Right
        }

        /// <summary>
        /// 游戏规模
        /// </summary>
        public const int rage = 3;
        /// <summary>
        /// 游戏目标分数
        /// </summary>
        public const int target = 500;
        /// <summary>
        /// 游戏分数，超过target则通关。
        /// </summary>
        public int score;

        public Game2048Box()
        {
            nums = new int[rage, rage];
            nums_old = new int[rage, rage];
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            for (int i = 0; i < rage; i++)
            {
                for (int j = 0; j < rage; j++)
                {
                    nums[i, j] = 0;
                    nums_old[i, j] = 0;
                }
            }
            Gen();
            score = 0;
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="direct">操作的方向，参考<see cref="Op"/></param>
        public void Change(int direct)
        {
            Copy(ref nums_old, nums);
            int[] line = new int[rage];
            switch (direct)
            {
                case (int)Op.Up:
                    for (int i = 0; i < rage; i++)
                    {
                        for (int j = 0; j < rage; j++)
                        {
                            line[j] = nums[j, i];
                        }
                        ChangeLine(ref line);
                        for (int j = 0; j < rage; j++)
                        {
                            nums[j, i] = line[j];
                        }
                    }
                    break;
                case (int)Op.Down:
                    for (int i = 0; i < rage; i++)
                    {
                        for (int j = 0; j < rage; j++)
                        {
                            line[rage - j - 1] = nums[j, i];
                        }
                        ChangeLine(ref line);
                        for (int j = 0; j < rage; j++)
                        {
                            nums[j, i] = line[rage - j - 1];
                        }
                    }
                    break;
                case (int)Op.Left:
                    for (int i = 0; i < rage; i++)
                    {
                        for (int j = 0; j < rage; j++)
                        {
                            line[j] = nums[i, j];
                        }
                        ChangeLine(ref line);
                        for (int j = 0; j < rage; j++)
                        {
                            nums[i, j] = line[j];
                        }
                    }
                    break;
                case (int)Op.Right:
                    for (int i = 0; i < rage; i++)
                    {
                        for (int j = 0; j < rage; j++)
                        {
                            line[rage - j - 1] = nums[i, j];
                        }
                        ChangeLine(ref line);
                        for (int j = 0; j < rage; j++)
                        {
                            nums[i, j] = line[rage - j - 1];
                        }
                    }
                    break;
            }
            // 如果操作没有使数字发生变化，视为无效操作
            if (!Compare(nums_old, nums) && CheckVictory() == null)
            {
                // 在操作有效且游戏继续的情况下生成新的数字
                Gen();
            }
        }

        /// <summary>
        /// 判定游戏胜利或失败
        /// </summary>
        /// <returns>胜利返回true，失败返回false，游戏继续返回null</returns>
        public bool? CheckVictory()
        {
            // 如果到达目标分数直接判定胜利
            if (score >= target)
            {
                return true;
            }
            else
            {
                // 先判定是否有空位
                int checkFull = 1;
                for (int i = 0; i < rage; i++)
                {
                    for (int j = 0; j < rage; j++)
                    {
                        checkFull *= nums[i, j];
                    }
                }
                // 如果有空位则继续
                if (checkFull == 0)
                {
                    return null;
                }
                // 如果没有空位
                else
                {
                    // 判定是否有相邻数字相同，有则继续
                    for (int i = 0; i < rage; i++)
                    {
                        for (int j = 0; j < rage - 1; j++)
                        {
                            if (nums[i, j] == nums[i, j + 1])
                            {
                                return null;
                            }
                            if (nums[j, i] == nums[j + 1, i])
                            {
                                return null;
                            }
                        }
                    }
                }
                // 没有空位且没有相邻数字相同，判定失败
                return false;
            }
        }

        /// <summary>
        /// 在随机位置生成一个数
        /// </summary>
        public void Gen()
        {
            Random random = new();
            int x, y;
            while (true)
            {
                x = random.Next(rage);
                y = random.Next(rage);
                if (nums[x, y] == 0)
                {
                    break;
                }
            }
            nums[x, y] = 2;
        }

        private void ChangeLine(ref int[] line)
        {
            MoveLine(ref line);
            MergeLine(ref line);
            MoveLine(ref line);
        }

        private void MoveLine(ref int[] line)
        {
            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] != 0 && line[i - 1] == 0)
                {
                    line[i - 1] = line[i];
                    line[i] = 0;
                    i--;
                }
            }
        }

        private void MergeLine(ref int[] line)
        {
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == line[i + 1] && line[i] != 0)
                {
                    line[i] *= 2;
                    line[i + 1] = 0;
                    score += line[i];
                }
            }
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

        private bool Compare(int[,] nums1, int[,] nums2)
        {
            for (int i = 0; i < rage; i++)
            {
                for (int j = 0; j < rage; j++)
                {
                    if (nums1[i, j] != nums2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
