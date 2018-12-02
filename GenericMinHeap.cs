    public class GenericMinHeap<T> where T : IComparable<T>
    {
        private readonly int capacity;
        private int size;
        private readonly T[] items;

        public int Size { get => size; set => size = value; }

        public GenericMinHeap(int capacity)
        {
            this.capacity = capacity;
            Size = 0;
            items = new T[capacity];
        }
        private int GetLeftChildIndex(int index) => index * 2 + 1;
        private int GetRightChildIndex(int index) => index * 2 + 2;
        private int GetParentIndex(int index) => (index - 1) / 2;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < Size;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < Size;
        private bool HasParent(int index) => GetParentIndex(index) >= 0;
        private T LeftChild(int index) => items[GetLeftChildIndex(index)];
        private T RightChild(int index) => items[GetRightChildIndex(index)];
        private T Parent(int index) => items[GetParentIndex(index)];
        private void Swap(int index1, int index2)
        {
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
        public T Peek()
        {
            if (Size == 0)
            {
                throw new Exception("No elements in the heap!");
            }
            return items[0];
        }
        public T Poll()
        {
            T item = Peek();
            items[0] = items[Size - 1];
            HeapifyDown();
            Size--;
            return item;
        }
        public void Add(T item)
        {
            Size++;
            if (Size > capacity)
            {
                throw new Exception("Heap over capacity!");
            }
            items[Size - 1] = item;
            HeapifyUp();
        }
        private void HeapifyUp()
        {
            int index = Size - 1;
            while (HasParent(index) && Parent(index).CompareTo(items[index]) > 0)
            {
                int parentIndex = GetParentIndex(index);
                Swap(index, parentIndex);
                index = parentIndex;
            }
        }
        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && LeftChild(index).CompareTo(RightChild(index)) > 0)
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                if (items[smallerChildIndex].CompareTo(items[index]) > 0)
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }

                index = smallerChildIndex;
            }
        }
    }  
