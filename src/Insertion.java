
/**
 * @author Tiago Concei��o
 * @author Gon�alo Lampreia
 */
public class Insertion {
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
