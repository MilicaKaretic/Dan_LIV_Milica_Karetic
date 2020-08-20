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
                    Console.WriteLine("All cars passed the semaphore.");
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
                    Program.allAutomobiles[i].TankVolume = Program.allAutomobiles[i].TankVolume - rng.Next(1, 5);
                }
                Thread.Sleep(1000);
            }
        }

        public void Racing(Automobile automobile)
        {
           

            automobile.Move();
        }
    }
}
