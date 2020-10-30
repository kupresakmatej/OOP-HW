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
        //private static Random generator = new Random();
        //private static double currentScore;

        public int GetViewerCount() { return this.viewers; }
        public double GetScoreSum() { return this.scoreSum; }
        public double GetMaxScore() { return this.maxScore; }

        public void SetViewerCount(int viewers) { this.viewers = viewers; }
        public void SetScoreSum(double scoreSum) { this.scoreSum = scoreSum; }
        public void SetMaxScore(double maxScore) { this.maxScore = maxScore; }

        public Episode ()
        {

        }
        public Episode(int viewers, double scoreSum, double maxScore)
        {
            this.viewers = viewers;
            this.scoreSum = scoreSum;
            this.maxScore = maxScore;
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

        //public static double GenerateRandomScore()
        //{
        //    currentScore = generator.NextDouble() * (10.0 - 0.0) + 0.0;
        //    return currentScore;
        //}
    }
}