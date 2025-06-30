public class Starter
{
    public static int _N;
    public static int _M;
    public static int[] parent;
    
    public static void Main(string[] args)
    {
        int caseCount = 0;
        while (true)
        {
            caseCount++;
            string[] input = Console.ReadLine().Split();
            _N = int.Parse(input[0]);
            _M = int.Parse(input[1]);

            if (_N == 0)
            {
                if (_M == 0)
                    return;
                Console.WriteLine($"Case {caseCount}: No trees.");
                continue;
            }
            
            parent = new int[_N+1];
            bool[] isCircle = new bool[_N+1];
            for (int i = 1; i <= _N; i++)
            {
                parent[i] = i;
            }
            
            for (int i = 1; i <= _M; i++)
            {
                input = Console.ReadLine().Split();
                int from = int.Parse(input[0]);
                int to = int.Parse(input[1]);
                
                Union(isCircle,from,to);
            }
            
            bool[] isExist = new bool[_N+1];
            int count = 0;
            for (int i = 1; i <= _N; i++)
            {
                CheckCircle(isCircle,i);
            }
            for (int i = 1; i <= _N; i++)
            {
                if (!isCircle[Find(i)])
                {
                    if(!isExist[Find(i)])
                        count++;
                    isExist[Find(i)] = true;
                }
            }

            if (count == 0)
            {
                Console.WriteLine($"Case {caseCount}: No trees.");
            }
            else if (count == 1)
            {
                Console.WriteLine($"Case {caseCount}: There is one tree.");
            }
            else
            {
                Console.WriteLine($"Case {caseCount}: A forest of {count} trees.");
            }
        }
    }
    public static void CheckCircle(bool[] circle, int x)
    {
        if(circle[x])
            circle[parent[x]] = true;
    }
    
    public static int Find(int x)
    {
        if (parent[x] == x)
            return x;
        return parent[x] = Find(parent[x]);
    }

    public static void Union(bool[] circle, int x, int y)
    {
        x = Find(x);
        y = Find(y);

        if (x == y)
        {
            circle[x] = true;

            return;
        }
        
        if(parent[x] < parent[y])
            parent[x] = y;
        else
            parent[y] = x;
    }
}