/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */

using System;

namespace eda12131190311906
{
    /// <summary>
    /// Quick Sort Algorithm
    /// http://en.wikipedia.org/wiki/Quicksort
    /// </summary>
    public sealed class Quick {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        /// <param name="p">Start index</param>
        /// <param name="r">End index</param>
        public static void Sort(int[] A, int p, int r)
        {
            //TailRecursiveSort(A, p, r);
            //return;
            if (p >= r) return;

            int q = Partition(A, p, r);
            Sort(A, p, q - 1);
            Sort(A, q + 1, r);
        }

        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A)
        {
            Sort(A, 0, A.Length-1);
        }

        /// <summary>
        /// Partition
        /// </summary>
        /// <param name="A">Array to sort</param>
        /// <param name="p">Start index</param>
        /// <param name="r">End index</param>
        /// <returns>Number of randomized partitions</returns>
        private static int Partition(int[] A, int p, int r) {
            int x = A[r];
            int i = p - 1;
            int temp;
            for(int j = p; j < r; j++)
            {
                if(A[j] <= x)
                {
                    i++;
                    temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }
            }
            i++;
            temp = A[i];
            A[i] = A[r];
            A[r] = temp;
            return i;
        }

        /// <summary>
        /// Randomized sort
        /// </summary>
        /// <param name="A">Array to sort</param>
        /// <param name="p">Start index</param>
        /// <param name="r">End index</param>
        public static void RandomizedSort(int[] A, int p, int r)
        {
            if (p >= r) return;
            int q = RandomizedPartition(A, p, r);
            RandomizedSort(A, p, q - 1);
            RandomizedSort(A, q + 1, r);
        }

        /// <summary>
        /// Randomized sort
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void RandomizedSort(int[] A)
        {
            RandomizedSort(A, 0, A.Length-1);
        }
	
        /// <summary>
        /// Partition
        /// </summary>
        /// <param name="A">Array to sort</param>
        /// <param name="p">Start index</param>
        /// <param name="r">End index</param>
        /// <returns>Number of randomized partitions</returns>
        private static int RandomizedPartition(int[] A, int p, int r)
        {
            int i = new Random().Next(r - p) + p;
            int temp = A[i];
            A[i] = A[r];
            A[r] = temp;
            return Partition(A, p, r);
        }

        /// <summary>
        /// Tail recursive sort
        /// </summary>
        /// <param name="A">Array to sort</param>
        /// <param name="p">Start index</param>
        /// <param name="r">End index</param>
        public static void TailRecursiveSort(int[] A, int p, int r)
        {
            while (p < r)
            {
                // Particionar e ordenar a tabela da esquerda
                int q = Partition(A, p, r);
                TailRecursiveSort(A, p, q - 1);
                p = q + 1;
            }
        }

        /// <summary>
        /// Tail recursive sort
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void TailRecursiveSort(int[] A)
        {
            TailRecursiveSort(A, 0, A.Length-1);
        }
	
    }
}
