/**
 * Insertion Sort Algorithm
 * http://en.wikipedia.org/wiki/Insertion_sort
 */

/**
 * @author Tiago Concei��o N� 11903
 * @author Gon�alo Lampreia N� 11906
 */
public class Insertion {
	/**
	 * Sort array
	 * @param A Array
	 */
	public static void sort(int A[])
	{
		for(int j = 0; j < A.length; j++)
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
