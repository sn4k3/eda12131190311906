/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceicao N 11903
 * Goncalo Lampreia N 11906
 * https://code.google.com/p/eda12131190311906/
 */
namespace eda12131190311906
{
    /// <summary>
    /// Comb Sort Algorithm
    /// http://en.wikipedia.org/wiki/Comb_sort
    /// </summary>
    public sealed class Comb {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A)
        {
            int gap = A.Length;
            bool swapped = false;

            while ((gap > 1) || swapped)
            {
                if (gap > 1)
                {
                    gap = (int) (gap / 1.247330950103979);
                }

                swapped = false;

                for (int i = 0; gap + i < A.Length; ++i)
                {
                    if (A[i] - A[i + gap] > 0)
                    {
                        int key = A[i];
                        A[i] = A[i + gap];
                        A[i + gap] = key;
                        swapped = true;
                    }
                }
            }
        }
    }
}
