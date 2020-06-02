using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace FiveNumberStatsProgram
{
    class Program
    {
        static void Main()
        {
            //Ask user for input
            Console.Write("How many numbers are there? ");
            int totalNum = Convert.ToInt32(Console.ReadLine());
            var nums = new double[totalNum];

            //Get each number and enter into an array
            for(int index = 0; index < totalNum; index++)
            {
                Console.WriteLine("Enter num: ");
                nums[index] = Convert.ToDouble(Console.ReadLine());
            }

            //Sort the list
            Array.Sort(nums);

            Console.WriteLine("MIN: {0} MAX: {1}", nums[0], nums[totalNum - 1]);
            Console.WriteLine("Q1: {0}  MEDIAN: {1}  Q3: {2}", Percentile(nums, 25), Percentile(nums, 50), Percentile(nums, 75));
        }

        static double Percentile(double[] nums, int totalNums)
        {

            if (totalNums >= 100) return nums[nums.Length - 1];

            double position = (nums.Length + 1) * totalNums / 100;
            double leftNumber = 0.0d, rightNumber = 0.0d;

            double n = totalNums / 100.0d * (nums.Length - 1) + 1.0d;

            if (position >= 1)
            {
                leftNumber = nums[(int)Math.Floor(n) - 1];
                rightNumber = nums[(int)Math.Floor(n)];
            }
            else
            {
                leftNumber = nums[0]; // first data
                rightNumber = nums[1]; // first data
            }

            //if (leftNumber == rightNumber)
            if (Equals(leftNumber, rightNumber))
                return leftNumber;
            double part = n - Math.Floor(n);
            return leftNumber + part * (rightNumber - leftNumber);
        } 
    }
}
