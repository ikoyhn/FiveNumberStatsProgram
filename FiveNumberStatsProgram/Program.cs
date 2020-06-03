using System;
using Calculations;
using System.Collections.Generic;
using System.Xml.Schema;
using Calculations;

namespace FiveNumberSummary
{
    class MainProgram
    {
        static void Main()
        {
            //Ask user for input
            Console.Write("How many numbers are there? ");
            int totalNums = Convert.ToInt32(Console.ReadLine());
            var nums = new double[totalNums];

            //Get each number and enter into an array
            for(int index = 0; index < totalNums; index++)
            {
                Console.WriteLine("Enter num: ");
                nums[index] = Convert.ToDouble(Console.ReadLine());
            }

            //Sort the list
            Array.Sort(nums);

            Console.WriteLine("MIN:{0} Q1:{1} MEDIAN:{2}  Q3:{3} MAX:{4}", Operations.Min(nums,totalNums), Operations.Percentile(nums, 25), Operations.Percentile(nums, 50), Operations.Percentile(nums, 75), Operations.Max(nums,totalNums));
        }
    }
}

namespace Calculations
{
    class Operations
    {
        public static double Percentile(double[] nums, int totalNums)
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

        public static double Min(double[] nums, int totalNums)
        {
            double min = nums[0];
            return min;
        }

        public static double Max(double[] nums, int totalNums)
        {
            double max = nums[totalNums - 1];
            return max;
        }
    }
}