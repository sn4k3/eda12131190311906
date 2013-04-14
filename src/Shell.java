/**
 * Shell Sort Algorithm
 * http://en.wikipedia.org/wiki/Shell_sort
 */

/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Shell {
	public static void sort(int[] A) {
	    int n = A.length;
	    int h = n / 2;
	    int c, j;
	    while (h > 0) 
	    {
	        for (int i = h; i < n; i++) 
	        {
	            c = A[i];
	            j = i;
	            while (j >= h && A[j - h] > c) {
	                A[j] = A[j - h];
	                j = j - h;
	            }
	            A[j] = c;
	        }
	        h = h / 2;
	    }
	}
}
