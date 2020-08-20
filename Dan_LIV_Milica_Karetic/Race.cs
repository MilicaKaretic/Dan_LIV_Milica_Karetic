using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dan_LIV_Milica_Karetic
{
    class Race
    {


        private bool endRace = false;
        private static readonly Random rng = new Random();

        private static string semaphoreColor = "";

        private readonly string[] colorOptions = { "Red", "Green"};

        private static int carCounter = 0;
        private static int winners = 0;


        CountdownEvent cnt = new CountdownEvent(3);
        SemaphoreSlim gasStation = new SemaphoreSlim(1);

        private EventWaitHandle winRace = new AutoResetEvent(true);

        public  void ChangeSemaphoreColor()
        {
            Console.WriteLine("Semaphore is  active.");
            for (int i = 0; i < 3; i++)
            {
                // Resets the for loop to do while all cars pass the semaphore
                if (i == 2)
                {
                    i = 0;
                }

                Console.WriteLine("{0} light.", colorOptions[i]);
                semaphoreColor = colorOptions[i];

                // Checks if all cars passed the semaphore before stopping to work
                Thread.Sleep(100);
                if (carCounter == 3)
                {
                    Console.WriteLine("\nAll cars passed the semaphore.\n");
                    carCounter = 0;
                    break;
                }


                Thread.Sleep(1900);
            }
        }

        public  void DecreaseTankVolume()
        {
            // Do this while the race is active
            while (endRace == false)
            {
                for (int i = 0; i < Program.allAutomobiles.Count; i++)
                {
                    Program.allAutomobiles[i].MaxTankVolume = Program.allAutomobiles[i].MaxTankVolume - rng.Next(1, 5);
                }
                Thread.Sleep(1000);
            }
        }

        public void Drive(int secs, Automobile auto)
        {
            for (int i = 0; i < secs; i++)
            {
                Thread.Sleep(1000);
                if (auto.MaxTankVolume <= 0)
                {
                    break;
                }
            }
        }
        readonly object l = new object();

        public void Racing(Automobile automobile)
        {
            cnt.Signal();
            cnt.Wait();

            automobile.Move();

            while(automobile.MaxTankVolume > 0)
            {
                //driving to semaphore
                Drive(10, automobile);

                Console.WriteLine("{0} {1} reached the semaphore, currently light is {2}", automobile.Color, automobile.Producer, semaphoreColor);

                //wait until currently light is green
                while (semaphoreColor == "Red")
                {
                    Thread.Sleep(0);
                }

                lock (l)
                {
                    carCounter++;
                }

                //drive to gas stayion
                Drive(3, automobile);

                //if tank values is less than 15 than go to gas station
                if (automobile.MaxTankVolume < 15)
                {
                    ChargingAtGasStation(automobile);
                }
                else
                {
                    Console.WriteLine("{0} {1} passed the gas station with tank valume: {2} l.", automobile.Color, automobile.Producer, automobile.MaxTankVolume);
                }

                Drive(7, automobile);
                break;
            }

            // Checks if the car is out of gas
            if (automobile.MaxTankVolume <= 0)
            {
                automobile.Stop();
                Console.WriteLine("{0} {1} is out of gas and left the race.", automobile.Color, automobile.Producer);
            }
            else if (automobile.MaxTankVolume > 0)
            {
                Console.WriteLine("{0} {1} car arrived to the end of race", automobile.Color, automobile.Producer);
                automobile.Stop();
            }

            winRace.WaitOne();
            EndRaceResult(automobile);
        }

        private bool fastestRed = false;

        public void EndRaceResult(Automobile automobile)
        {

            lock (l)
            {
                carCounter++;
            }

            if(automobile.MaxTankVolume > 0)
            {
                winners++;
            }

            if(winners > 0 && automobile.MaxTankVolume > 0)
            {
                Console.WriteLine("\n{0}. {1} {2}", winners, automobile.Color, automobile.Producer);
            }


            if(automobile.Color == "Red" && automobile.MaxTankVolume > 0 && !fastestRed)
            {
                fastestRed = true;
                PrintFirstRed(automobile);
            }
            else if (carCounter == 3 && Program.isRedCar == false)
            {
                Console.WriteLine("\n\nThere were no red cars in the race.\n");
            }
            else if (carCounter == 3 && Program.isRedCar == true && fastestRed == false)
            {
                Console.WriteLine("\n\nNo red cars get to the end of race.\n");
            }
            
            winRace.Set();
        }

        public void PrintFirstRed(Automobile automobile)
        {
            winRace.Set();
            Console.WriteLine("\n\nFastest red car is: {0} {1}.\n", automobile.Color, automobile.Producer);
        }

        public void ChargingAtGasStation(Automobile automobile)
        {
            gasStation.Wait();
            Console.WriteLine("{0} {1} is charging, current tank volume: {2}l", automobile.Color, automobile.Producer, automobile.MaxTankVolume);
            Thread.Sleep(50);
            automobile.MaxTankVolume = 51;
            Console.WriteLine("{0} {1} finished charging their tank", automobile.Color, automobile.Producer);
            gasStation.Release();
        }
    }
}
