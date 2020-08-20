using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LIV_Milica_Karetic
{
    class Tractor : MotorVehicle
    {
        public double TireSize { get; set; }
        public string Drive { get; set; }
        public int WheelBase { get; set; }

        private readonly string[] allDrive = { "drive1", "drive2", "drive3" };

        public override void CreateNewVehicle()
        {
            Tractor tractor = new Tractor
            {
                MotorVolume = Math.Round(rng.NextDouble() * 1000, 2),
                Weight = rng.Next(1000, 2001),
                Category = allCategory[rng.Next(0, allCategory.Length)],
                MotorType = allMotorType[rng.Next(0, allMotorType.Length)],
                Color = allColors[rng.Next(0, allColors.Length)],
                MotorNumber = rng.Next(50, 101),
                TireSize = Math.Round(rng.NextDouble() * 100, 2),
                WheelBase = rng.Next(2, 11),
                Drive = allDrive[rng.Next(0, allDrive.Length)],
            };

            Program.allTractor.Add(tractor);
        }
    }
}
