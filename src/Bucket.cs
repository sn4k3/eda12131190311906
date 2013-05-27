/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceicao N 11903
 * Goncalo Lampreia N 11906
 * https://code.google.com/p/eda12131190311906/
 */

using System;
using System.Windows.Forms;

namespace eda12131190311906
{
    /// <summary>
    /// Bucket Sort Algorithm
    /// http://en.wikipedia.org/wiki/Bucket_sort
    /// </summary>
    public sealed class Bucket
    {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A) 
        {
            int max = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                }
            }
            int[] count = new int[max + 1];
            for (int i = 0; i < A.Length; i++)
            {
                count[A[i]]++;
            }

            for (int i = 0, j = 0; i < count.Length; i++)
            {
                for (; count[i] > 0; (count[i])--)
                {
                    A[j] = i;
                    j++;
                }
            }
        }
    }
}
