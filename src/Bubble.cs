/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Concei��o N� 11903
 * Gon�alo Lampreia N� 11906
 * https://code.google.com/p/eda12131190311906/
 */
namespace eda12131190311906
{
    /// <summary>
    /// Bubble Sort Algorithm
    /// http://en.wikipedia.org/wiki/Bubblesort
    /// </summary>
    public sealed class Bubble {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A)
        {
            for(int i = 0; i < A.Length; i++)
            {
                for(int j = A.Length-1; j >= i + 1; j--)
                {
                    if(A[j] < A[j -1])
                    {
                        int key = A[j];
                        A[j] = A[j - 1];
                        A[j - 1] = key;
                    }
                }
            }
        }
    }
}
