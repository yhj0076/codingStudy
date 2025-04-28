public class Starter
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        
        int[] circle = new int[n];
        for (int i = 0; i < n; i++)
        {
            circle[i] = i + 1;
        }

        int pointer = n - 1;
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                do
                {
                    pointer = (pointer + 1) % n;
                } while (circle[pointer] == 0);
            }
            result[i] = circle[pointer];
            circle[pointer] = 0;
        }

        Console.WriteLine($"<{string.Join(", ", result)}>");
    }
}