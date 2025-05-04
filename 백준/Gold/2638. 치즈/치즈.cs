public class Starter
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);

        int timer = 0;
        
        int[,] cheese = new int[N+2,M+2];
        HashSet<(int x,int y)> cheeseSet = new HashSet<(int,int)>();
        
        for (int i = 1; i <= N; i++)
        {
            input = Console.ReadLine().Split();
            for (int j = 0; j < M; j++)
            {
                cheese[i,j+1] = int.Parse(input[j]);
                if (cheese[i,j+1] == 1)
                {
                    cheeseSet.Add((i,j+1));
                }
            }
        }
        
        bool[,] visited = new bool[N+2,M+2];
        int MaxAir = (N + 2) * (M + 2);
        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
        
        int[] checkX = new int[] { 1, 0, -1, 0 };
        int[] checkY = new int[] { 0, 1, 0, -1 };

        while (MaxAir > 1)
        {
            MaxAir = (N + 2) * (M + 2);
            visited = new bool[N+2,M+2];
            visited[0, 0] = true;
            queue.Enqueue((0, 0));
            while (queue.Count > 0)
            {
                var position = queue.Dequeue();
                cheese[position.x, position.y] = -1;

                for (int i = 0; i < 4; i++)
                {
                    int nextIndexX = position.x + checkX[i];
                    int nextIndexY = position.y + checkY[i];
                    if (nextIndexX < 0 || nextIndexX > N + 1 || nextIndexY < 0 || nextIndexY > M + 1)
                        continue;
                    if ((cheese[nextIndexX, nextIndexY] == 0 || cheese[nextIndexX, nextIndexY] == -1) &&
                        !visited[nextIndexX, nextIndexY])
                    {
                        if (cheese[nextIndexX, nextIndexY] == 0)
                            cheese[nextIndexX, nextIndexY] = -1;
                        queue.Enqueue((nextIndexX, nextIndexY));
                        visited[nextIndexX, nextIndexY] = true;
                        MaxAir--;
                    }
                }
            }

            bool disappearCheese = false;
            foreach (var piece in cheeseSet)
            {
                int nearByAirCount = 0;
                for (int i = 0; i < 4; i++)
                {
                    int nextIndexX = piece.x + checkX[i];
                    int nextIndexY = piece.y + checkY[i];

                    if (cheese[nextIndexX, nextIndexY] == -1)
                        nearByAirCount++;
                }

                if (nearByAirCount >= 2)
                {
                    cheese[piece.x, piece.y] = 0;
                    disappearCheese = true;
                    cheeseSet.Remove(piece);
                }
            }

            if (disappearCheese)
                timer++;
        }

        Console.WriteLine(timer);
    }
}