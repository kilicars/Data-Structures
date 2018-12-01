    public class MinIntHeap
    {
        private readonly int capacity;
        private int size;
        private readonly int[] items;

        public int Size { get => size; set => size = value; }

        public MinIntHeap(int capacity)
        {
            this.capacity = capacity;
            Size = 0;
            items = new int[capacity];
        }
        private int GetLeftChildIndex(int index) => index * 2 + 1;
        private int GetRightChildIndex(int index) => index * 2 + 2;
        private int GetParentIndex(int index) => (index - 1) / 2;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < Size;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < Size;
        private bool HasParent(int index) => GetParentIndex(index) >= 0;
        private int LeftChild(int index) => items[GetLeftChildIndex(index)];
        private int RightChild(int index) => items[GetRightChildIndex(index)];
        private int Parent(int index) => items[GetParentIndex(index)];
        private void Swap(int index1, int index2)
        {
            int temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
        public int Peek()
        {
            if (Size == 0)
            {
                throw new Exception("No elemnts in the heap!");
            }
            return items[0];
        }
        public int Poll()
        {
            int item = Peek();
            items[0] = items[Size - 1];
            HeapifyDown();
            Size--;
            return item;
        }
        public void Add(int item)
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
            while (HasParent(index) && Parent(index) > items[index])
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
                if (HasRightChild(index) && LeftChild(index) > RightChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                if (items[smallerChildIndex] > items[index])
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
