/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceicao N 11903
 * Goncalo Lampreia N 11906
 * https://code.google.com/p/eda12131190311906/
 */
namespace eda12131190311906
{
    /// <summary>
    /// Shell Sort Algorithm
    /// http://en.wikipedia.org/wiki/Shell_sort
    /// </summary>
    public sealed class Shell
    {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A) {
            int n = A.Length;
            int h = n / 2;
            int c, j;
            while (h > 0) 
            {
                for (int i = h; i < n; i++) 
                {
                    c = A[i];
                    j = i;
                    while (j >= h && A[j - h] > c) {
                        A[j] = A[j - h];
                        j = j - h;
                    }
                    A[j] = c;
                }
                h = h / 2;
            }
        }
    }
}
