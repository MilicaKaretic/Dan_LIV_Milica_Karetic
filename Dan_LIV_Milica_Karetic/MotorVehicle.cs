using System;

namespace Dan_LIV_Milica_Karetic
{
    /// <summary>
    /// abstract class motorVehicle
    /// </summary>
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

        /// <summary>
        /// create new vehicle
        /// </summary>
        public virtual void CreateNewVehicle()
        {

        }

        /// <summary>
        /// move vehicle
        /// </summary>
        public virtual void Move()
        {

        }
        /// <summary>
        /// stop vehicle
        /// </summary>
        public virtual void Stop()
        {

        }
    }
}
