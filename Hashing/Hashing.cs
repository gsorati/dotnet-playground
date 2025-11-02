using System.Collections;

namespace Hash
{
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