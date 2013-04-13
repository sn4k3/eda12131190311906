/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Counting {
	/**
	 * Sort array
	 * @param A Array
	 */
	public static void sort(int[] A) 
	{
		int max = A[0], min = A[0];
		for (int i = 1; i < A.length; i++)
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
	    for (int i = 0; i < A.length; i++)
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
