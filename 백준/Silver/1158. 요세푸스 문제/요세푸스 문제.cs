public class Starter
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        
        List<int> circle = new List<int>();
        for (int i = 0; i < n; i++)
        {
            circle.Add(i + 1);
        }

        int pointer = 0;
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            pointer = (pointer + k - 1) % circle.Count;
            result[i] = circle[pointer];
            circle.RemoveAt(pointer);
        }

        Console.WriteLine($"<{string.Join(", ", result)}>");
    }
}