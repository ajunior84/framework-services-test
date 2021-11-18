using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Service.Services
{
    /// <summary>
    /// Base Service
    /// </summary>
    public abstract class BaseService
    {
        #region "  Protected Methods  "

        protected TValidator GetValidator<TValidator, TType>() where TValidator : AbstractValidator<TType>
        {
            var instance = Activator.CreateInstance<TValidator>();
            return instance;
        }

        #endregion
    }
}
