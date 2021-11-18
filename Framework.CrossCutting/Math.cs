using Framework.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.CrossCutting
{
    /// <summary>
    /// Mathematics
    /// </summary>
    public sealed class Math : IMath
    {
        #region " IMath "

        /// <summary>
        /// Decompose a value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Item1: Dividers, Item2: Prime Numbers</returns>
        public Tuple<IEnumerable<int>, IEnumerable<int>> DecomposeValue(int value)
        {
            var dividers = new List<int>();
            var primeNumbers = new List<int>();

            for (int i = value; i >= 1; i--)
            {
                if (value % i == 0)
                {
                    dividers.Add(i);

                    if (IsPrimeNumber(i))
                    {
                        primeNumbers.Add(i);
                    }
                }
            }

            return new Tuple<IEnumerable<int>, IEnumerable<int>>(dividers.OrderBy(p => p), primeNumbers.OrderBy(p => p));
        }

        /// <summary>
        /// Check if value is prime number
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public bool IsPrimeNumber(int value)
        {
            if (value <= 1)
            {
                return false;
            }

            if (value == 2)
            {
                return true;
            }

            if (value % 2 == 0)
            {
                return false;
            }

            var boundary = (int)System.Math.Floor(System.Math.Sqrt(value));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region " IDisposable "

        public void Dispose()
        {
            // Release resources
        }

        #endregion
    }
}
