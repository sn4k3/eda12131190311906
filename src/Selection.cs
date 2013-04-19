/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */
namespace eda12131190311906
{
    /// <summary>
    /// Selection Sort Algorithm
    /// http://en.wikipedia.org/wiki/Selection_sort
    /// </summary>
    public sealed class Selection {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int minElementIndex = i;
                int minElementValue = A[i];
                for (int j = i + 1; j < A.Length; j++) 
                {
                    if (A[j] < minElementValue)
                    {
                        minElementIndex = j;
                        minElementValue = A[j];
                    }
                }
                A[minElementIndex] = A[i];
                A[i] = minElementValue;
            }
        }
    }
}
