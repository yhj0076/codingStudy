using System.Text;

namespace codingStudy;

public class Starter
{
    static int[] parent; // 부모 노드 배열
    static int[] size; // 각 집합의 크기
    static StringBuilder answer = new StringBuilder();
    public static void Main(string[] args)
    {
        int testCount = int.Parse(Console.ReadLine());

        for (int t = 0; t < testCount; t++)
        {
            int relationCount = int.Parse(Console.ReadLine());

            // 친구 이름을 인덱스로 매핑하기 위한 Dictionary
            Dictionary<string, int> friends = new Dictionary<string, int>();
            parent = new int[1000000];
            size = new int[1000000];

            int currentIndex = 1; // 친구 인덱스는 1부터 시작

            // 초기화
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
                size[i] = 1;
            }

            for (int r = 0; r < relationCount; r++)
            {
                string[] input = Console.ReadLine().Split();
                string friendA = input[0];
                string friendB = input[1];

                // 친구 A가 없으면 추가
                if (!friends.ContainsKey(friendA))
                {
                    friends[friendA] = currentIndex++;
                }

                // 친구 B가 없으면 추가
                if (!friends.ContainsKey(friendB))
                {
                    friends[friendB] = currentIndex++;
                }

                int indexA = friends[friendA];
                int indexB = friends[friendB];

                // Union-Find 병합
                Union(indexA, indexB);

                // 같은 네트워크 크기를 결과에 추가
                answer.Append(size[Find(indexA)]).Append("\n");
            }
        }

        // 결과 출력
        Console.WriteLine(answer.ToString());
    }
    
    // Find 연산 (경로 압축)
    static public int Find(int x)
    {
        if (x != parent[x])
        {
            parent[x] = Find(parent[x]); // 경로 압축
        }
        return parent[x];
    }

    // Union 연산 (크기 기반 병합)
    static public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX != rootY)
        {
            // 작은 트리를 큰 트리에 연결
            if (size[rootX] < size[rootY])
            {
                parent[rootX] = rootY;
                size[rootY] += size[rootX];
            }
            else
            {
                parent[rootY] = rootX;
                size[rootX] += size[rootY];
            }
        }
    }
}