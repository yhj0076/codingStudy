using System;
using System.Collections.Generic;

public class Starter
{
    public static int n, m;
    public static int[] parent;
    public static int[] roadCount;
    public static Queue<(int,int)> queue = new Queue<(int, int)>();
    public static Queue<(int,int)> leftQueue = new Queue<(int, int)>();

    public static void Main(string[] args)
    {
        // 입력
        string[] input = Console.ReadLine().Split();
        n = int.Parse(input[0]);
        m = int.Parse(input[1]);

        parent = new int[n];
        roadCount = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            string str = Console.ReadLine();
            for (int j = i; j < n; j++)
            {
                if (str[j] == 'Y')
                {
                    queue.Enqueue((i,j));
                }
            }
            parent[i] = i;
        }

        if (n == 1)
        {
            Console.WriteLine("0");
            return;
        }
        
        int usedRoads = 0;
        
        while (queue.Count > 0)
        {
            var element = queue.Dequeue();
            int x = element.Item1;
            int y = element.Item2;
            if (Union(x, y))
            {
                roadCount[x]++;
                roadCount[y]++;
                m--;
                usedRoads++;
            }
            else
            {
                leftQueue.Enqueue((x,y));
            }
        }

        if (usedRoads != n - 1)
        {
            Console.WriteLine("-1");
            return;
        }

        while (m > 0)
        {
            if (leftQueue.Count > 0)
            {
                var element = leftQueue.Dequeue();
                roadCount[element.Item1]++;
                roadCount[element.Item2]++;
                m--;
            }
            else
            {
                Console.WriteLine("-1");
                return;
            }
        }

        if (m > 0)
        {
            Console.WriteLine("-1");
            return;
        }

        int root = Find(0);
        for (int i = 1; i < n; i++)
        {
            if (Find(i) != root)
            {
                Console.WriteLine("-1");
                return;
            }
        }
        
        Console.WriteLine(string.Join(" ",roadCount));
    }

    public static int Find(int x)
    {
        if(parent[x] != x)
            parent[x] = Find(parent[x]);
        return parent[x];
    }

    public static bool Union(int x, int y)
    {
        x = Find(x);
        y = Find(y);
        if (x < y)
        {
            parent[y] = x;
            return true;
        }
        if (x > y)
        {
            parent[x] = y;
            return true;
        }
        return false;
    }
}
