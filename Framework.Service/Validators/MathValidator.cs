using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Service.Validators
{
    /// <summary>
    /// Math Validator
    /// </summary>
    public class MathValidator : AbstractValidator<int>
    {
        #region "  Constructors  "

        public MathValidator()
        {
            // Value validation
            RuleFor(p => p)
                .GreaterThanOrEqualTo(1)
                    .WithMessage("The number must be greater then or equal to 1.")
                .NotEmpty()
                .NotNull();
        }

        #endregion
    }
}
