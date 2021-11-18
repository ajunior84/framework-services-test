using FluentValidation;
using Framework.Domain.Models;
using Framework.Service.Interfaces;
using Framework.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Service.Services
{
    /// <summary>
    ///  Math Service
    /// </summary>
    public class MathService : BaseService, IMathService
    {
        #region "  Constructors  "

        public MathService()
        {

        }

        #endregion

        #region "  IMathService  "

        public async Task<DecomposeValueResult> DecomposeValueAsync(int value)
        {
            var validator = GetValidator<MathValidator, int>();
            
            // Validate
            await validator.ValidateAndThrowAsync(value);

            using(CrossCutting.Math math = new CrossCutting.Math())
            {
                var result = math.DecomposeValue(value);
                return new DecomposeValueResult(math.IsPrimeNumber(value), value, result.Item1, result.Item2);
            }
        }

        public bool IsPrime(int value)
        {
            using (CrossCutting.Math math = new CrossCutting.Math())
            {
                return math.IsPrimeNumber(value);
            }
        }

        #endregion
    }
}
