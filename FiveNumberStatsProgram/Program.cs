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
    }
}
