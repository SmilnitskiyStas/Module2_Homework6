using HomeElectrics.Enums;
using HomeElectrics.Models;
using HomeElectrics.Models.Appliances;

namespace HomeElectrics
{
    internal class Starter
    {
        public void Run()
        {
            ElectricalAppliances[] electricalAppliances;

            int[] arrayAppliances = DefinitionAppliances();

            electricalAppliances = CreateAppliances(arrayAppliances);

            electricalAppliances = SwitchOnAppliances(electricalAppliances);

            CalculationOfPowerConsumption(electricalAppliances);

            SortAndPrintAppliances(electricalAppliances);

            FoundByParameters(electricalAppliances);
        }

        /// <summary>
        /// Вибираємо прилади які є в нашому домі.
        /// </summary>
        /// <returns>Масив приладів.</returns>
        private int[] DefinitionAppliances()
        {
            Console.WriteLine("You need the definition of appliances for your home.");

            ShowFilesOfObject();

            Console.WriteLine("Choose the ones that you have electrical appliances.\nUse separation (',') for it.");

            string[] stringArrayAppliances = Console.ReadLine().Split(',');

            int[] arrayAppliances = new int[stringArrayAppliances.Length];

            for (int i = 0; i < stringArrayAppliances.Length; i++)
            {
                arrayAppliances[i] = int.Parse(stringArrayAppliances[i]) - 1;
            }

            return arrayAppliances;
        }

        /// <summary>
        /// Створення визначених приладів.
        /// </summary>
        /// <param name="arrayAppliances">Масив вибраних приладів для створення.</param>
        /// <returns>Масив приладів.</returns>
        private ElectricalAppliances[] CreateAppliances(int[] arrayAppliances)
        {
            Random random = new Random();

            ElectricalAppliances[] electricalAppliances = new ElectricalAppliances[arrayAppliances.Length];

            for (int i = 0; i < arrayAppliances.Length; i++)
            {
                switch (arrayAppliances[i])
                {
                    case 0:
                        ElectricalAppliances boiler = new Boiler(((EnumAppliances)0).ToString(), random.Next(800, 2000), false);
                        electricalAppliances[i] = boiler;
                        break;
                    case 1:
                        ElectricalAppliances kettle = new Kettle(((EnumAppliances)1).ToString(), random.Next(1500, 2500), false);
                        electricalAppliances[i] = kettle;
                        break;
                    case 2:
                        ElectricalAppliances laptop = new Laptop(((EnumAppliances)2).ToString(), random.Next(500, 1200), false);
                        electricalAppliances[i] = laptop;
                        break;
                    case 3:
                        ElectricalAppliances light = new Light(((EnumAppliances)3).ToString(), random.Next(20, 100), false);
                        electricalAppliances[i] = light;
                        break;
                    case 4:
                        ElectricalAppliances multiwavelength = new Multiwavelength(((EnumAppliances)4).ToString(), random.Next(700, 1600), false);
                        electricalAppliances[i] = multiwavelength;
                        break;
                    case 5:
                        ElectricalAppliances refrigerator = new Refrigerator(((EnumAppliances)5).ToString(), random.Next(700, 3000), false);
                        electricalAppliances[i] = refrigerator;
                        break;
                    case 6:
                        ElectricalAppliances smoothingIron = new SmoothingIron(((EnumAppliances)6).ToString(), random.Next(1000, 2000), false);
                        electricalAppliances[i] = smoothingIron;
                        break;
                    case 7:
                        ElectricalAppliances tv = new TV(((EnumAppliances)7).ToString(), random.Next(300, 800), false);
                        electricalAppliances[i] = tv;
                        break;
                }
            }

            return electricalAppliances;
        }

