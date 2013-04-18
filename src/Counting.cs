/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
namespace eda12131190311906
{
    /// <summary>
    /// Counting Sort Algorithm
    /// http://en.wikipedia.org/wiki/Counting_sort
    /// </summary>
    public sealed class Counting {
        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A) 
        {
            int max = A[0], min = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                }
                else if (A[i] < min)
                {
                    min = A[i];
                }
            }
            int numValues = max - min + 1;
            int[] counts = new int[numValues];
            for (int i = 0; i < A.Length; i++)
            {
                counts[A[i]-min]++;
            }
            int outputPos = 0;
            for (int i = 0; i < numValues; i++)
            {
                for (int j = 0; j < counts[i]; j++)
                {
                    A[outputPos] = i+min;
                    outputPos++;
                }
            }
        }
    }
}
