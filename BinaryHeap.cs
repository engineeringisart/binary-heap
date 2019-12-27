using System;

namespace BinaryHeap
{
    // This is a min-heap.
    class BinaryHeap
    {
        private int[] heap { get; set; }
        private int size { get; set; }

        public BinaryHeap(int maximumSize)
        {
            heap = new int[maximumSize + 1];
            size = 0;
        }

        public int FindMin()
        {
            return heap[1];
        }

        public void Insert(int value)
        {
            if (size == heap.Length - 1)
            {
                DoubleMaximumSize();
            }

            size++;
            int cursor = size;

            // Percolate up
            while (cursor > 1 && value < heap[cursor / 2])
            {
                heap[cursor] = heap[cursor / 2];
                cursor = cursor / 2;
            }
            heap[cursor] = value;
        }

        // Pick the "last" value in the heap, and try to insert it at the root.
        // Continually compare against child nodes whether the new value is valid at the given position,
        // otherwise copy the child value up and run the comparison until satisfied.
        public void DeleteMin()
        {
            int key = heap[size];
            heap[1] = 0; // Just a symbolic deletion
            heap[size] = 0; // Just a symbolic deletion
            size--;

            // Percolate down
            int cursor = 1;
            while (cursor * 2 <= size) // while children exist to make comparisons
            {
                int child = cursor * 2;

                // If there are children in bounds and the right is smaller
                if (child != size && heap[child] > heap[child + 1])
                {
                    child++;
                }
                // If the key is still too large, continue percolating down
                if (key > heap[child])
                {
                    heap[cursor] = heap[child];
                }
                else
                {
                    break;
                }
                cursor = child;
            }

            heap[cursor] = key;
        }

        private void DoubleMaximumSize()
        {
            int newSize = heap.Length * 2;
            int[] newHeap = new int[newSize];
            Array.Copy(heap, newHeap, heap.Length);
            heap = newHeap;
        }
    }
}