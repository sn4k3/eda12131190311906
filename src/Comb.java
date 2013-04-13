/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Comb {
	/**
	 * Sort array
	 * @param A Array
	 */
	public static void sort(int[] A)
    {
        int gap = A.length;
        boolean swapped = false;

        while ((gap > 1) || swapped)
        {
            if (gap > 1)
            {
                gap = (int) ((double)gap / 1.247330950103979);
            }

            swapped = false;

            for (int i = 0; gap + i < A.length; ++i)
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
