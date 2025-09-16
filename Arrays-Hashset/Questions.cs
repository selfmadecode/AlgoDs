using System.Collections;
using System.Diagnostics;

namespace AlgoDs.Arrays_Hashset;

public partial class Questions
{
    /*
     * Question:
     
        Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
        Example 1:

        Input: nums = [1,2,3,1]
        Output: true
        Example 2:

        Input: nums = [1,2,3,4]
        Output: false
        Example 3:

        Input: nums = [1,1,1,3,3,4,3,2,4,2]
        Output: true
     */

    public static bool ContainsDuplicateSolution(int[] nums)
    {
        var noDuplicate = new HashSet<int>(); // space complexity O(n)
        foreach (int item in nums) // time complexity O(n)
        {
            if (noDuplicate.Contains(item))
                return true;

            noDuplicate.Add(item);
        }
        return false;
    }

    /*
     * Given two strings s and t, return true if t is an anagram of s, and false otherwise.

        An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
        typically using all the original letters exactly once.
        Example 1:

        Input: s = "anagram", t = "nagaram"
        Output: true
        Example 2:

        Input: s = "rat", t = "car"
        Output: false
     */
    public static bool IsAnagram(string s = "anagram", string t = "nagaram")
    {
        if (s.Length != t.Length)
            return false;
        // Create a Dictionary containing char as Key and
        // int as Value. We will be storing character as
        // Key and count of character as Value.
        var map = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            // If contains increase count by 1 for that character
            if (map.ContainsKey(s[i]))
                map[s[i]] = map[s[i]] + 1;
            else
                map.Add(s[i], 1);
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (map.ContainsKey(t[i]))
                map[t[i]] = map[t[i]] - 1;
            else
                return false;
        }

        var keys = map.Keys;

        foreach (var chr in keys)
        {
            if (map[chr] != 0)
                return false;
        }

        return true;

        //     var charArray1 = s.ToCharArray();
        //     var charArray2 = t.ToCharArray();

        //     Array.Sort(charArray1);
        //     Array.Sort(charArray2);

        //     for(int i = 0; i < charArray1.Length; i++){
        //         if(charArray1[i] != charArray2[i])
        //             return false;
        
        //return string.Concat(charArray1) == string.Concat(charArray2);

    }

    /*
     * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
       You may assume that each input would have exactly one solution, and you may not use the same element twice.
       You can return the answer in any order.

        Example 1:

        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
        Example 2:

        Input: nums = [3,2,4], target = 6
        Output: [1,2]
        Example 3:

        Input: nums = [3,3], target = 6
        Output: [0,1]
     */

    public static int[] TwoSum(int target = 9)
    {        
        int[] nums = { 1, 1, 1, 1, 4, 7, 2, 1, 1, 1, 1 };

        var values = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var difference = target - nums[i];

            if (values.ContainsKey(difference))
                return new int[] { i, values[difference] };

            else if (!values.ContainsKey(nums[i])) // skip if the num[i] already exists as a key
                values.Add(nums[i], i);
        };

        return Array.Empty<int>();
    }

    
    public static int BestTimeToBuyandSellStock(int[] nums)
    {
        int[] prices = { 7, 1, 3, 4, 2, 42, 34 };
        int profit = 0;
        int leftPosition = 0;

        for(int rightPosition = 1; rightPosition < prices.Length; rightPosition++)
        {
            if (prices[leftPosition] < prices[rightPosition])
            {
                profit = Math.Max(profit, prices[rightPosition] - prices[leftPosition]);
            }
            else
            {
                leftPosition = rightPosition;
            }
        }

        return profit;
    }

    //    There is a malfunctioning keyboard where some letter keys do not work.All other keys on the keyboard work properly.
    //Given a string text of words separated by a single space (no leading or trailing spaces) and a string brokenLetters of all distinct letter keys that are broken, return the number of words in text you can fully type using this keyboard.

    //Example 1:

    //Input: text = "hello world", brokenLetters = "ad"
    //Output: 1
    //Explanation: We cannot type "world" because the 'd' key is broken.

    public static int CanBeTypedWords(string text = "hello world", string brokenLetters = "ad")
    {
        var brokenLetterCharacters = new HashSet<char>(brokenLetters);
        //var count = text.Split(" ").Count(word => word.All(ch => !brokenLetterCharacters.Contains(ch)));

        // best approach
        int count = 0;
        foreach (var word in text.Split(" "))
        {
            bool canBeTyped = true;
            foreach (var ch in word)
            {
                if (brokenLetterCharacters.Contains(ch))
                {
                    canBeTyped = false;
                    break;
                }
            }

            if(canBeTyped)
                count++;
        }

        return count;
    }
}