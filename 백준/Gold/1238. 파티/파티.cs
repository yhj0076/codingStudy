public class Starter
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);
        int X = int.Parse(input[2]);

        int[,] graph = new int[N+1,N+1];
        
        for (int i = 0; i < M; i++)
        {
            input = Console.ReadLine().Split();
            
            int from = int.Parse(input[0]);
            int to = int.Parse(input[1]);
            int cost = int.Parse(input[2]);
            
            graph[from,to] = cost;
        }
        
        int[] startX = new int[N+1];
        int[] endX = new int[N+1];
        
        for (int i = 1; i <= N; i++)
        {
            if (i != X)
            {
                startX[i] = int.MaxValue;
                endX[i] = int.MaxValue;
            }
        }
        
        // [(거리, 노드), 거리]
        PriorityQueue<(int, int), int> pQ = new PriorityQueue<(int, int), int>();
        pQ.Enqueue((0,X),0);
        bool[] visited = new bool[N+1];
        while (pQ.Count > 0)
        {
            (int distance, int node) element = pQ.Dequeue();
            visited[element.node] = true;
            for (int i = 1; i <= N; i++)
            {
                if (graph[element.node, i] > 0 && !visited[i])
                {
                    startX[i] = Math.Min(startX[i], element.distance + graph[element.node, i]);
                    pQ.Enqueue((startX[i], i), startX[i]);
                }
            }
        }
        
        pQ.Enqueue((0,X),0);
        visited = new bool[N+1];
        while (pQ.Count > 0)
        {
            (int distance, int node) element = pQ.Dequeue();
            visited[element.node] = true;
            for (int i = 1; i <= N; i++)
            {
                if (graph[i, element.node] > 0 && !visited[i])
                {
                    endX[i] = Math.Min(endX[i], element.distance + graph[i, element.node]);
                    pQ.Enqueue((endX[i], i), endX[i]);
                }
            }
        }

        int answer = 0;
        for (int i = 1; i <= N; i++)
        {
            answer = Math.Max(answer, startX[i] + endX[i]);
        }

        Console.WriteLine(answer);
    }
}