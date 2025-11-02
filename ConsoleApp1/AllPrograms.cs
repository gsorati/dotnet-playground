using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace Programs
{
    public class AllPrograms
    {
        public void CallPrograms()
        {
            ////int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            ////int bs = new BinarySearch().Search(arr, 6);
            ////Console.WriteLine("result:{0}", bs);


            ////// Recurssion
            ////Recurssion recurssion = new Recurssion();
            ////Console.WriteLine("Factorical of Num is : {0}", recurssion.FactoricalOfNum(4));
            ////Console.WriteLine("Is Palindrome : {0}", recurssion.IsPalindrome("GADAG", 0, 4));
            ////Console.WriteLine("Sum of Digits : {0}", recurssion.SumOfDigits(124594));
            ////Console.WriteLine("Max rope counts : {0}", recurssion.MaxRopeCut(9, 2, 2, 2));
            ////recurssion.GenerateSubSet("ABC");
            ////recurssion.TowerOfHonoi(2, 'a', 'b', 'c');
            ////Console.WriteLine("Servier in the circule : {0}", recurssion.JoshephusProblem(7, 3));
            ////Console.WriteLine("Count of subset of number : {0}", recurssion.CountSumOfSubSet(new int[] { 10, 5, 2, 3, 6 }, 8, 5));

            // remove duplicates
            ////RemoveDuplicates();

            // Count of consigative repeating characters in string
            ////ConsigativeRepeatingCharsCount("***%%**********%%%");
            ////ConsigativeRepeatingCharsCount("***%%%%***%%%");

            /* processes an integer array(input) level by level in a binary tree - like pattern, where each "level" has double the number of elements as the previous.At each level, it counts how many odd numbers exist, stores that count, and finally prints the level with the maximum odd numbers. */
            FindMaxOddCountLevel(new int[] { 1, 3, 3, 4, 5, 7, 9 });

            // Hashing
            ////new Hashing().CallPrograms();

            // Strings
            //new strings().CallPrograms();
        }

        public void RemoveDuplicates()
        {
            int[] arr = { 10, 20, 20, 30, 40, 40, 50 };
            ArrayList arl = new ArrayList();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!arl.Contains(arr[i]))
                {
                    arl.Add(arr[i]);
                }
            }
            foreach (int ar in arl)
                Console.WriteLine(ar.ToString());
        }

        public void ConsigativeRepeatingCharsCount(string input)
        {
            var output = "";
            var count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                    count++;
                else
                {
                    output += count;
                    count = 1;
                }
            }
            output += count;
            Console.WriteLine(output);
        }

        public void FindMaxOddCountLevel(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                Console.WriteLine("Input array is empty.");
                return;
            }

            int maxOddNum = 0;
            var maxOddIndex = 0;
            var index = 0;
            var level = 0;
            var levelCount = 1;
            Dictionary<int, int> oddNumsDict = new Dictionary<int, int>();
            while (index < input.Length)
            {
                var oddNumsCount = 0;
                for (int i = 0; i < levelCount; i++)
                {
                    if (input[index] % 2 != 0)
                        oddNumsCount++;
                    index++;
                }
                oddNumsDict[level] = oddNumsCount;
                levelCount *= 2;
                level++;
            }

            foreach (var key in oddNumsDict.Keys)
            {
                if (maxOddNum < oddNumsDict[key])
                {
                    maxOddNum = oddNumsDict[key];
                    maxOddIndex = key;
                }
            }

            Console.WriteLine($"index: {maxOddIndex} - num: {maxOddNum}");
        }
    }

    public class BinarySearch
    {
        public int Search(int[] arr, int searchElement)
        {

            int low = 0;
            int mid;
            int high = arr.Length - 1;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (arr[mid] == searchElement)
                {
                    return mid;
                }
                else
                {
                    if (arr[mid] < searchElement)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }
            return -1;
        }
    }

    public class Recurssion
    {
        /// <summary>
        /// Time complexity:O(n)
        /// Auxilalary space: Theta(n)
        /// </summary>
        public int FactoricalOfNum(int n)
        {
            if (n == 1)
                return 1;

            return n * FactoricalOfNum(n - 1);
        }

        /// <summary>
        /// Time complexity:O(n)
        /// Auxilalary space: Theta(n/2)==> Theta(n)
        /// </summary>
        public bool IsPalindrome(String s, int start, int end)
        {
            if (start >= end)
                return true;

            return (s[start] == s[end]) && IsPalindrome(s, start + 1, end - 1);
        }

        /// <summary>
        /// Time complexity:Theta(d) where d is number of digits
        /// Auxilalary space: Theta(d)
        /// </summary>
        public int SumOfDigits(int n)
        {
            if (n == 0)
                return 0;

            return SumOfDigits(n / 10) + n % 10;
        }

        /// <summary>
        /// i/p: 5,2,5,1 o/p: 5
        /// i/p: 23,12,9,11 o/p: 2
        /// Time complexity:O(3 power n)
        /// Auxilalary space: O(3 power n)
        /// </summary>
        public int MaxRopeCut(int n, int a, int b, int c)
        {
            int res = 0;
            if (n == 0) return 0;
            if (n <= 0) return -1;

            res = Math.Max(MaxRopeCut(n - a, a, b, c), Math.Max(MaxRopeCut(n - b, a, b, c), MaxRopeCut(n - c, a, b, c)));

            return res == -1 ? -1 : res + 1;
        }

        /// <summary>
        /// i/p: "AB" o/p: '', 'A', 'B', 'AB'
        /// i/p: "ABC" o/p: '', 'A', 'B', 'C', 'AB', 'BC', 'CA', 'ABC'
        /// </summary>
        public void GenerateSubSet(string s, string curr = "", int i = 0)
        {
            if (i == s.Length)
            {
                Console.WriteLine(curr);
                return;
            }

            GenerateSubSet(s, curr, i + 1);
            GenerateSubSet(s, curr + s[i], i + 1);
        }

        /// <summary>
        /// i/p:2,'a','b','c' o/p: Move disk form a to b, Move disk form a to c, Move disk form b to c
        /// </summary>
        public void TowerOfHonoi(int n, char a, char b, char c)
        {
            if (n == 1)
            {
                Console.WriteLine("Move disk form {0} to {1}", a, c);
                return;
            }

            TowerOfHonoi(n - 1, a, c, b);
            Console.WriteLine("Move disk form {0} to {1}", a, c);
            TowerOfHonoi(n - 1, b, a, c);
        }

        /// <summary>
        /// Kill every third person wiht circular manner and print serviver.
        /// i/p: n = 7 , k=3 (kill)
        /// </summary>
        public int JoshephusProblem(int n, int k)
        {
            if (n == 1) return 0;
            else
                return (JoshephusProblem(n - 1, k) + k) % n;
        }

        /// <summary>
        /// i/p: {10,5,2,3,6} sum =8 o/p =2
        /// i/p: {1,2,3} sum = 4 o/p: 1
        /// i/p: {10,20,15} sum = 37 o/p: 0
        /// i/p: {10,20,15} sum = 0 o/p: 1
        /// </summary>
        public int CountSumOfSubSet(int[] arr, int sum, int n)
        {
            if (n == 0) return (sum == 0) ? 1 : 0;
            return CountSumOfSubSet(arr, sum, n - 1) + CountSumOfSubSet(arr, sum - arr[n - 1], n - 1);
        }
    }

    public class Hashing
    {
        public void CallPrograms()
        {
            var CountDistinctinput = new int[] { 15, 12, 13, 12, 13, 13, 18 }; // 4
            // var CountDistinctinput = new int[] { 10, 10, 10 }; // 1
            //var CountDistinctinput = new int[] { 10, 11, 12 }; // 3
            this.CountDistinctElements(CountDistinctinput);

            Console.WriteLine("******Frequencies of elements*******");
            //var frequenciesOfElementsinput = new int[] { 10, 12, 10, 15, 10, 20, 12, 12 }; // 4
            //var frequenciesOfElementsinput = new int[] { 10, 10, 10 }; // 1
            var frequenciesOfElementsinput = new int[] { 10, 11, 12 }; // 3
            this.FrequenciesOfElements(frequenciesOfElementsinput);
        }

        private void CountDistinctElements(int[] array)
        {
            // Naive solution
            int count = 1;
            for (int i = 1; i < array.Length; i++)
            {
                var isExist = false;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    count++;
                }
            }

            Console.WriteLine($"Count of distinct elements using Naive solution: {count}");

            // Efficient solution
            HashSet<int> hashSet = new HashSet<int>(array);
            Console.WriteLine($"Count of distinct elements using Efficient solution: {hashSet.Count}");
        }

        private void FrequenciesOfElements(int[] array)
        {
            // Naive solution
            for (int i = 0; i < array.Length; i++)
            {
                var alreadyProcessed = false;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        alreadyProcessed = true;
                        break;
                    }
                }

                if (alreadyProcessed)
                {
                    continue;
                }
                var count = 1;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                    }
                }

                Console.WriteLine($"Frequency of element {array[i]} with Naive solution is {count} ");
            }

            // Efficient solution
            Hashtable hashTable = new Hashtable();

            for (int i = 0; i < array.Length; i++)
            {
                if (hashTable.ContainsKey(array[i]))
                {
                    hashTable[array[i]] = (int)(hashTable[array[i]]) + 1;
                }
                else
                    hashTable.Add(array[i], 1);
            }

            foreach (var key in hashTable.Keys)
            {
                Console.WriteLine($"Frequency of element {key} with efficient solution is {hashTable[key]} ");
            }

            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (dictionary.ContainsKey(array[i]))
                {
                    dictionary[array[i]] = (int)(dictionary[array[i]]) + 1;
                }
                else
                    dictionary.Add(array[i], 1);
            }

            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine($"Frequency of element {key} with efficient solution using dictionary is {hashTable[key]} ");
            }
        }

        private void IntersectionOfTwoArray() { }
    }

    public class strings
    {
        public void CallPrograms()
        {
            Console.WriteLine("given string is palindrome using Naive:" + this.IsStringPalindromeNaive("GADAG"));
            Console.WriteLine("given string is palindrome using Naive:" + this.IsStringPalindrome("GADAG"));
            Console.WriteLine("given string is squence of string:" + this.IsSubSequenceOfString("test", ""));
            Console.WriteLine("given string is Anagram using Mine:" + this.IsAnagramMine("aaacb", "cabaa"));
            Console.WriteLine("given string is Anagram using Naive:" + this.IsAnagramNaive("aaacb", "cabaa"));
            Console.WriteLine("given string is Anagram using efficient:" + this.IsAnagram("aaacb", "cabaa"));
            Console.WriteLine("Find left most repeating character in a given string using naive:" + this.LeftMostRepeatingCharNaive("abdb"));
            Console.WriteLine("Find left most repeating character in a given string using better approach:" + this.LeftMostRepeatingCharBetter("abdb"));
            Console.WriteLine("Find left most repeating character in a given string using efficient approach 1:" + this.LeftMostRepeatingCharEfficient1("abd"));
            Console.WriteLine("Find left most repeating character in a given string using efficient approach 2:" + this.LeftMostRepeatingCharEfficient2("abda"));

            Console.WriteLine("Find left most non repeating character in a given string using naive:" + this.LeftMostNonRepeatingCharNaive("abdb"));
            Console.WriteLine("Find left most non repeating character in a given string using better approach:" + this.LeftMostNonRepeatingCharBetter("abdb"));
            Console.WriteLine("Find left most non repeating character in a given string using efficient approach 1:" + this.LeftMostNonRepeatingCharEfficient("abd"));

            this.ReverseWordsInString("welcome to school"); // school to welcome
        }

        private bool IsStringPalindromeNaive(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            string str2 = new string(chars);

            if (str == str2)
                return true;
            return false;
        }
        private bool IsStringPalindrome(string str)
        {
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Subsequence of a string, means those characters should be present in the given string and sequence should be correct order.
        /// EX: All subsequence of "ABC" is "","A","B","C","AB","AC","BC","ABC".
        /// </summary>
        private bool IsSubSequenceOfString(string str1, string str2)
        {
            // Naive solution, generate all subsets of 2 pow n using the binary, if matches the binary return true
            // efficient: by comparing both strings char by char with same sequence we will be able to achive it.
            int j = 0;
            if (str1.Length < str2.Length)
                return false;
            for (int i = 0; i < str1.Length && j < str2.Length; i++)
            {
                if (str1[i] == str2[j])
                    j++;
            }

            return j == str2.Length;
        }

        /// <summary>
        /// Annagram means, the characters and count of chars should match in both the strings.
        /// Ex: "listen" "silent" => Yes, "aaacb" "cabaa" => Yes, "aab" "bab" => No
        /// </summary>
        private bool IsAnagramMine(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                bool isFound = false;
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        s2 = s2.Remove(j, 1);
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Annagram means, the characters and count of chars should match in both the strings.
        /// sort both the arrays and compare the characters
        /// </summary>
        private bool IsAnagramNaive(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            char[] chars1 = s1.ToCharArray();
            Array.Sort(chars1);
            s1 = new string(chars1);
            char[] chars2 = s2.ToCharArray();
            Array.Sort(chars2);
            s2 = new string(chars2);

            return s1.Equals(s2);
        }

        /// <summary>
        /// Annagram means, the characters and count of chars should match in both the strings.
        /// For efficient solution, we use standard counting technique. we use characters as indexes in count array with array size of 256 bits.0(n)
        /// </summary>
        private bool IsAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            int[] count = new int[256];
            for (int i = 0; i < s1.Length; i++)
            {
                // increase count of char.
                count[s1[i]]++;
                // descrease count of char.
                count[s2[i]]--;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] != 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Find the left most character which is repeating in the string.0(n2)
        /// </summary>
        private int LeftMostRepeatingCharNaive(string s1)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = i + 1; j < s1.Length; j++)
                {
                    if (s1[i] == s1[j])
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Find the left most character which is repeating in the string
        /// </summary>
        private int LeftMostRepeatingChar(string s1)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = i + 1; j < s1.Length; j++)
                {
                    if (s1[i] == s1[j])
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Better approach
        /// </summary>
        private int LeftMostRepeatingCharBetter(string s1)
        {
            int[] count = new int[256];
            for (int i = 0; i < s1.Length; i++)
            {
                count[s1[i]]++;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (count[s1[i]] > 1)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// efficient approach 1: initilize count array to -1. use char as index to store the value and identify the min values.
        /// </summary>
        private int LeftMostRepeatingCharEfficient1(string s1)
        {
            int[] count = new int[256];
            int res = int.MaxValue;
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = -1;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                var val = count[s1[i]];
                if (val == -1)
                    count[s1[i]] = i;
                else
                    res = Math.Min(res, val);
            }

            return res == int.MaxValue ? -1 : res;
        }

        /// <summary>
        /// efficient approach 1: use boolean arry and loop from right to left. if the value is already visited then update the result else mark it as visited.
        /// </summary>
        private int LeftMostRepeatingCharEfficient2(string s1)
        {
            bool[] visited = new bool[256];
            int res = -1;

            for (int i = s1.Length - 1; i >= 0; i--)
            {
                if (visited[s1[i]])
                    res = i;
                else
                    visited[s1[i]] = true;
            }

            return res;
        }

        /// <summary>
        /// Find the left most character which is repeating in the string
        /// </summary>
        private int LeftMostNonRepeatingCharNaive(string s1)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                bool flag = false;
                for (int j = i + 1; j < s1.Length; j++)
                {
                    if (s1[i] == s1[j])
                    {
                        flag = true;
                    }
                }

                if (!flag)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Better approach
        /// </summary>
        private int LeftMostNonRepeatingCharBetter(string s1)
        {
            int[] count = new int[256];
            for (int i = 0; i < s1.Length; i++)
            {
                count[s1[i]]++;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (count[s1[i]] == 1)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// efficient approach 1: initilize count array to -1. use char as index to store the value and identify the min values. extra is to identify the repeated values for those setting -2
        /// </summary>
        private int LeftMostNonRepeatingCharEfficient(string s1)
        {
            int[] count = new int[256];
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = -1;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                var val = count[s1[i]];
                if (val == -1)
                    count[s1[i]] = i;
                else
                    count[s1[i]] = -2;
            }
            int res = int.MaxValue;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] >= 0)
                    res = Math.Min(res, count[i]);
            }

            return res == int.MaxValue ? -1 : res;
        }

        /// <summary>
        /// Naive solution is to use the stack to reverse the order of the given string
        /// Efficient approach: reverse each words and then reverse the whole array.
        /// </summary>
        private void ReverseWordsInString(string s1)
        {
            var start = 0;
            for (int end = 0; end < s1.Length; end++)
            {
                if (s1[end] == ' ')
                {
                    Reverse(s1.ToCharArray(), start, end - 1);
                    start = end + 1;
                }
            }

            Reverse(s1.ToCharArray(), start, s1.Length - 1);
            Reverse(s1.ToCharArray(), 0, s1.Length - 1);

            Console.WriteLine("The reverse of a given string is : " + s1.ToString());
        }

        private void Reverse(char[] s, int start, int end)
        {
            while (start <= end) { }
            {
                var endVal = s[end];
                s[end] = s[start];
                s[start] = endVal;

                start++;
                end--;
            }
        }

        /// <summary>
        /// Pattern searching.
        /// Search a pattern in agiven string.
        /// Naive when repeated chars: 0((n-m+1)*m)
        /// Navive when all distinct 0(n).
        /// </summary>
        private void PatternSearchingNaive(string text, string pattern)
        {
            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                int j;
                for (j = 0; j < pattern.Length; j++)
                {
                    if (text[i] != pattern[i + j])
                        break;
                }

                if (j == pattern.Length)
                    Console.WriteLine("Pattern searchin with Naive " + i + "\n");
            }
        }

        /// <summary>
        /// Pattern searching.
        /// Search a pattern in agiven string.
        ///  0((n-m+1)*m), but better than naive. It creates a hash and if that is matching then only goes for char by char comparision.
        /// </summary>
        private void ReverseWordsInStringRabinKarp(string text, string pattern)
        {

        }

        /// <summary>
        /// Pattern searching.
        /// KMP algorithm.
        /// 0(N)
        /// </summary>
        private void ReverseWordsInStringKMP(string text, string pattern)
        {

        }

        /// <summary>
        /// Pattern searching.
        /// Search a pattern in agiven string.
        /// 0(m)
        /// </summary>
        private void ReverseWordsInStringSuffixTrue(string text, string pattern)
        {

        }

    }
}
