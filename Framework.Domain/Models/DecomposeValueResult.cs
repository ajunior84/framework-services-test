using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain.Models
{
    /// <summary>
    /// Result of decompose value operation
    /// </summary>
    public class DecomposeValueResult
    {
        #region "  Properties  "

        public bool IsPrime { private set; get; }
        public int InputNumber { private set; get; }
        public IEnumerable<int> Dividers { private set; get; }
        public IEnumerable<int> PrimeNumbers { private set; get; }

        #endregion

        #region "  Constructros  "

        public DecomposeValueResult(bool isPrime, int inputNumber, IEnumerable<int> dividers, IEnumerable<int> primeNumbers)
        {
            IsPrime = isPrime;
            InputNumber = inputNumber;
            Dividers = dividers;
            PrimeNumbers = primeNumbers;
        }

        #endregion
    }
}
