
// See https://aka.ms/new-console-template for more information
using System.Numerics;
int[] c = new int[4] { 2, 3, 4, 5 };
int[] x = {1,2,3,4,5 };

Console.WriteLine("Hello, World!");

public class Solution
{
    public int[]? TwoSum(int[] nums, int target)
    {
        int i = 0, j = 0;
        foreach (int num in nums)
        {
            for (j = i + 1; j < nums.Length; j++)
            {
                if (target == nums[j] + num)
                {
                    return [i, j];
                }
            }
            i++;
        }
        return null;
    }
}