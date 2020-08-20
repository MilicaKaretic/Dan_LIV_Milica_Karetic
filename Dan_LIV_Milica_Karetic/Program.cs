using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dan_LIV_Milica_Karetic
{
    class Program
    {
        public static List<Automobile> allAutomobiles = new List<Automobile>();
        public static List<Tractor> allTractor = new List<Tractor>();
        public static List<Truck> allTruck = new List<Truck>();

        public static bool isRedCar = false;

        static void Main(string[] args)
        {
            Automobile auto = new Automobile();
            Tractor tractor = new Tractor();
            Truck truck = new Truck();

            Race race = new Race();
            

            // Creating vehicles
            for (int i = 0; i < 2; i++)
            {
                auto.CreateNewVehicle();
                truck.CreateNewVehicle();
                tractor.CreateNewVehicle();
            }

            for (int i = 1; i < 6; i++)
            {               
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

            // Starting threads
            for (int i = 0; i < allAutomobiles.Count; i++)
            {
                int temp = i;
                Thread thread1 = new Thread(() => race.Racing(allAutomobiles[temp]));
                thread1.Start();
            }

            // Creating golf car
            Random rng = new Random();
            Automobile golf = new Automobile
            {
                Color = "Orange",
                MaxTankVolume = 51,
                Producer = "Golf"
            };
            allAutomobiles.Add(golf);

            for (int i = 0; i < allAutomobiles.Count; i++)
            {
                if(allAutomobiles[i].Color == "Red")
                {
                    isRedCar = true;
                    break;
                }
            }

            // Starting golf
            Console.WriteLine(golf.Color + " " + golf.Producer + " joined the race\n\n\n");
            Thread threadGolf = new Thread(() => race.Racing(golf));
            threadGolf.Start();

            // Thread that changes the semaphore color every 2 seconds
            Thread thread3 = new Thread(race.ChangeSemaphoreColor)
            {
                IsBackground = true
            };
            thread3.Start();

            // Thread that reduces the car Tank Volume every 1 second
            Thread thread4 = new Thread(race.DecreaseTankVolume)
            {
                IsBackground = true
            };
            thread4.Start();

            Console.ReadKey();
        }

        

        
    }
}
