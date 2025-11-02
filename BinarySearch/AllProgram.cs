using System;
using System.Collections;
using System.Collections.Generic;

namespace AllPrograms
{
    public class Programs
    {
        public void CallPrograms()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            int bs = new BinarySearch().Search(arr, 6);
            Console.WriteLine("result:{0}", bs);


            // Recurssion
            Recurssion recurssion = new Recurssion();
            Console.WriteLine("Factorical of Num is : {0}", recurssion.FactoricalOfNum(4));
            Console.WriteLine("Is Palindrome : {0}", recurssion.IsPalindrome("GADAG", 0, 4));
            Console.WriteLine("Sum of Digits : {0}", recurssion.SumOfDigits(124594));
            Console.WriteLine("Max rope counts : {0}", recurssion.MaxRopeCut(9, 2, 2, 2));
            recurssion.GenerateSubSet("ABC");
            recurssion.TowerOfHonoi(2, 'a', 'b', 'c');
            Console.WriteLine("Servier in the circule : {0}", recurssion.JoshephusProblem(7, 3));
            Console.WriteLine("Count of subset of number : {0}", recurssion.CountSumOfSubSet(new int[] { 10, 5, 2, 3, 6 }, 8, 5));

            // remove duplicates
            removeDuplicates();

            // Hashing
            new Hashing().CallPrograms();
        }

        public void removeDuplicates()
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
}
