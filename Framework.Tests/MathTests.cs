using Framework.Service.Interfaces;
using Framework.Service.Services;
using System;
using Xunit;

namespace Framework.Tests
{
    public class MathTests
    {
        [Fact]
        public void IsPrime_InputOne()
        {
            IMathService mathService = new MathService();
            bool result = mathService.IsPrime(1);

            Assert.False(result, "By definition 1 not be prime.");
        }
    }
}
