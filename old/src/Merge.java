/**
 * Merge Sort Algorithm
 * http://en.wikipedia.org/wiki/Mergesort
 */

/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Merge {
	/**
	 * Sort array
	 * @param A Array
	 * @param p Start index
	 * @param q Middle index
	 * @param r End index
	 */
	public static void sort(int[] A, int p, int q, int r)
	{
		int n1 = q - p;
		int n2 = r - q + 1;
		int L[] = new int[n1+1];
		int R[] = new int[n2+1];
		
		for(int i = 0; i < n1; i++)
		{
			L[i] = A[p + i];
		}

		for(int j = 0; j < n2; j++)
		{
			R[j] = A[q + j];
		}

		L[n1] = Integer.MAX_VALUE;
		R[n2] = Integer.MAX_VALUE;
		int i = 0, j = 0;
		
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
	
	/**
	 * Sort array
	 * @param A Array
	 */
	public static void sort(int[] A)
	{
		Merge.sort(A, 0, (int)((A.length-1) / 2), A.length-1);
	}

}
