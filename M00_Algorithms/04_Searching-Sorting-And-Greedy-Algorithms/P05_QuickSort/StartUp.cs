namespace P05_QuickSort
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            QuickSort(arr, 0, arr.Length -1);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] && arr[right] < arr[pivot])
                {
                    Swap(arr, left, right);
                }

                if (arr[left] <= arr[pivot])
                {
                    left++;
                }

                if (arr[right] >= arr[pivot])
                {
                    right--;
                }
            }

            Swap(arr, pivot, right);

            QuickSort(arr, start, right - 1);
            QuickSort(arr, right + 1, end);
        }

        private static void QuickSort2(int[] arr, int start, int end)
        {
            int pivot = end;
            int left = start;
            int right = end - 1;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] && arr[right] < arr[pivot])
                {
                    Swap(arr, left, right);
                }

                if (arr[left] <= arr[pivot])
                {
                    left++;
                }

                if (arr[right] >= arr[pivot])
                {
                    right--;
                }

                Swap(arr, pivot, right);
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
