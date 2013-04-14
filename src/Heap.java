/**
 * Heap Sort Algorithm
 * http://en.wikipedia.org/wiki/Heapsort
 */

/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Heap {
	/**
	 * Heapsize
	 */
	private static int heapsize = 0;
	
	/**
	 * Calculate left 
	 * @param i
	 * @return Left
	 */
	private static int left(int i)
	{
		return i * 2 + 1;
	}
	
	/**
	 * Calculate right
	 * @param i 
	 * @return Right
	 */
	private static int right(int i)
	{
		return Heap.left(i)+1;
	}
	
	/**
	 * Calculate parent
	 * @param i
	 * @return Parent
	 */
	private static int parent(int i) {
		return (int) Math.floor((i-1)/2.0);
	}
	
	/**
	 * Max heapify
	 * @param A Array
	 * @param i index
	 */
	private static void maxHeapify(int A[], int i){
		final int l = Heap.left(i);
		final int r = Heap.right(i);
		int largest = 0;
		
		if(l < Heap.heapsize && A[l] > A[i]){
			largest = l;
		}
		else{
			largest = i;
		}
		
		if(r < Heap.heapsize && A[r] > A[largest]){
			largest = r;
		}
		
		if(largest != i){
			final int key = A[i];
			A[i] = A[largest];
			A[largest] = key;
			Heap.maxHeapify(A, largest);
		}
	}
	
	/**
	 * Max heapify, non recursive method
	 * @param A Array
	 * @param i index
	 */
	private static void maxHeapifyEx(int A[], int i){
		int largest = i;
		
		while(true)
		{
			final int l = Heap.left(i);
			final int r = Heap.right(i);
			
			if(l < Heap.heapsize && A[l] > A[i]){
				largest = l;
			}
			else{
				largest = i;
			}
			
			if(r < Heap.heapsize && A[r] > A[largest]){
				largest = r;
			}
			
			if(largest == i){
				break;
			}
			
			final int temp = A[i];
			A[i] = A[largest];
			A[largest] = temp;
			i = largest;
		}
	}
	
	/**
	 * Build max heap
	 * @param A Array
	 */
	private static void buildMaxHeap(int A[])
	{
		Heap.heapsize = A.length-1;
		for(int i = (int)Math.floor((A.length-1)/2); i >= 0; i--){
			Heap.maxHeapify(A, i);
	    }
	}
	
	/**
	 * Sort array
	 * @param A Array
	 */
	public static void sort(int A[]) {
	    Heap.buildMaxHeap(A);
	    Heap.heapsize = A.length-1;
	    for(int i = A.length - 1; i >= 1; i--){
		  final int key = A[i];
		  A[i] = A[0];
		  A[0] = key;
		  Heap.heapsize--;
		  Heap.maxHeapify(A, 0);
	    }
	}	
}
