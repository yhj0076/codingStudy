public class Starter
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split();
        
        List<long> X = new List<long>();
        X.Add(-1000000001L);
        
        foreach (var stringValue in input)
        {
            long value = long.Parse(stringValue);

            if (X[^1] < value)
            {
                X.Add(value);
            }
            else
            {
                int head = 0;
                int tail = X.Count - 1;
                int mid = (head + tail) / 2;
                while (tail - head > 1)
                {
                    mid = (head + tail) / 2;
                    long midVal = X[mid];

                    if (value > midVal)
                    {
                        head = mid;
                    }
                    else
                    {
                        tail = mid;
                    }
                }
                if (value < X[tail])
                {
                    X[tail] = value;
                }
            }
        }
        Console.WriteLine(X.Count-1);
    }
}