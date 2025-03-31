public class Starter
{
    public static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        //PriorityQueue<int, int> sortedQueue = new PriorityQueue<int, int>();
        
        for (int i = 0; i < N; i++)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            queue.Enqueue(number, number);
            //sortedQueue.Enqueue(number, number);
        }

        // Console.Write("[");
        // while (sortedQueue.Count > 1)
        // {
        //     Console.Write($"{sortedQueue.Dequeue()}, ");
        // }
        // Console.Write($"{sortedQueue.Dequeue()}]\n");
        
        
        long compareCount = 0;
        while (queue.Count > 1)
        {
            int minValue1 = queue.Dequeue();
            int minValue2 = queue.Dequeue();
            
            int newValue = minValue1 + minValue2;
            compareCount += newValue;
            queue.Enqueue(newValue, newValue);
            //Console.WriteLine($"{minValue1} + {minValue2} = {newValue}");
        }
        Console.WriteLine(compareCount);
    }
}