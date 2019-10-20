using System;
using System.Collections;

namespace RollingAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] {5, 42, 79, 16, 57, 16, 82, 34};
            int window = 4;

            Console.WriteLine("CalculateRollingAverageWithQueue");

            ArrayList rollingAverageResults = CalculateRollingAverageWithQueue(input, window);

            foreach(var rollingAverage in rollingAverageResults)
            {
                Console.WriteLine(rollingAverage);
            }

            Console.WriteLine("\nCalculateRollingAverageWithForLoop");
            rollingAverageResults = CalculateRollingAverageWithForLoop(input, window);

            foreach (var rollingAverage in rollingAverageResults)
            {
                Console.WriteLine(rollingAverage);
            }

        }

        //I should have just originally used a queue FIFO for the rolling window
        private static ArrayList CalculateRollingAverageWithQueue(int[] inputNumbers, int window)
        {
            Queue processingQueue = new Queue();
            ArrayList calculatedRollingAverages = new ArrayList();
            int rollingSum = 0;

            foreach (var number in inputNumbers)
            {
                processingQueue.Enqueue(number);
                rollingSum += number;

                if(processingQueue.Count == window)
                {
                    calculatedRollingAverages.Add((double)rollingSum / window);
                    rollingSum -= (int)processingQueue.Dequeue();
                }
            }

            return calculatedRollingAverages;
        }

        //My second path I had was just to start iterating the list at the index corresponding to the start of the window
        private static ArrayList CalculateRollingAverageWithForLoop(int[] inputNumbers, int window)
        {
            ArrayList calculatedRollingAverages = new ArrayList();
            int rollingSum = 0;
            int maxWindowIndex = window - 1;

            for (int i = maxWindowIndex; i < inputNumbers.Length; i++)
            {
                rollingSum = 0;

                for (int j = i - maxWindowIndex; j <= i; j++)
                {
                    rollingSum += inputNumbers[j]; 
                }

                calculatedRollingAverages.Add((double)rollingSum / window);
            }

            return calculatedRollingAverages;
        }
    }
}
