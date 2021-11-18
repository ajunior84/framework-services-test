using FluentValidation;
using Framework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service.Interfaces
{
    /// <summary>
    /// Math Service Interface
    /// </summary>
    public interface IMathService
    {
        #region "  Methods  "

        /// <summary>
        /// Decompose a value and get dividers and prime numbers
        /// </summary>
        /// <param name="value">Value to decompose</param>
        /// <returns></returns>
        Task<DecomposeValueResult> DecomposeValueAsync(int value);
        
        /// <summary>
        /// Check if number is prime number
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns></returns>
        bool IsPrime(int value);

        #endregion
    }
}
