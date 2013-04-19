/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */
namespace eda12131190311906
{
    /// <summary>
    /// Insertion Sort Algorithm
    /// http://en.wikipedia.org/wiki/Insertion_sort
    /// </summary>
    public sealed class Insertion {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A)
        {
            for(int j = 0; j < A.Length; j++)
            {
                int key = A[j];
                int i = j-1;
                while(i > -1 && A[i] > key)
                {
                    A[i+1] = A[i];
                    i--;
                }
                A[i+1] = key;
            }
        }
    }
}
