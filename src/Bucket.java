/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Bucket {
	
	/**
	 * Sort array
	 * @param A Array
	 */
	public static void sort(int[] A) 
	{
		int max = A[0];
		for (int i = 1; i < A.length; i++)
		{
		    if (A[i] > max)
		    {
		        max = A[i];
		    }
		}
	    int[] count = new int[max+1];
	    for(int i = 0; i < A.length; i++ ) 
	    {
	    	count[A[i]]++;
	    }
	    
	    for(int i=0,j=0; i < count.length; i++) 
	    {
	    	for(; count[i] > 0; (count[i])--)
	    	{
	    		A[j] = i;
	    		j++;
	    	}
	    }
	}
}
