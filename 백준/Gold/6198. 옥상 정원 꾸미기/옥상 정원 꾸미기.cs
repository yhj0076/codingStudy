public class Starter
{
    public static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        long[] buildings = new long[N];
        for (int i = 0; i < N; i++)
        {
            buildings[i] = Convert.ToInt64(Console.ReadLine());
        }

        Stack<int> stack = new Stack<int>();
        long sum = 0;

        for (int i = 0; i < N; i++)
        {
            while (stack.Count > 0 && buildings[i] >= buildings[stack.Peek()])
            {
                int idx = stack.Pop();
                sum += i - idx - 1;
            }
            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            int idx = stack.Pop();
            sum += N - idx - 1;
        }

        Console.WriteLine(sum);
    }
}