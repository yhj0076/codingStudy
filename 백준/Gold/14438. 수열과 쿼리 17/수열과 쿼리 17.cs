using System.Text;

public class Starter
{
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        
        int treeSize = 1;

        while (treeSize < N)
        {
            treeSize <<= 1;
        }
        
        int[] tree = new int[treeSize*2];

        string[] input = Console.ReadLine().Split();
        
        int maxValue = int.MinValue;
        
        for (int i = 0; i < N; i++)
        {
            int index = i + treeSize;
            while (index > 0)
            {
                int innerValue = tree[index];
                int targetValue = int.Parse(input[i]);
                tree[index] = Math.Min(innerValue, targetValue) > 0 ? Math.Min(innerValue, targetValue) : targetValue;
                maxValue = Math.Max(maxValue, tree[index]);
                index /= 2;
            }
        }

        treeSize--;
        
        int M = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < M; i++)
        {
            input = Console.ReadLine().Split();
            if (input[0] == "1")
            {
                // input[1]을 input[2]로 바꾼다.
                int index = int.Parse(input[1]) + treeSize;
                int targetValue = int.Parse(input[2]);
                tree[index] = targetValue;
                index /= 2;
                while (index > 0)
                {
                    tree[index] = Math.Min(tree[index*2], tree[index*2+1]) > 0 ? Math.Min(tree[index*2], tree[index*2+1]) : Math.Max(tree[index*2], tree[index*2+1]);
                    index /= 2;
                }
            }
            else if(input[0] == "2")
            {
                // input[1]부터 input[2] 중 크기가 가장 작은 값을 출력한다.
                int left = int.Parse(input[1]) + treeSize;
                int right = int.Parse(input[2]) + treeSize;
                int min = maxValue;
                while (left <= right)
                {
                    if (left % 2 == 1)
                    {
                        min = Math.Min(min, tree[left]);
                        left++;
                    }
                    left /= 2;

                    if (right % 2 == 0)
                    {
                        min = Math.Min(min, tree[right]);
                        right--;
                    }
                    right /= 2;
                }
                sb.Append($"{min}\n");
            }
        }

        Console.WriteLine(sb.ToString().TrimEnd());
    }
}