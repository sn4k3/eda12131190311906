/**
 * @author Tiago Conceição
 * @author Gonçalo Lampreia
 */
public class Bubble {
	public static void sort(int A[])
	{
		for(int i = 0; i < A.length; i++)
		{
			for(int j = A.length; j >= i + 1; j--)
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
