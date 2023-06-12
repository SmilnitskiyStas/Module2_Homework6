using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeElectrics.Interface
{
    internal interface INameble
    {
        string NameAppliance { get; }

        int Voltage { get; }
    }
}
