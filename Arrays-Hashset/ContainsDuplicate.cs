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
