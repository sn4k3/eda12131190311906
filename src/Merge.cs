/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */
namespace eda12131190311906
{
    /// <summary>
    /// Merge Sort Algorithm
    /// http://en.wikipedia.org/wiki/Mergesort
    /// </summary>
    public sealed class Merge {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        /// <param name="p">Start index</param>
        /// <param name="q">Middle index</param>
        /// <param name="r">Right index</param>
        public static void Sort(int[] A, int p, int q, int r)
        {
            int n1 = q - p;
            int n2 = r - q + 1;
            int[] L = new int[n1+1];
            int[] R = new int[n2+1];
            int i, j;
            for(i = 0; i < n1; i++)
            {
                L[i] = A[p + i];
            }

            for(j = 0; j < n2; j++)
            {
                R[j] = A[q + j];
            }

            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;
            j = i = 0;
		
            for(int k = p; k <= r; k++)
            {
                if(L[i] <= R[j])
                {
                    A[k] = L[i];
                    i++;
                }
                else
                {
                    A[k] = R[j];
                    j++;
                }
            }
        }

        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A)
        {
            Sort(A, 0, (A.Length-1) / 2, A.Length-1);
        }

    }
}
