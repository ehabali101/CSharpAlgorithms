using System;
using System.Collections.Generic;
using System.Text;

namespace csharpCoding
{
    class BinaryGap
    {
        public int solution(int n)
        {
            string bits = Convert.ToString(n, 2);
            int longest = 0;
            int curCount = 0;
            int onesCount = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0')
                {
                    if (curCount > 0)
                        curCount++;
                    else
                        curCount = 1;
                }
                else // 1
                {
                    onesCount++;

                    if (curCount > longest)
                    {
                        longest = curCount;
                    }

                    if (onesCount > 1)
                        curCount = 0;

                }


            }

            return longest;
        }
    }
}
