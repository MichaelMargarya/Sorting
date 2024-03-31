using System;

namespace Sorting
{
    internal class Sort
    {
        public Sort()
        {
            try
            {
                Console.WriteLine("Enter Array Length");
                if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
                    throw new ArgumentException("Invalid array length.");

                int[] userArray = new int[length];
                Console.WriteLine("Enter Array items");
                for (int i = 0; i < userArray.Length; i++)
                {
                    if (!int.TryParse(Console.ReadLine(), out int resurse))
                        throw new ArgumentException("Invalid array item.");
                    userArray[i] = resurse;
                }

                Console.WriteLine("Enter Sort: 1 - Merge Sort, 2 - Bubble Sort, 3 - Insertion Sort, 4 - Quick Sort");
                if (!int.TryParse(Console.ReadLine(), out int userInp) || userInp < 1 || userInp > 4)
                    throw new ArgumentException("Invalid sorting option.");

                switch (userInp)
                {
                    case 1:
                        DisplaySortedArray(MergeSort(userArray));
                        break;
                    case 2:
                        DisplaySortedArray(BubbleSort(userArray));
                        break;
                    case 3:
                        DisplaySortedArray(InsertionSort(userArray));
                        break;
                    case 4:
                        DisplaySortedArray(QuickSort(userArray, 0, userArray.Length - 1));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void DisplaySortedArray(int[] sortedArray)
        {
            Console.WriteLine("Sorted Array:");
            foreach (int a in sortedArray)
            {
                Console.Write(a + "\t");
            }
        }

        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return arr;

            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                }
                resultIndex++;
            }

            while (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                leftIndex++;
                resultIndex++;
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                rightIndex++;
                resultIndex++;
            }

            return result;
        }

        public static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        public static int[] InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int right = arr[i];
                int left = i - 1;

                while (left >= 0 && arr[left] > right)
                {
                    arr[left + 1] = arr[left];
                    left--;
                }

                arr[left + 1] = right;
            }

            return arr;
        }

        public static int[] QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int p = Partition(arr, low, high);
                QuickSort(arr, low, p - 1);
                QuickSort(arr, p + 1, high);
            }
            return arr;
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }
    }
}
