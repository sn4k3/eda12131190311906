/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Bubble {
	/**
	 * Sort array
	 * @param A Array
	 */
	public static void sort(int A[])
	{
		for(int i = 0; i < A.length; i++)
		{
			for(int j = A.length-1; j >= i + 1; j--)
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
