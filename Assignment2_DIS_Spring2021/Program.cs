﻿using System;
using System.Collections.Generic;

namespace Assignment2_DIS_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            Console.WriteLine("Question 1");
            ShuffleArray(ar1, n1);

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = {0,1,0,3,12};
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if(Isomorphic(s61,s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } ,{ 2, 50 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if(HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number",n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if(profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}",profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        /// Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        /// Example 1:
        /// Input: nums = [2,5,1,3,4,7], n = 3
        /// Output: [2,3,5,4,1,7]
        /// Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        /// Example 2:
        /// Input: nums = [1,2,3,4,4,3,2,1], n = 4
        /// Output: [1,4,2,3,3,2,4,1]
        /// Example 3:
        /// Input: nums = [1,1,2,2], n = 2
        /// Output: [1,2,1,2]
        /// </summary>
        
        /*
         * Approach: Run a loop till the middle of the array
         * in every pass, take one element from the first half and
         * the second element from the second half.
         * time complexity = O(n)
         * space complexity = O(n)
         */

        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {
                int[] result = new int[2 * n];
                int j = 0;
                for (int i = 0; i < n; i++)
                {
                    // get the first element from the first half
                    result[j++] = nums[i];
                    // get the second element from the second half
                    result[j++] = nums[i + n];
                }
                // print to console
                Console.Write("The suffled array is: ");
                for(int i = 0; i < 2 * n; i++)
                {
                    Console.Write(result[i] + " ");
                }
                Console.Write("\n\n");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>
       
        /*
         * Approach: Determine the first occurence of 0 and store the index i of that
         * For every subsequent nonzero element copy it to the index i+1 and increment the index.
         * from i till the end of the loop, fill all the slots with 0.
         * time complexity = O(n)
         * space complexity = O(1)
         */

        private static void MoveZeroes(int[] nums)
        {
            try
            {
                int i = 0;
                int j = 0;

                // find the first occurence of 0
                while (i < nums.Length && nums[i] != 0)
                {
                    i++;
                }
                // edge case: no 0 present then print to console and return 
                if (i == nums.Length)
                {
                    // print to console when no 0 present
                    Console.Write("The array with all 0s at right: ");
                    for (int l = 0; l < nums.Length; l++)
                    {
                        Console.Write(nums[l] + " ");
                    }
                    return;
                }
                // record the first occurence of 0
                j = i;
                // this index will search for non-zero numbers after the first occurence of zero
                i = j + 1;
                while (i < nums.Length)
                {
                    // if current element is 0 then see the next element
                    if (nums[i] == 0)
                    {
                        i++;
                    }
                    else
                    {
                        // put the current element in the position having index j
                        nums[j++] = nums[i++];
                    }
                }
                // rest all position should have 0
                while (j < nums.Length)
                {
                    nums[j++] = 0;
                }
                // Write the output to console
                Console.Write("The array with all 0s at right: ");
                for(int l = 0; l < nums.Length; l++)
                {
                    Console.Write(nums[l] + " ");
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        /// Question 3
        /// <summary>
        /// For an array of integers - nums
        /// A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        /// Print the number of cool pairs
        /// Example 1
        /// Input: nums = [1,2,3,1,1,3]
        /// Output: 4
        /// Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        /// Example 3:
        /// Input: nums = [1, 2, 3]
        /// Output: 0
        /// Constraints: time complexity should be O(n).
        /// </summary>

        /*
         * Approach: Maintain a dictionary with distinct elements as keys and their count as values
         * if a number is present n times then number of cool pair possible is n(n-1)/2;
         * Traverse through the dictionary to calculate this.
         * time complexity = O(n)
         */
        private static void CoolPairs(int[] nums)
        {
            try
            {
                Dictionary<int, int> h = new Dictionary<int, int>();
                // store the count of the distinct elements in the dictionary
                for (int i = 0; i < nums.Length; i++)
                {
                    if (h.ContainsKey(nums[i]))
                    {
                        h[nums[i]] += 1;
                    }
                    else
                    {
                        h.Add(nums[i], 1);
                    }
                }
                // calculate the number of cool pairs possible with each distinct value and sum them up  
                Dictionary<int, int>.KeyCollection keyColl = h.Keys;
                int total = 0;
                foreach (int s in keyColl)
                {
                    total += (h[s] * (h[s] - 1) / 2);
                }
                // Write the output to console
                Console.WriteLine("The number of cool pairs: " + total);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        /// Example 1:
        /// Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        /// Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        /// Example 2:
        /// Input: nums = [3,2,4], target = 6
        /// Output: [1,2]
        /// Example 3:
        /// Input: nums = [3,3], target = 6
        /// Output: [0,1]
        /// Constraints: Time complexity should be O(n)
        /// </summary>
        /// 

        /*
         * Approach: create dictionary where key = items and value = index
         * while inserting every element check if (target-element) is present in the dictionary keys
         * print the correspinding indices.
         */
        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> h = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    // check if target - element is present in the array
                    if (h.ContainsKey(target - nums[i]))
                    {
                        // output to console
                        Console.WriteLine("positions are (" + h[target - nums[i]] + "," + i + ")");
                        break;
                    }
                    // otherwise add the <K,V> pair in the dictionary
                    h.Add(nums[i], i);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        /// The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        /// Print the shuffled string.
        /// Example 1
        /// Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        /// Output: "usfrocky"
        /// Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        /// Example 2:
        /// Input: s = "USF", indices = [0,1,2]
        /// Output: "USF"
        /// Explanation: After shuffling, each character remains in its position.
        /// Example 3:
        /// Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        /// Output: "rocky"
        /// </summary>
        /// 

        /*
         * Approach: Create a dictionary having indices as keys and items as values
         * Build the array by feteching element corresponding to every index in O(1) time
         * from the dictionary.
         * time complexity = O(n)
         */
        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                int l = s.Length;
                Dictionary<int, String> d = new Dictionary<int, String>();
                // create the dictionary
                for (int i = 0; i < l; i++)
                {
                    d.Add(indices[i], s[i].ToString());
                }
                string output = "";
                // build the string by querying the dictionary with the index values.
                for (int i = 0; i < l; i++)
                {
                    output += d[i];
                }
                Console.WriteLine("The suffled string is : "+ output);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        /// Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        /// All occurrences of a character must be replaced with another character while preserving the order of characters.
        /// No two characters may map to the same character but a character may map to itself.
        /// Example 1:
        /// Input:s1 = “bulls” s2 = “sunny” 
        /// Output : True
        /// Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        /// Example 2:
        /// Input: s1 = “usf” s2 = “add”
        /// Output : False
        /// Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        /// Example 3:
        /// Input : s1 = “ab” s2 = “aa”
        /// Output: False
        /// </summary>
        /// 

        /*
         * Approach: for two strings s and t create a dictionary with s[i] as key 
         * and t[i] as value. while inserting check if two diffrent keys are mapped to the same values.
         * if the dictionary is already having the same key as s[i], check if the value is 
         * matching with t[i].
         * time complexity = O(n);
         */
        private static bool Isomorphic(string s, string t)
        {
            try
            {
                Dictionary<char, char> h = new Dictionary<char, char>();
                // edge case: if the two array are of unequal length, 
                // there is no point in checking further
                if (s.Length != t.Length)
                {
                    return false;
                }
                int i = 0;
                while (i < s.Length)
                {
                    // two different keys can not be mapped to the same values.
                    if (!(h.ContainsKey(s[i]) || h.ContainsValue(t[i])))
                    {
                        h.Add(s[i], t[i]);
                    }
                    else
                    {
                        // if the key is not there or the value does not match,
                        // the strings can not be isomorphic to each other
                        if (!h.ContainsKey(s[i]) || h[s[i]] != t[i])
                        {
                            return false;
                        }
                    }
                    i++;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        /// 

        /*
         * Approach: Here sorting is the trickiest. sort by id ascending order, but if for two
         * element, their ids are found to be equal then sort by marks descending order.
         * After this take the top 5 entry corresponding to the same id and sum their scores. 
         */
        private static void HighFive(int[,] items)
        {
            try
            {
                List<int[]> list = new List<int[]>();
                List<int[]> result = new List<int[]>();
                // converting to list so that, we can use delegates and lambda expression for sorting
                for(int i = 0; i < items.GetLength(0); i++)
                {
                    list.Add(new int[] { items[i, 0], items[i, 1] });
                }
                // sorting the list
                list.Sort((x, y) => { return (x[0] < y[0]) ? -1 : ((x[0] == y[0]) ? ((x[1] <= y[1]) ? 1 : -1) : 1); });
                int m = list[0][0];
                int c = 1;
                int s = list[0][1];

                // taking the top 5 entries of every id and computing its sum
                for(int i = 1; i < list.Count; i++)
                {
                    if(list[i][0]==m && c < 5)
                    {
                        s += list[i][1];
                        c += 1;
                    }
                    else if(list[i][0]!=m)
                    {
                        result.Add(new int[] { m, s });
                        Console.WriteLine("id=" + m + " highfive=" + s);
                        m = list[i][0];
                        c = 1;
                        s = list[i][1];
                    }
                }
                result.Add(new int[] { m, s });
                Console.WriteLine("id=" + m + " highfive=" + s);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        /// A happy number is a number defined by the following process:
        /// •	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        /// •	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        /// •	Those numbers for which this process ends in 1 are happy.
        /// Return true if n is a happy number, and false if not.
        /// Example 1:
        /// Input: n = 19
        /// Output: true
        /// Explanation:
        /// 12 + 92 = 82
        /// 82 + 22 = 68
        /// 62 + 82 = 100
        /// 12 + 02 + 02 = 1
        /// Example 2:
        /// Input: n = 2
        /// Output: false
        /// Constraints:
        /// 1 <= n <= 231 - 1
        /// </summary>
        /// 

        /*
         * create a recursive function. But after computing the sum of squares of the digits
         * store it in the hashset, so that when the given number is not a happy number it can be
         * detected by checking the hashset.
         */
        private static HashSet<int> store = new HashSet<int>();
        private static bool HappyNumber(int n)
        {
            try
            {
                // store into hashset
                store.Add(n);
                // if n=1 its already a happoy number
                if (n == 1)
                {
                    return true;
                }

                // compute sum of squares of the digit
                int s = 0;
                while (n > 0)
                {
                    int d = n % 10;
                    s += Convert.ToInt32(Math.Pow(d, 2));
                    n = n / 10;
                }
                // check if the value is already there in the hashset
                // then it is not a happy number
                if (!store.Contains(s))
                {
                    return HappyNumber(s);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        /*
         * traverse from right to left with the last element as sell value. whenever buy value 
         * is more than sell value, set new sell value = current buy value. Everytime calculate the profit
         * and compare it with already encountered max.
         * time complexity = O(n)
         */


        private static int Stocks(int[] prices)
        {
            try
            {
                int maxp = 0;
                int sell = prices.Length - 1;
                int buy = sell - 1;

                // traverse backwards
                // buy and sell are carrying index numbers
                while (buy >= 0)
                {
                    // set the new sell index when value at buy 
                    //index is more than the value at the sell index 
                    if (prices[buy] > prices[sell])
                    {
                        sell = buy;
                        buy = sell - 1;
                    }
                    else
                    {
                        // calculate the running profit and compare it with the max so far
                        maxp = Math.Max(maxp, prices[sell] - prices[buy]);
                        buy--;
                    }
                }
                return maxp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        /// Input: n = 2
        /// Output: 2
        /// Explanation: There are two ways to climb to the top.
        /// 1. 1 step + 1 step
        /// 2. 2 steps
        /// Example 2:
        /// Input: n = 3
        /// Output: 3
        /// Explanation: There are three ways to climb to the top.
        /// 1. 1 step + 1 step + 1 step
        /// 2. 1 step + 2 steps
        /// 3. 2 steps + 1 step
        /// Hint : Use the concept of Fibonacci series.
        /// </summary>
        /*
         * Approach = step i can be climed by climbing one step from step i-1 or by climbing 2 step from 
         * step i-2. We have to use dynamic programming.
         * Time Complexity = O(n)
         * Space Complexity = O(1)
         */
        private static void Stairs(int n)
        {
            try
            {
                int output = 0;
                // for step 0;
                int a = 1; 
                // for step 1
                int b = 1;
                // if n<=1 we do not have to compute any other value
                if (n <= 1)
                {
                    output= 1;
                }
                // to reduce space complexity only store the last two values
                for (int i = 2; i <= n; i++)
                {
                    a = a + b;
                    //swap a and b
                    int temp = a;
                    a = b;
                    b = temp;
                }
                output = b;
                // output to console
                Console.WriteLine("The total number of unique ways is "+output);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
