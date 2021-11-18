using Framework.Application.Mediator.Requests;
using Framework.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Application.Controllers
{
    /// <summary>
    /// Math
    /// </summary>
    public class MathController : BaseController
    {
        #region "  Constructors  "

        public MathController(IMediator mediator) : base(mediator)
        {

        }

        #endregion

        #region "  Endpoints  "

        /// <summary>
        /// Decompose a value and get dividers and prime numbers
        /// </summary>
        /// <param name="value">Value to decompose</param>
        /// <returns></returns>
        [HttpGet("decompose/{value:int}")]
        public async Task<IActionResult> Decompose([FromRoute, Required, Range(1, int.MaxValue)] int value)
        {
            try
            {
                var request = new DecomposeValueRequest(value);
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.Message, new
                {
                    value
                });
            }
        }

        #endregion
    }
}
