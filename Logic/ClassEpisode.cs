using System;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Episode
    {
        private int viewers;
        private double scoreSum;
        private double maxScore;
        private double averageScore;
        private EpisodeDesc episode;

        public int GetViewerCount() { return this.viewers; }
        public double GetScoreSum() { return this.scoreSum; }
        public double GetMaxScore() { return this.maxScore; }

        public void SetViewerCount(int viewers) { this.viewers = viewers; }
        public void SetScoreSum(double scoreSum) { this.scoreSum = scoreSum; }
        public void SetMaxScore(double maxScore) { this.maxScore = maxScore; }

        public Episode ()
        {

        }
        public Episode(int viewers, double scoreSum, double maxScore, EpisodeDesc episode)
        {
            this.viewers = viewers;
            this.scoreSum = scoreSum;
            this.maxScore = maxScore;
            this.episode = episode;
        }

        public void AddView(double currentScore)
        {
            this.scoreSum += currentScore;

            if(currentScore > maxScore)
            {
                this.maxScore = currentScore;
            }

            this.viewers += 1;
        }

        public double GetAverageScore()
        {
            this.averageScore = this.scoreSum / this.viewers;
            return averageScore;
        }

        public override string ToString()
        {
            return $"{viewers}, {scoreSum}, {maxScore}, {episode}";
        }
    }

    public class EpisodeDesc
    {
        private int episodeNumber;
        private TimeSpan episodeLength;
        private string episodeName;

        public EpisodeDesc(int episodeNumber, TimeSpan episodeLength, string episodeName)
        {
            this.episodeNumber = episodeNumber;
            this.episodeLength = episodeLength;
            this.episodeName = episodeName;
        }

        public override string ToString()
        {
            return $"{episodeNumber}, {episodeLength}, {episodeName}";
        }
    }

    public class TvUtilities
    {
        private static Random generator = new Random();
        private static double currentScore;
        public static double GenerateRandomScore()
        {
            currentScore = generator.NextDouble() * (10.0 - 0.0) + 0.0;
            return currentScore;
        }

        public static Episode Parse(string episodeInput)
        {
            string[] episode = episodeInput.Split(',');
            int viewers = Convert.ToInt16(episode[0]);
            double scoreSum = Convert.ToDouble(episode[1]);
            double maxScore = Convert.ToDouble(episode[2]);
            int episodeNumber = Convert.ToInt16(episode[3]);
            TimeSpan episodeLength = TimeSpan.Parse(episode[4]);
            string episodeName = episode[5];

            return new Episode(viewers, scoreSum, maxScore, new EpisodeDesc(episodeNumber, episodeLength, episodeName));
        }

        public static void Sort(Episode[] episodes)
        {
            for(int j = 0; j <= episodes.Length - 2; j++)
            {
                for(int i = 0; i <= episodes.Length - 2; i++)
                {
                    if(episodes[i].GetAverageScore() < episodes[i+1].GetAverageScore())
                    {
                        Swap(ref episodes[i + 1], ref episodes[i]);
                    }
                }
            }
        }

        public static void Swap(ref Episode ep1, ref Episode ep2)
        {
            Episode tmp = ep1;
            ep1 = ep2;
            ep2 = tmp;
        }
    }
}