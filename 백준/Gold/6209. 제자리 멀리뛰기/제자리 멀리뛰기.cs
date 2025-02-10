public class Starter
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int d = int.Parse(input[0]);  // 탈출구까지의 거리
        int n = int.Parse(input[1]);    // 돌섬 수
        int m = int.Parse(input[2]);    // 최대 제거 가능 돌섬 수

        int[] islands = new int[n+1];
        for (int i = 1; i <= n; i++)
        {
            int island = int.Parse(Console.ReadLine());
            islands[i] = island;
        }
        Array.Sort(islands);

        int head = 0;
        int rear = d;
        int answer = -1;
        
        // Console.WriteLine();

        while (head <= rear)
        {
            int mid = (head + rear) / 2;
            // Console.WriteLine("mid vaule : " + mid);
            int noVisitedIsland = 0;
            int currentPos = 0;
            for (int i = 1; i <= n; i++)
            {
                if (mid <= islands[i] - islands[currentPos])
                {
                    currentPos = i;
                }
                else
                {
                    // Console.WriteLine("visit failure : " + islands[i]);
                    noVisitedIsland++;
                }
            }

            if (noVisitedIsland > m)
            {
                rear = mid-1;
            }
            else
            {
                answer = mid;
                head = mid + 1;
            }

            // Console.WriteLine();
        }

        Console.WriteLine(answer);
    }
}