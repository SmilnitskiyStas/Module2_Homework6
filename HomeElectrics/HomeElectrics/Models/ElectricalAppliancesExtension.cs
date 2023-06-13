using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeElectrics.Models
{
    internal static class ElectricalAppliancesExtension
    {
        public static void FoundElectricalAppliances(this ElectricalAppliances electricalAppliance, ElectricalAppliances[] electricalAppliances, string nameAppliances = null, int minVoltage = 0, int maxVoltage = 0)
        {
            ElectricalAppliances[] electricalAppliancesByName, electricalAppliancesByVoltage;

            if (!string.IsNullOrEmpty(nameAppliances))
            {
                electricalAppliancesByName = FountByName(electricalAppliances, nameAppliances);
            }

            if (minVoltage != 0)
            {
                electricalAppliancesByVoltage = FoundByVoltage(electricalAppliances, minVoltage, maxVoltage);
            }
        }

        /// <summary>
        /// Пошук по імені.
        /// </summary>
        /// <param name="electricalAppliances">Масив приладів для пошуку.</param>
        /// <param name="name">Ім'я приладу для пошуку.</param>
        /// <returns>Масив приладів які співпали по імені.</returns>
        private static ElectricalAppliances[] FountByName(ElectricalAppliances[] electricalAppliances, string name)
        {
            ElectricalAppliances[] electricalAppliancesByName = new ElectricalAppliances[electricalAppliances.Length];

            int count = 0;

            Console.WriteLine($"\nFound device by name '{name}'\n");

            for (int i = 0; i < electricalAppliances.Length; i++)
            {
                if (electricalAppliances[i].NameAppliance == name)
                {
                    electricalAppliancesByName[count++] = electricalAppliances[i];

                    Console.WriteLine($"Name: {electricalAppliances[i].NameAppliance}, Voltage: {electricalAppliances[i].Voltage}");
                }
            }

            return electricalAppliancesByName;
        }

        /// <summary>
        /// Пошук по вольтажу.
        /// </summary>
        /// <param name="electricalAppliances">Масив приладів для пошуку.</param>
        /// <param name="minVoltage">Мінімальне значення для пошуку.</param>
        /// <param name="maxVoltage">Максимальне значення для пошуку.</param>
        /// <returns>Масив приладів які співпали по вольтажу.</returns>
        private static ElectricalAppliances[] FoundByVoltage(ElectricalAppliances[] electricalAppliances, int minVoltage, int maxVoltage)
        {
            ElectricalAppliances[] electricalAppliancesByVoltage = new ElectricalAppliances[electricalAppliances.Length];

            int count = 0;

            Console.WriteLine($"\nFound device by voltage: minValue - {minVoltage}, maxValue - {maxVoltage}");

            for (int i = 0; i < electricalAppliances.Length; i++)
            {
                if (electricalAppliances[i].Voltage >= maxVoltage && electricalAppliances[i].Voltage <= minVoltage)
                {
                    electricalAppliancesByVoltage[count++] = electricalAppliances[i];

                    Console.WriteLine($"Name: {electricalAppliances[i].NameAppliance}, voltage: {electricalAppliances[i].Voltage}");
                }
            }

            if (electricalAppliancesByVoltage[0] is null)
            {
                Console.WriteLine("We don`t found device");
            }

            return electricalAppliancesByVoltage;
        }
    }
}
