using _01.Queue;

MyQueue myQueue = new MyQueue();

myQueue.Enqueue(1);
myQueue.Enqueue(2);
myQueue.Enqueue(3);
myQueue.Enqueue(4);
myQueue.Enqueue(5);

int number = myQueue.Dequeue();

myQueue.Enqueue(1);