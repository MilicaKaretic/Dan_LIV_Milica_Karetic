using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LIV_Milica_Karetic
{
    class Truck :  MotorVehicle
    {
        public double Capacity { get; set; }
        public double Hight { get; set; }
        public int SeatNumber { get; set; }

        public Truck() : base()
        {
                
        }

        /// <summary>
        /// loading truck
        /// </summary>
        public void Load()
        {
            Console.WriteLine("Load the truck");
        }

        /// <summary>
        /// unloading truck
        /// </summary>
        public void Unload()
        {
            Console.WriteLine("Unload the truck");
        }

        /// <summary>
        /// create new truck
        /// </summary>
        public override void CreateNewVehicle()
        {
            Truck truck = new Truck
            {
                MotorVolume = Math.Round(rng.NextDouble() * 1000, 2),
                Weight = rng.Next(1000, 2001),
                Category = allCategory[rng.Next(0, allCategory.Length)],
                MotorType = allMotorType[rng.Next(0, allMotorType.Length)],
                Color = allColors[rng.Next(0, allColors.Length)],
                MotorNumber = rng.Next(50, 101),
                Capacity = Math.Round(rng.NextDouble() * 10000, 2),
                Hight = Math.Round(rng.NextDouble() * 100, 2),
                SeatNumber = rng.Next(2, 7),
            };
            //add truck to truck list
            Program.allTruck.Add(truck);
        }
    }
}
