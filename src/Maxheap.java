/**
 * @author Tiago Conceição
 * @author Gonçalo Lampreia
 */
public class Maxheap {
	int heapsize = 0;
	int[]A;
	
	public Maxheap(int[] A) {
		this.A = A;
		this.heapsize = A.length-1;
	}
	
	public int left(int i)
	{
		return i * 2 + 1;
	}
	
	public int right(int i)
	{
		return this.left(i)+1;
	}
	
	public int parent(int i) {
		return (int) Math.floor((i-1)/2.0);
	}
	
	public void maxHeapify(int i){
		final int l = this.left(i);
		final int r = this.right(i);
		int largest = 0;
		
		if(l < this.heapsize && this.A[l] > this.A[i]){
			largest = l;
		}
		else{
			largest = i;
		}
		
		if(r < this.heapsize && this.A[r] > this.A[largest]){
			largest = r;
		}
		
		if(largest != i){
			final int temp = this.A[i];
			A[i] = A[largest];
			A[largest] = temp;
			maxHeapify(largest);
		}
	}
	
	public void maxHeapifyEx(int i){
		int largest = i;
		
		while(true)
		{
			final int l = this.left(i);
			final int r = this.right(i);
			
			if(l < this.heapsize && this.A[l] > this.A[i]){
				largest = l;
			}
			else{
				largest = i;
			}
			
			if(r < this.heapsize && this.A[r] > this.A[largest]){
				largest = r;
			}
			
			if(largest == i){
				break;
			}
			
			final int temp = this.A[i];
			A[i] = A[largest];
			A[largest] = temp;
			i = largest;
		}
	}
	
	public void buildMaxHeap()
	{
		this.heapsize = this.A.length-1;
		for(int i = (int)Math.floor((A.length-1)/2); i >= 0; i--){
			maxHeapify(i);
	    }
	}
	
	public void sort() {
	    this.buildMaxHeap();
	    for(int i = this.A.length - 1; i >= 1; i--){
		  final int temp = this.A[i];
		  this.A[i] = this.A[0];
		  this.A[0] = temp;
		  this.heapsize--;
		  this.maxHeapify(0);
	    }
	}
	
	@Override
	public String toString() {
		String s = "";
		//int ct = 0;
		for(int x: this.A){  
	      s += " " + x;
	      //ct++;
	    }
		return s += "\n";
	}
	
}
