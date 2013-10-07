using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabFareMeter.Contracts
{
    public interface ICalculator<T>
    {
        double Calculate(T t);
    }
}
