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

        public void Load()
        {
            Console.WriteLine("Fill up the truck");
        }

        public void Unload()
        {
            Console.WriteLine("Remove items from the truck");
        }
    }
}
