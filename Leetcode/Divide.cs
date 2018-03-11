using System;
using System.Linq;

namespace Leetcode
{
    internal class Divide
    {
        internal static int Execute(int dividend, int divisor)
        {
            long result = 0;
            long longDividend = Math.Abs((long)dividend);
            long longDivisor = Math.Abs((long)divisor);
            bool negSign = (dividend < 0) ^ (divisor < 0);

            if (longDivisor == 1)
                return negSign ? 
                    (int)Math.Max(-longDividend, int.MinValue): 
                        (int)Math.Min(longDividend, int.MaxValue);

            if (longDividend == longDivisor)
                return negSign ? -1 : 1;

            if (longDividend < longDivisor)
                return 0;


            var currentPower = 0;
            var tryResult = longDivisor << currentPower;
            while (tryResult <= longDividend)
            {
                if (tryResult == longDividend)
                    return negSign ? -(1 << currentPower) : 1 << currentPower;

                ++currentPower;
                tryResult = longDivisor << currentPower;
            }

            result = 1 << --currentPower;
            longDividend -= longDivisor << currentPower;
            result += Execute((int)longDividend, (int)longDivisor);

            return negSign ? (int)Math.Max(-result, int.MinValue) : (int)Math.Min(result, int.MaxValue);
        }
    }
}