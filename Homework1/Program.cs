using System;
using Logic;

namespace Homework1
{
    class Program
    {
        private static Random generator = new Random();
        private static double currentScore;
        public static double GenerateRandomScore()  //Pokušao sam ovu funkciju staviti u klasu(zakomentirana je tamo i dalje), ali mi je VS javljao grešku
        {
            currentScore = generator.NextDouble() * (10.0 - 0.0) + 0.0;
            return currentScore;
        }

        static void Main(string[] args)
        {
            Episode ep1, ep2;
            ep1 = new Episode();
            ep2 = new Episode(10, 64.39, 8.7);

            int viewers = 10;

            for (int i = 0; i < viewers; i++)
            {
                ep1.AddView(GenerateRandomScore());
                Console.WriteLine(Math.Round(ep1.GetMaxScore(), 5));
            }

            if(ep1.GetAverageScore() > ep2.GetAverageScore())
            {
                Console.WriteLine($"Viewers: {ep1.GetViewerCount()}");
            }
            else
            {
                Console.WriteLine($"Viewers: {ep2.GetViewerCount()}");
            }
        }
    }
}
