using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeElectrics.Models
{
    internal class FoundElectricalAppliances : ElectricalAppliances
    {
        public FoundElectricalAppliances()
        {
        }

        public FoundElectricalAppliances(string nameAppliances, int voltage, bool isWorking)
            : base(nameAppliances, voltage, isWorking)
        {
        }
    }
}
