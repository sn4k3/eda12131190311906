/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */

using System;

namespace eda12131190311906
{
    /// <summary>
    /// Heap Sort Algorithm
    /// http://en.wikipedia.org/wiki/Heapsort
    /// </summary>
    public sealed class Heap {
        /// <summary>
        /// Heapsize
        /// </summary>
        private static int _heapsize;

        /// <summary>
        /// Calculate left
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Left</returns>
        private static int Left(int i)
        {
            return i * 2 + 1;
        }

        /// <summary>
        /// Calculate right
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Right</returns>
        private static int Right(int i)
        {
            return Left(i)+1;
        }

        /// <summary>
        /// Calculate parent
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Parent</returns>
        private static int Parent(int i) {
            return (int) Math.Floor((i-1)/2.0);
        }

        /// <summary>
        /// Max heapify, non recursive method
        /// </summary>
        /// <param name="A">Array to sort</param>
        /// <param name="i">index</param>
        private static void MaxHeapify(int[] A, int i){
            int l = Left(i);
            int r = Right(i);
            int largest = 0;
		
            if(l < _heapsize && A[l] > A[i]){
                largest = l;
            }
            else{
                largest = i;
            }
		
            if(r < _heapsize && A[r] > A[largest]){
                largest = r;
            }
		
            if(largest != i){
                int key = A[i];
                A[i] = A[largest];
                A[largest] = key;
                MaxHeapify(A, largest);
            }
        }

        /// <summary>
        /// Max heapify, non recursive method
        /// </summary>
        /// <param name="A">Array to sort</param>
        /// <param name="i">index</param>
        private static void MaxHeapifyEx(int[] A, int i){
            int largest = i;
		
            while(true)
            {
                int l = Left(i);
                int r = Right(i);
			
                if(l < _heapsize && A[l] > A[i]){
                    largest = l;
                }
                else{
                    largest = i;
                }
			
                if(r < _heapsize && A[r] > A[largest]){
                    largest = r;
                }
			
                if(largest == i){
                    break;
                }
			
                int temp = A[i];
                A[i] = A[largest];
                A[largest] = temp;
                i = largest;
            }
        }

        /// <summary>
        /// Build max heap
        /// </summary>
        /// <param name="A">Array to sort</param>
        private static void BuildMaxHeap(int[] A)
        {
            _heapsize = A.Length-1;
            for(var i = (int)Math.Floor(((A.Length-1)/2D)); i >= 0; i--){
                MaxHeapify(A, i);
            }
        }

        /// <summary>
        /// Sort an array
        /// </summary>
        /// <param name="A">Array to sort</param>
        public static void Sort(int[] A) {
            BuildMaxHeap(A);
            _heapsize = A.Length-1;
            for(int i = A.Length - 1; i >= 1; i--){
                int key = A[i];
                A[i] = A[0];
                A[0] = key;
                _heapsize--;
                MaxHeapify(A, 0);
            }
        }	
    }
}
