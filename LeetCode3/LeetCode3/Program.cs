using System;
using System.Collections.Generic;

public class Solution
{

    // Method 1: Sliding Window with HashSet (Most Intuitive)
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;

        HashSet<char> seen = new HashSet<char>();
        int left = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // If character is already in window, shrink from left
            while (seen.Contains(s[right]))
            {
                seen.Remove(s[left]);
                left++;
            }

            // Add current character to window
            seen.Add(s[right]);

            // Update maximum length
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    // Method 2: Optimized Sliding Window with Dictionary (Faster)
    public int LengthOfLongestSubstringOptimized(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;

        Dictionary<char, int> charIndex = new Dictionary<char, int>();
        int left = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char currentChar = s[right];

            // If character exists and is within current window
            if (charIndex.ContainsKey(currentChar) && charIndex[currentChar] >= left)
            {
                // Jump left pointer to position after the duplicate
                left = charIndex[currentChar] + 1;
            }

            // Update character's last seen position
            charIndex[currentChar] = right;

            // Update maximum length
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}

// Test class to demonstrate both solutions
public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        // Test cases
        string[] testCases = {
            "abcabcbb",    // Expected: 3 ("abc")
            "bbbbb",       // Expected: 1 ("b")
            "pwwkew",      // Expected: 3 ("wke")
            "",            // Expected: 0
            "au",          // Expected: 2 ("au")
            "dvdf",        // Expected: 3 ("vdf")
            "abcdef",      // Expected: 6 ("abcdef")
            "abba"         // Expected: 2 ("ab" or "ba")
        };

        Console.WriteLine("=== Method 1: HashSet Sliding Window ===");
        foreach (string test in testCases)
        {
            int result = solution.LengthOfLongestSubstring(test);
            Console.WriteLine($"Input: \"{test}\" -> Output: {result}");
        }

        Console.WriteLine("\n=== Method 2: Optimized Dictionary ===");
        foreach (string test in testCases)
        {
            int result = solution.LengthOfLongestSubstringOptimized(test);
            Console.WriteLine($"Input: \"{test}\" -> Output: {result}");
        }

        // Detailed walkthrough for "abcabcbb"
        Console.WriteLine("\n=== Detailed Walkthrough: 'abcabcbb' ===");
        DetailedWalkthrough("abcabcbb");
    }

    // Helper method to show step-by-step execution
    public static void DetailedWalkthrough(string s)
    {
        HashSet<char> seen = new HashSet<char>();
        int left = 0;
        int maxLength = 0;

        Console.WriteLine($"String: {s}");
        Console.WriteLine("Step | Right | Char | Left | Window | Max Length");
        Console.WriteLine("-----|-------|------|------|--------|----------");

        for (int right = 0; right < s.Length; right++)
        {
            while (seen.Contains(s[right]))
            {
                seen.Remove(s[left]);
                left++;
            }

            seen.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);

            string window = s.Substring(left, right - left + 1);
            Console.WriteLine($"  {right}  |   {right}   |  {s[right]}   |  {left}   | {window,-6} | {maxLength}");
        }

        Console.WriteLine($"\nFinal Answer: {maxLength}");
        Console.ReadKey();
    }
}