        /// <summary>
        /// Включення приладів в розетку.
        /// </summary>
        /// <param name="electricalAppliances">Масив приладів.</param>
        /// <returns>Масив після включення приладів.</returns>
        private ElectricalAppliances[] SwitchOnAppliances(ElectricalAppliances[] electricalAppliances)
        {
            Random random = new Random();

            for (int i = 0; i < electricalAppliances.Length; i++)
            {
                ElectricalAppliances electricalAppliance = electricalAppliances[i];

                int switchOn = random.Next(0, 2);

                if (switchOn == 1)
                {
                    electricalAppliance.IsWorking = true;
                }

                if (electricalAppliance is Boiler)
                {
                    electricalAppliance.IsWorking = true;
                }

                if (electricalAppliance is Refrigerator)
                {
                    electricalAppliance.IsWorking = true;
                }

                electricalAppliances[i] = electricalAppliance;
            }

            return electricalAppliances;
        }

        /// <summary>
        /// Відображення вольтажу по включеним приладам.
        /// </summary>
        /// <param name="electricalAppliances">Масив приладів.</param>
        private void CalculationOfPowerConsumption(ElectricalAppliances[] electricalAppliances)
        {
            Console.WriteLine("\nDevices that are currently working!\n");

            int power = 0;

            for (int i = 0; i < electricalAppliances.Length; i++)
            {
                if (electricalAppliances[i].IsWorking)
                {
                    power += electricalAppliances[i].Voltage;

                    Console.WriteLine($"Name device: {electricalAppliances[i].NameAppliance}, voltage: {electricalAppliances[i].Voltage}");
                }
            }

            Console.WriteLine($"\nCalculation of power consumption: {power}\n");
        }

        /// <summary>
        /// Сортування приладів по одному із параметрів.
        /// </summary>
        /// <param name="electricalAppliances">Масив приладів.</param>
        private void SortAndPrintAppliances(ElectricalAppliances[] electricalAppliances)
        {
            Console.WriteLine("\nSort all your devices\n");
            Array.Sort(electricalAppliances);

            for (int i = 0; i < electricalAppliances.Length; i++)
            {
                Console.WriteLine($"Name: {electricalAppliances[i].NameAppliance}, Voltage: {electricalAppliances[i].Voltage}, Working: {electricalAppliances[i].IsWorking}");
            }
        }

        /// <summary>
        /// Пошук приладів за характеристиками.
        /// </summary>
        /// <param name="electricalAppliances">Масив приладів.</param>
        private void FoundByParameters(ElectricalAppliances[] electricalAppliances)
        {
            Console.WriteLine("\nTo search by parameters, you need to specify some data\n1. Name of appliance\n2. Maximum and minimum voltage value");

            Console.WriteLine("\nSelect one device for searching:\n");

            for (int i = 0; i < electricalAppliances.Length; i++)
            {
                Console.WriteLine($"Number - {i + 1}, Name - {electricalAppliances[i].NameAppliance}");
            }

            int searchDevice = int.Parse(Console.ReadLine());

            Console.WriteLine("Set max and min value for voltage (min, max)");
            string[] stringValueVoltage = Console.ReadLine().Split(',');

            FoundElectricalAppliances foundElectricalAppliances = new FoundElectricalAppliances();
            foundElectricalAppliances.FoundElectricalAppliances(electricalAppliances, electricalAppliances[searchDevice].NameAppliance, int.Parse(stringValueVoltage[0]), int.Parse(stringValueVoltage[1]));
        }

        /// <summary>
        /// Відображення файлів Приладів без розширення.
        /// </summary>
        private void ShowFilesOfObject()
        {
            string[] appliances = Directory.GetFiles(@"C:\Users\Stas2\source\repos\GitProject\Module2_Homework6\HomeElectrics\HomeElectrics\Models\Appliances");

            for (int i = 0; i < appliances.Length; i++)
            {
                string[] arrayFile = appliances[i].Split("\\");

                string[] fileName = arrayFile[arrayFile.Length - 1].Split(".cs");

                Console.WriteLine($"Number - {i + 1}, Name - {fileName[0]}");
            }
        }
    }
}
