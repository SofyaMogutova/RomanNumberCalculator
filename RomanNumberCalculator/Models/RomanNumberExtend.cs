using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumberCalculator
{
    internal class RomanNumberExtend : RomanNumber
    {
        ushort sum;
        ushort last;
        public RomanNumberExtend(string str) : base(1)
        {
            ushort[] digit = new ushort[] { 1, 5, 10, 50, 100, 500, 1000 };
            char[] roman_num = new char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            for (int j = 0; j < 7; ++j)
                if (str[str.Length - 1] == roman_num[j])
                    sum = digit[j];
            last = sum;
            for (int i = str.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < 7; ++j)
                {
                    if (str[i] == roman_num[j] && last <= digit[j])
                    {
                        sum += digit[j];
                        last = digit[j];
                    }
                    else if (str[i] == roman_num[j] && last > digit[j])
                    {
                        sum -= digit[j];
                        last = digit[j];
                    }
                }
            }
            number = sum;
        }
    }
}
