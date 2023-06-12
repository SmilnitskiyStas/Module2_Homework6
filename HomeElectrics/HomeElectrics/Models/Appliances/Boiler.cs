using HomeElectrics.Interface;

namespace HomeElectrics.Models.Appliances
{
    internal class Boiler : ElectricalAppliances
    {
        public Boiler(string nameAppliances, int voltage, bool isWorking)
            : base(nameAppliances, voltage, isWorking)
        {
        }
    }
}
