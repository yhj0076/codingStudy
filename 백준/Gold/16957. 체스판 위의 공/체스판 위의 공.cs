using System.Text;

public class BallOnChessBoard
{
    public static int R;
    public static int C;
    public static int[,] BallBoard;
    public static int[,] ArrowBoard;
    public static int[,] Board;
    public static (int, int)[,] Memo;
    public static int[] dx  = new int[]{-1, -1, 0, 1, 1, 1, 0, -1};
    public static int[] dy  = new int[]{0, 1, 1, 1, 0, -1, -1, -1};

    // 7 0 1
    // 6 + 2
    // 5 4 3
    
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        R = int.Parse(input[0]);
        C = int.Parse(input[1]);
        Board = new int[R, C];
        ArrowBoard = new int[R, C];
        BallBoard = new int[R, C];
        Memo = new (int, int)[R, C];
        for (int r = 0; r < R; r++)
        {
            input = Console.ReadLine().Split();
            for (int c = 0; c < C; c++)
            {
                Board[r, c] = int.Parse(input[c]);
                Memo[r, c] = (-1, -1);
            }
        }
        
        // 1. 내가 주변보다 가장 작으면 이동을 멈춘다.
        // 2. 그 외에는 가장 작은 정수칸으로 이동한다.

        for (int r = 0; r < R; r++)
        {
            for (int c = 0; c < C; c++)
            {
                Arrow(r,c);
            }
        }

        for (int r = 0; r < R; r++)
        {
            for (int c = 0; c < C; c++)
            {
                var (destX,destY) = InitBall_(r,c);
                BallBoard[destX,destY]++;
            }
        }

        StringBuilder answer = new StringBuilder();
        for (int r = 0; r < R; r++)
        {
            for (int c = 0; c < C; c++)
            {
                answer.Append(BallBoard[r,c]);
                if(c != C - 1) answer.Append(" ");
            }
            answer.Append("\n");
        }

        Console.WriteLine(answer.ToString());
    }
    
    public static (int, int) InitBall_(int r, int c)
    {
        if(Memo[r,c] != (-1, -1))
            return Memo[r, c];

        var arrow = ArrowBoard[r, c];
        if (arrow == -1)
        {
            Memo[r, c] = (r, c);
            return (r, c);
        }
        
        int newR = r + dx[arrow];
        int newC = c + dy[arrow];
        Memo[r, c] = InitBall_(newR, newC);
        return Memo[r, c];
    }
    
    public static void Arrow(int r, int c)
    {
        int min = int.MaxValue;
        int minPos = -1;
        
        int newX;
        int newY;
        for (int i = 0; i < 8; i++)
        {
            newX = r + dx[i];
            newY = c + dy[i];
            if(newX < 0 || newX >= R || newY < 0 || newY >= C)
                continue;
            if (Board[newX, newY] < Board[r, c] && min > Board[newX, newY])
            {
                min = Board[newX, newY];
                minPos = i;
            }
        }
        
        // UnionParent((r, c), minPos);
        ArrowBoard[r, c] = minPos;
    }
}