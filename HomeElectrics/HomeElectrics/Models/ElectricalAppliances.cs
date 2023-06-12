using HomeElectrics.Interface;

namespace HomeElectrics.Models
{
    internal abstract class ElectricalAppliances : IComparable, IWorked, INameble
    {
        public string NameAppliance { get; set; }

        public int Voltage { get; set; }

        public bool IsWorking { get; set; }

        public ElectricalAppliances()
        {
        }

        public ElectricalAppliances(string nameAppliances, int voltage, bool isWorking)
        {
            if (string.IsNullOrEmpty(nameAppliances))
            {
                throw new ArgumentNullException($"Parameters: {nameAppliances} is null.");
            }

            NameAppliance = nameAppliances;

            if (voltage == 0.0)
            {
                throw new ArgumentNullException($"Parameters: {nameAppliances} is null.");
            }

            Voltage = voltage;
            IsWorking = isWorking;
        }

        public int CompareTo(object? obj)
        {
            if (obj is ElectricalAppliances electricalAppliances)
            {
                return NameAppliance.CompareTo(electricalAppliances.NameAppliance);
            }
            else
            {
                throw new ArgumentException("Error!");
            }
        }
    }
}
