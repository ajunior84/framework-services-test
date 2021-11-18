using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.CrossCutting.Interfaces
{
    public interface IMath : IDisposable
    {
        Tuple<IEnumerable<int>, IEnumerable<int>> DecomposeValue(int value);
        bool IsPrimeNumber(int value);
    }
}
