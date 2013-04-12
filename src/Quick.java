/**
 * 
 */


import java.util.Random;

/**
 * @author Tiago
 *
 */
public class Quick {
	
	public static void sort(int A[], int p, int r)
	{
		if(p < r)
		{
			int q = Quick.partition(A, p, r);
			Quick.sort(A, p, q - 1);
			Quick.sort(A, q + 1, r);
		}
	}

	private static int partition(int[] A, int p, int r) {
		int x = A[r];
		int i = p - 1;
		
		for(int j = p; j < r; j++)
		{
			if(A[j] <= x)
			{
				i++;
				int temp = A[i];
				A[i] = A[j];
				A[j] = temp;
			}
		}
		i++;
		int temp = A[i];
		A[i] = A[r];
		A[r] = temp;
		return i;
	}
	
	public static void randomizedSort(int A[], int p, int r)
	{
		if(p < r)
		{
			int q = Quick.randomizedPartition(A, p, r);
			Quick.randomizedSort(A, p, q - 1);
			Quick.randomizedSort(A, q + 1, r);
		}
	}
	
	private static int randomizedPartition(int A[], int p, int r)
	{
		int i = new Random().nextInt(r - p) + p;
		int temp = A[i];
		A[i] = A[r];
		A[r] = temp;
		return Quick.partition(A, p, r);
	}
	
	public static void tailRecursiveSort(int A[], int p, int r)
	{
		while (p < r)
		{
			// Particionar e ordenar a tabela da esquerda
			int q = Quick.partition(A, p, r);
			Quick.tailRecursiveSort(A, p, q - 1);
			p = q + 1;
		}
	}
	
}
