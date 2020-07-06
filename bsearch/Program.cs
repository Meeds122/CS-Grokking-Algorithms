using System;

namespace bsearch
{
    class Program
    {
        static (bool, int, int) binarySearch(int[] values, int to_search)
        {
            /* (bool, int) binarySearch(int[] values, int to_search)
             * Input: 
             *     int[] values - A sorted integer array of values to search through
             *     int to_search - An integer to go find in the array
             * Output:
             *     (bool, int, int)
             *     item1: bool - was item found
             *     item2: int - number of jumps to find
             *     item3: int - position of item if found. -1 if not found
            */
            bool found = false;
            int jumps = 0;
            int position = -1;
            
            // Algorithm goes here
            int low_bound = 0;
            int high_bound = values.Length;
            int mid_value;
            while (low_bound <= high_bound)
            {
                jumps++;
                mid_value = (high_bound + low_bound) / 2;
                if (values[mid_value] == to_search)
                {
                    found = true;
                    position = mid_value;
                    break;
                }
                else if (values[mid_value] < to_search)
                {
                    low_bound = mid_value + 1;
                }
                else if (values[mid_value] > to_search)
                {
                    high_bound = mid_value - 1;
                }
            }
            return (found, jumps, position);
        }
        static void Main(string[] args)
        {
            // Get size of task
            Console.Write("Number of randoms: ");
            int number_of_randoms = Int32.Parse(Console.ReadLine());

            // Generate random numbers
            var random = new Random();
            int[] values = new int[number_of_randoms];
            for(int i = 0; i < number_of_randoms; i++)
            {
                values[i] = random.Next(0, number_of_randoms*2);
            }
            
            // Sort numbers
            Console.WriteLine("Unsorted array: ");
            printArray(values);
            Array.Sort(values);
            Console.WriteLine("Sorted array: ");
            printArray(values);
            
            // Get digit to search for
            Console.Write("Digit to search for: ");
            int search_for = Int32.Parse(Console.ReadLine());

            // Search for digit
            var results = binarySearch(values, search_for);

            // Print results
            if (results.Item1 == true)
            {
                Console.WriteLine($"The item was found in the array with {results.Item2} loops at location {results.Item3}");
            }
            else
            {
                Console.WriteLine($"The item was not found in the array after {results.Item2} loops");
            }
        }
        static void printArray(int[] values)
        {
            /* printArray(int[] values)
             * Input:
             *     int[] values - An array of integers to print out
             * Output:
             *     none
            */
            for(int i = 0; i < values.Length; i++)
            {
                Console.Write($"{values[i]} ");
            }
            Console.WriteLine();
        }
    }
}
