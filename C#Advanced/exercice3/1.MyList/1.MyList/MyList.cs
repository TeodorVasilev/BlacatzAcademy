namespace _1.MyList
{
    public class MyList
    {
        private int[] numbers;
        private int capacity;
        private int size;

        public MyList(int capacity = 4)
        {
            this.capacity = capacity;
            this.numbers = new int[capacity];
        }

        public int this[int index] 
        {
            get
            {
                return this.numbers[index];
            }
        }

        public int Count { 
            get 
            {
                return this.size;
            } 
        }

        public void Add(int number)
        {
            if(this.size >= this.capacity)
            {
                this.EnlargeList();
            }

            this.numbers[this.size] = number;
            this.size++;
        }

        public void Remove(int number)
        {
            for (int i = 0; i < this.numbers.Length; i++)
            {
                if(this.numbers[i] == number)
                {
                    this.RemoveElementAtIndex(i);
                    break;
                }
            }
        }

        private void RemoveElementAtIndex(int index)
        {
            for (int i = index; i < this.numbers.Length - 1; i++)
            {
                this.numbers[i] = this.numbers[i + 1];
            }

            this.size--;
        }

        private void EnlargeList()
        {
            this.capacity *= 2;
            int[] newArr = new int[this.capacity];
            for (int i = 0; i < this.numbers.Length; i++)
            {
                newArr[i] = this.numbers[i];
            }

            this.numbers = newArr;
        }
    }
}
