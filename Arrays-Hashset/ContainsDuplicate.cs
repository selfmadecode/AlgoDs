namespace AlgoDs.Arrays_Hashset;

public class ContainsDuplicate
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
}

public class Anagram
{
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
}

