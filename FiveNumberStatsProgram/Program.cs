using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace FiveNumberStatsProgram
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("How many numbers are there");
            int totalNum = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[totalNum];

            for(int index = 0; index < totalNum; index++)
            {
                Console.WriteLine("Enter num: ");
                nums[index] = Convert.ToInt32(Console.ReadLine());
            }
            Array.Sort(nums);
            MaxMin(nums, totalNum);
            Median(nums, totalNum);

        }
        static void MaxMin(int[] nums, int totalNum)
        {
            Console.WriteLine("MIN: {0} MAX: {1}", nums[0], nums[totalNum-1]);
        }

        static void Median(int[] nums, int totalNum)
        {
            double mediaValue = 0.0;

            if (totalNum % 2 == 0)
            {
                var firstValue = nums[(nums.Length / 2) - 1];
                var secondValue = nums[(nums.Length / 2)];
                mediaValue = (firstValue + secondValue) / 2.0;
            }
            if (totalNum % 2 == 1)
            {
                mediaValue = nums[(nums.Length / 2)];
            }
            Console.WriteLine("MEDIAN: {0}",mediaValue);

        }

        static double Percentile(double[] sortedData, double p)
        {
            // algo derived from Aczel pg 15 bottom
            if (p >= 100.0d) return sortedData[sortedData.Length - 1];

            double position = (sortedData.Length + 1) * p / 100.0;
            double leftNumber = 0.0d, rightNumber = 0.0d;

            double n = p / 100.0d * (sortedData.Length - 1) + 1.0d;

            if (position >= 1)
            {
                leftNumber = sortedData[(int)Math.Floor(n) - 1];
                rightNumber = sortedData[(int)Math.Floor(n)];
            }
            else
            {
                leftNumber = sortedData[0]; // first data
                rightNumber = sortedData[1]; // first data
            }

            //if (leftNumber == rightNumber)
            if (Equals(leftNumber, rightNumber))
                return leftNumber;
            double part = n - Math.Floor(n);
            return leftNumber + part * (rightNumber - leftNumber);
        }
    }
}
