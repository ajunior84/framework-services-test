using Framework.Application.Mediator.Requests;
using Framework.Domain.Models;
using Framework.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Application.Mediator.Handlers
{
    /// <summary>
    /// Decompose Value Handler
    /// </summary>
    public class DecomposeValueHandler : IRequestHandler<DecomposeValueRequest, DecomposeValueResult>
    {
        #region "  Variables  "

        private readonly IMathService _mathService;

        #endregion

        #region "  Constructors  "

        public DecomposeValueHandler(IMathService mathService)
        {
            _mathService = mathService;
        }

        #endregion

        #region "  IRequestHandler  "

        public Task<DecomposeValueResult> Handle(DecomposeValueRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _mathService.DecomposeValueAsync(request.Value);
        }

        #endregion
    }
}
