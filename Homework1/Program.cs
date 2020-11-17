using System;
using Logic;
using System.IO;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Episode ep1, ep2;
            //ep1 = new Episode();
            //ep2 = new Episode(10, 64.39, 8.7);

            //int viewers = 10;

            //for (int i = 0; i < viewers; i++)
            //{
            //    ep1.AddView(GenerateRandomScore());
            //    Console.WriteLine(Math.Round(ep1.GetMaxScore(), 5));
            //}

            //if(ep1.GetAverageScore() > ep2.GetAverageScore())
            //{
            //    Console.WriteLine($"Viewers: {ep1.GetViewerCount()}");
            //}
            //else
            //{
            //    Console.WriteLine($"Viewers: {ep2.GetViewerCount()}");
            //}

            EpisodeDesc description = new EpisodeDesc(1, TimeSpan.FromMinutes(45), "Pilot");
            Console.WriteLine(description);

            Episode episode = new Episode(10, 88.64, 9.78, description);
            Console.WriteLine(episode);

            string fileName = "shows.txt";
            string[] episodesInputs = File.ReadAllLines(fileName);
            Episode[] episodes = new Episode[episodesInputs.Length];

            for (int i = 0; i < episodes.Length; i++)
            {
                episodes[i] = TvUtilities.Parse(episodesInputs[i]);
            }

            Console.WriteLine("Episodes:");
            Console.WriteLine(string.Join<Episode>(Environment.NewLine, episodes));
            TvUtilities.Sort(episodes);
            Console.WriteLine("Sorted episodes:");
            string sortedEpisodesOutput = string.Join<Episode>(Environment.NewLine, episodes);
            Console.WriteLine(sortedEpisodesOutput);
            File.WriteAllText("sorted.tv", sortedEpisodesOutput);
        }
    }
}
