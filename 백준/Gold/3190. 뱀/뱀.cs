public class Starter
{
    public static int[,] board;
    public static int N;
    public static List<(int,int)> snake = new List<(int,int)>();
    public static void Main(string[] args)
    {
        N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        
        board = new int[N+1, N+1];
        board[1, 1] = 2;

        for (int i = 0; i < K; i++)
        {
            string[] input = Console.ReadLine().Split();
            board[int.Parse(input[0]), int.Parse(input[1])] = 1;
        }
        
        int L = int.Parse(Console.ReadLine());
        
        snake.Add((1,1));
        int index = 0;
        int timer = 0;
        int[] dX = new int[]{ 0, 1, 0, -1};
        int[] dY = new int[]{1, 0, -1, 0};
        // 시계방향으로 돌아간다. left, down, right, up
        
        for (int i = 0; i < L; i++)
        {
            string[] input = Console.ReadLine().Split();
            int goStraight = int.Parse(input[0]);
            string spinHead = input[1];

            (int x, int y) head = snake.Last();
            
            // 현재 방향으로 goStraight만큼 전진한 후, direction으로 방향을 전환한다.
            while(timer < goStraight)
            {
                timer++;
                head = snake.Last();
                if (GoFoward(head.x + dX[index], head.y + dY[index]) == false)
                {
                    Console.WriteLine(timer);
                    return;
                }
            }

            if (spinHead == "D")
                index++;
            else if (spinHead == "L")
                index--;

            if (index < 0)
                index = 3;
            else if (index == 4)
                index = 0;
        }

        while (true)
        {
            timer++;
            (int x, int y)head = snake.Last();
            if (GoFoward(head.x + dX[index], head.y + dY[index]) == false)
            {
                Console.WriteLine(timer);
                return;
            }
        }
    }
    
    public static bool GoFoward(int i, int j)
    {
        if(i <= 0 || j <= 0 || i > N || j > N)
            return false;

        if (board[i, j] == 2)
            return false;
        
        snake.Add((i,j));
        if (board[i, j] == 0)   // 사과가 없다면
        {
            (int x, int y) tail = snake[0];
            board[tail.x, tail.y] = 0;
            snake.Remove(tail);
        }
        board[i, j] = 2;
        return true;
    }
}