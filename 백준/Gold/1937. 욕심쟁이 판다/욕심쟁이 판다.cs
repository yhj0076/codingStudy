public class Starter
{
    public static Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();
    public static Dictionary<int, int> memo = new Dictionary<int, int>(); // DFS 결과 캐싱 (메모이제이션)
    
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[,] data = new int[n, n];
        int[,] graph = new int[n, n];
        bool[] isChild = new bool[n * n]; // 부모 여부 확인 (true면 자식)

        int index = 0;
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                data[i, j] = int.Parse(input[j]);
                graph[i, j] = index;
                dict[index] = new HashSet<int>(); // 미리 초기화
                index++;
            }
        }

        int[] xAdd = new int[] { -1, 1, 0, 0 };
        int[] yAdd = new int[] { 0, 0, 1, -1 };

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int head = data[i, j];
                int nodeIndex = graph[i, j];

                for (int k = 0; k < 4; k++)
                {
                    int newX = i + xAdd[k];
                    int newY = j + yAdd[k];

                    if (newX >= 0 && newX < n && newY >= 0 && newY < n)
                    {
                        int leaf = data[newX, newY];
                        int leafIndex = graph[newX, newY];

                        if (leaf > head)
                        {
                            dict[nodeIndex].Add(leafIndex);
                            isChild[leafIndex] = true; // 자식 노드 표시
                        }
                    }
                }
            }
        }

        int answer = 0;

        // 루트 노드 찾기 (부모가 없는 노드)
        for (int i = 0; i < n * n; i++)
        {
            if (!isChild[i]) // 부모가 없는 노드부터 시작
            {
                int maxValue = DFS(i);
                if (answer < maxValue)
                {
                    answer = maxValue;
                }
            }
        }

        Console.WriteLine(answer);
    }

    public static int DFS(int current)
    {
        if (memo.ContainsKey(current)) return memo[current]; // 캐싱된 값 반환

        int maxDepth = 1; // 현재 노드를 포함한 깊이

        foreach (var leaf in dict[current])
        {
            maxDepth = Math.Max(maxDepth, 1 + DFS(leaf));
        }

        memo[current] = maxDepth; // 결과 저장
        return maxDepth;
    }
}
