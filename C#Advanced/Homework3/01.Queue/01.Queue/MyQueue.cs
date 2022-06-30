namespace _01.Queue
{
    public class MyQueue
    {
        private int[] elements = new int[4];
        private int size = 0;

        public int this[int index]
        {
            get
            {
                if(index < 0 || index >= elements.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.elements[index];
            }

            set
            {
                if (index < 0 || index >= elements.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                this.elements[index] = value;
            }
        }

        public void Enqueue(int element)
        {
            if(this.elements.Length == size)
            {
                this.elements = Resize(this.elements);
            }

            this.elements[this.size] = element;
            size++;
        }
        
        public int Dequeue()
        {
            if(this.size == 0)
            {
                throw new InvalidOperationException();
            }

            int element = this.elements[0];

            for (int i = 0; i < this.elements.Length - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.elements[elements.Length - 1] = 0;
            size--;

            return element;
        }

        private int[] Resize(int[] elements)
        {
            int[] resized = new int[elements.Length * 2];

            for(int i = 0; i < elements.Length; i++)
            {
                resized[i] = elements[i];
            }

            return resized;
        }
    }
}
