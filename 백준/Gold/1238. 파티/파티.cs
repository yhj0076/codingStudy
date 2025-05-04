using System;
using System.Collections.Generic;

public class Starter
{
    static int N, M, X;
    static List<(int to, int cost)>[] graph;
    static List<(int to, int cost)>[] reverseGraph;

    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        N = int.Parse(input[0]);
        M = int.Parse(input[1]);
        X = int.Parse(input[2]);

        graph = new List<(int, int)>[N + 1];
        reverseGraph = new List<(int, int)>[N + 1];

        for (int i = 1; i <= N; i++)
        {
            graph[i] = new List<(int, int)>();
            reverseGraph[i] = new List<(int, int)>();
        }

        for (int i = 0; i < M; i++)
        {
            input = Console.ReadLine().Split();
            int from = int.Parse(input[0]);
            int to = int.Parse(input[1]);
            int cost = int.Parse(input[2]);

            graph[from].Add((to, cost));
            reverseGraph[to].Add((from, cost)); // 역방향 저장
        }

        int[] distFromX = Dijkstra(graph, X);
        int[] distToX = Dijkstra(reverseGraph, X);

        int answer = 0;
        for (int i = 1; i <= N; i++)
        {
            answer = Math.Max(answer, distFromX[i] + distToX[i]);
        }

        Console.WriteLine(answer);
    }

    static int[] Dijkstra(List<(int to, int cost)>[] g, int start)
    {
        int[] dist = new int[N + 1];
        Array.Fill(dist, int.MaxValue);
        dist[start] = 0;

        var pq = new PriorityQueue<(int node, int dist), int>();
        pq.Enqueue((start, 0), 0);

        while (pq.Count > 0)
        {
            var (cur, cost) = pq.Dequeue();
            if (cost > dist[cur]) continue;

            foreach (var (next, nextCost) in g[cur])
            {
                if (dist[next] > dist[cur] + nextCost)
                {
                    dist[next] = dist[cur] + nextCost;
                    pq.Enqueue((next, dist[next]), dist[next]);
                }
            }
        }

        return dist;
    }
}