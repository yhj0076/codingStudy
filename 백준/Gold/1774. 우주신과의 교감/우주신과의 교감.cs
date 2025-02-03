public class Starter
{
    public class Position
    {
        public Position(long x, long y)
        {
            this.x = x;
            this.y = y;
        }

        public long x { get; set; }
        public long y { get; set; }
    }
    public class Edge
    {
        public Edge(int from, int to)
        {
            this.From = ufos[from];
            this.To = ufos[to];
            this.FromIndex = from;
            this.ToIndex = to;
            this.cost = Pythagorean(From,To);
        }

        public Edge(int from, int to, double cost)
        {
            this.From = ufos[from];
            this.To = ufos[to];
            this.FromIndex = from;
            this.ToIndex = to;
            this.cost = cost;
        }

        public double cost { get; set; }
        public Position From { get; set; }
        public Position To { get; set; }
        public int FromIndex { get; set; }
        public int ToIndex { get; set; }
    }
    public static Dictionary<int, Position> ufos = new Dictionary<int, Position>();
    public static int[] parents = new int[10000];
    
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);
        
        for (int i = 0; i < parents.Length; i++)
        {
            parents[i] = i;
        }
        
        PriorityQueue<Edge,double> pQ = new PriorityQueue<Edge, double>();

        for (int i = 1; i <= N; i++)
        {
            input = Console.ReadLine().Split();
            long x = long.Parse(input[0]);
            long y = long.Parse(input[1]);
            Position pos = new Position(x, y);
            ufos.Add(i, pos);
        }
        
        bool[,] visited = new bool[N+1,N+1];
        
        for (int i = 0; i < M; i++)
        {
            input = Console.ReadLine().Split();
            int from = int.Parse(input[0]);
            int to = int.Parse(input[1]);
            
            Edge e = new Edge(from, to, 0);
            visited[from,to] = true;
            visited[to,from] = true;
            pQ.Enqueue(e,0);
            // 이미 연결된 간선들 추가하기
        }
        
        // 모든 요소를 돌아보며 간선들을 우선순위큐에 넣는다.
        foreach (var ufo in ufos)
        {
            Position current = ufo.Value;
            foreach (var nearUfo in ufos)
            {
                Position near = nearUfo.Value;
                if (current != near && !visited[ufo.Key,nearUfo.Key])
                {
                    visited[ufo.Key,nearUfo.Key] = true;
                    visited[nearUfo.Key,ufo.Key] = true;
                    Edge distance = new Edge(ufo.Key, nearUfo.Key);
                    pQ.Enqueue(distance,distance.cost);
                }
            }
        }
        
        double answer = 0d;
        
        while (pQ.Count > 0)
        {
            Edge smallestEdge = pQ.Dequeue();
            int fromIndex = smallestEdge.FromIndex;
            int toIndex = smallestEdge.ToIndex;

            int fromParent = Find(fromIndex);
            int toParent = Find(toIndex);
            if (fromParent != toParent)
            {
                answer += smallestEdge.cost;
                Union(fromIndex, toIndex);
            }
        }
        
        Console.WriteLine(answer.ToString("F2"));
    }
    
    public static int Find(int x)
    {
        if (parents[x] != x)
        {
            parents[x] = Find(parents[x]);
        }

        return parents[x];
    }

    public static void Union(int a, int b)
    {
        a = Find(a);
        b = Find(b);
        if (a < b)
        {
            parents[b] = a;
        }
        else
        {
            parents[a] = b;
        }
    }
    
    public static double Pythagorean(Position a, Position b)
    {
        double dx = a.x - b.x;
        double dy = a.y - b.y;

        double value = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        // Console.WriteLine(" a(" + a.x + "," + a.y + ") = " + 
        //                   "\n b(" + b.x + "," + b.y + ") = " +
        //                   "\n distance : " + value);
        return value;
    }
}