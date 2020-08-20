using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_LIV_Milica_Karetic
{
    public abstract class MotorVehicle
    {
        public double MotorVolume { get; set; }
        public int Weight { get; set; }
        public string Category { get; set; }
        public string MotorType { get; set; }
        public string Color { get; set; }
        public int MotorNumber { get; set; }

        protected readonly string[] allColors = { "Red", "Blue", "Yellow","Orange", "Black" };
        protected readonly string[] allCategory = { "A", "B", "C", "D" };
        protected readonly string[] allMotorType = { "DC", "AC", "LM", "SRM" };

        public static Random rng = new Random();

        public MotorVehicle()
        {

        }

        public virtual void CreateNewVehicle()
        {

        }

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
