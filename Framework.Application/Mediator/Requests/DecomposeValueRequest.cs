using Framework.Domain.Models;
using Framework.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Application.Mediator.Requests
{
    public class DecomposeValueRequest : IRequest<DecomposeValueResult>
    {
        public int Value { private set; get; }

        public DecomposeValueRequest(int value)
        {
            Value = value;
        }
    }
}
