using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LIV_Milica_Karetic
{
    abstract class MotorVehicle
    {
        double MotorVolume { get; set; }
        public int Weight { get; set; }
        public string Category { get; set; }
        public string MotorType { get; set; }
        public string Color { get; set; }
        public int MotorNumber { get; set; }

        public virtual void Move()
        {
            Console.WriteLine("Turn on motor and start going.");
        }
        public virtual void Stop()
        {
            Console.WriteLine("Turn off motor.");
        }
    }
}
