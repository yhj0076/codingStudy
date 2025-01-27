public class Starter
{
    public static int n;
    public static int m;
    public static int[,] floyd;
    public static int[] parent;
    public static int[] rank;

    public static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());

        floyd = new int[n + 1, n + 1];
        parent = new int[n + 1];
        rank = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
            rank[i] = 1;
            for (int j = 1; j <= n; j++)
            {
                floyd[i, j] = (i == j) ? 0 : 100;
            }
        }

        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine().Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);

            floyd[x, y] = floyd[y, x] = 1;
            union_parent(x, y);
        }

        // Floyd-Warshall for shortest paths
        for (int k = 1; k <= n; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    floyd[i, j] = Math.Min(floyd[i, j], floyd[i, k] + floyd[k, j]);
                }
            }
        }

        // Group representatives and calculate captains
        int[] roots = parent.Select(find_parent).Distinct().ToArray();
        List<int> captains = new List<int>();

        foreach (var root in roots)
        {
            int minMaxDistance = int.MaxValue;
            int captain = -1;

            for (int i = 1; i <= n; i++)
            {
                if (find_parent(i) == root)
                {
                    int maxDistance = 0;
                    for (int j = 1; j <= n; j++)
                    {
                        if (floyd[i, j] < 100)
                        {
                            maxDistance = Math.Max(maxDistance, floyd[i, j]);
                        }
                    }

                    if (maxDistance < minMaxDistance)
                    {
                        minMaxDistance = maxDistance;
                        captain = i;
                    }
                }
            }

            if (captain != -1)
            {
                captains.Add(captain);
            }
        }

        captains.Sort();
        Console.WriteLine(captains.Count);
        Console.WriteLine(string.Join("\n", captains));
    }

    static public int find_parent(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = find_parent(parent[x]); // Path compression
        }
        return parent[x];
    }

    static public void union_parent(int a, int b)
    {
        a = find_parent(a);
        b = find_parent(b);

        if (a != b)
        {
            if (rank[a] > rank[b])
            {
                parent[b] = a;
            }
            else if (rank[a] < rank[b])
            {
                parent[a] = b;
            }
            else
            {
                parent[b] = a;
                rank[a]++;
            }
        }
    }
}
