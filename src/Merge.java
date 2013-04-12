import java.util.Arrays;

/**
 * @author Tiago Conceição
 * @author Gonçalo Lampreia
 */

public class Merge {
	public static int[] sort(int[] A, int p, int q, int r)
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
		System.out.println(Arrays.toString(L));
		System.out.println(Arrays.toString(R));
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
		
		return A;
	}

}
