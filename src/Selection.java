/**
 * Selection Sort Algorithm
 * http://en.wikipedia.org/wiki/Selection_sort
 */

/**
 * @author Tiago Concei��o N� 11903
 * @author Gon�alo Lampreia N� 11906
 */
public class Selection {
	/**
	 * Sort array
	 * @param A Array
	 */
	public static void sort(int[] A)
    {
        for (int i = 0; i < A.length; i++)
        {
        	int minElementIndex = i;
        	int minElementValue = A[i];
		    for (int j = i + 1; j < A.length; j++) 
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
