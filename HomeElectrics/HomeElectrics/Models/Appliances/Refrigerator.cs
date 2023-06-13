using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeElectrics.Models.Appliances
{
    internal class Refrigerator : ElectricalAppliances
    {
        public Refrigerator(string nameAppliances, int voltage, bool isWorking)
            : base(nameAppliances, voltage, isWorking)
        {
        }
    }
}
