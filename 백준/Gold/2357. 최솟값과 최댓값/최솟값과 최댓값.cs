using System.Text;

public class Starter
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);

        int size = 1;
        while (size < N)
        {
            size <<= 1;
        }
        (long,long)[] tree = new (long, long)[2*size];
        size--;

        for (int i = 1; i <= N; i++)
        {
            long num = int.Parse(Console.ReadLine());
            (long, long) vaule = (num, num);
            int index = i + size;
            while (index > 0)
            {
                var innerVaule = tree[index];
                long minVaule = Math.Min(innerVaule.Item1, num) == 0 ? 
                    Math.Max(innerVaule.Item1, num) : Math.Min(innerVaule.Item1, num);
                long maxVaule = Math.Max(innerVaule.Item2, num);
                tree[index] = (minVaule,maxVaule);
                index /= 2;
            }
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < M; i++)
        {
            input = Console.ReadLine().Split();
            int left = int.Parse(input[0]) + size;
            int right = int.Parse(input[1]) + size;
            
            (long, long) value = (0, 0);
            while (left <= right)
            {
                if (left % 2 == 1)
                {
                    long minValue = Math.Min(tree[left].Item1,value.Item1) == 0 ? 
                        Math.Max(tree[left].Item1,value.Item1) : Math.Min(tree[left].Item1,value.Item1);
                    long maxValue = Math.Max(tree[left].Item2, value.Item2);
                    value = (minValue, maxValue);
                    left++;
                }
                left /= 2;

                if (right % 2 == 0)
                {
                    long minValue = Math.Min(tree[right].Item1,value.Item1) == 0 ? 
                        Math.Max(tree[right].Item1,value.Item1) : Math.Min(tree[right].Item1,value.Item1);
                    long maxValue = Math.Max(tree[right].Item2, value.Item2);
                    value = (minValue, maxValue);
                    right--;
                }
                right /= 2;
            }
            
            sb.Append(value.Item1+" "+value.Item2+"\n");
        }

        Console.WriteLine(sb.ToString());
    }
}