using System;

namespace Dan_LIV_Milica_Karetic
{
    public class Automobile : MotorVehicle
    {
        public string RegistrationNumber { get; set; }
        public int DoorNumber { get; set; }
        public int MaxTankVolume { get; set; }
        public string TransportType { get; set; }
        public string Producer { get; set; }
        public int TrafficNumber { get; set; }

        private readonly string[] allTransportType = { "type1", "type2", "type3" };
        private readonly string[] allProducer = { "Fiat", "Nissan" , "Golf"};

        public Automobile() : base()
        {

        }
        /// <summary>
        /// Recolor method that change color and traffic number of car
        /// </summary>
        /// <param name="color">New color</param>
        /// <param name="trafficNumber">new traffic number</param>
        public void Recolor(string color, int trafficNumber)
        {
            Color = color;
            TrafficNumber = trafficNumber;
        }
        /// <summary>
        /// Move car
        /// </summary>
        public override void Move()
        {
            Console.WriteLine(this.Color + " " + this.Producer + " started moving.");
        }
        /// <summary>
        /// stop car
        /// </summary>
        public override void Stop()
        {
            Console.WriteLine(this.Color + " " + this.Producer + " stopped moving.");
        }

        /// <summary>
        /// create new car
        /// </summary>
        public override void CreateNewVehicle()
        {
            Automobile auto = new Automobile
            {
                MotorVolume = Math.Round(rng.NextDouble() * 1000, 2),
                Weight = rng.Next(1000, 2001),
                Category = allCategory[rng.Next(0, allCategory.Length)],
                MotorType = allMotorType[rng.Next(0, allMotorType.Length)],
                DoorNumber = rng.Next(3, 6),
                MaxTankVolume = 51,
                Color = allColors[rng.Next(0, allColors.Length)],
                MotorNumber = rng.Next(50, 101),
                RegistrationNumber = rng.Next(1000, 10000).ToString(),              
                TransportType = allTransportType[rng.Next(0, allTransportType.Length)],
                Producer = allProducer[rng.Next(0, allProducer.Length)],
                TrafficNumber = rng.Next(100, 1000)
            };

            //add new car to list
            Program.allAutomobiles.Add(auto);
        }

    }
}
