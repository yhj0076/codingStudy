public class Starter
{
    public static int _R;
    public static int _C;
    public static int _T;
    public static int[,] _Map;
    public static int[,] _NewMap;
    public static Queue<(int,int)> queue = new Queue<(int,int)>();
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        _R = int.Parse(input[0]);
        _C = int.Parse(input[1]);
        _T = int.Parse(input[2]);
        _Map = new int[_R, _C];
        _NewMap = new int[_R, _C];
        (int, int) purificator1 = (-1,-1);
        (int, int) purificator2 = (-1,-1);
        
        for (int r = 0; r < _R; r++)
        {
            input = Console.ReadLine().Split();
            for (int c = 0; c < _C; c++)
            {
                _Map[r, c] = int.Parse(input[c]);
                if(_Map[r,c] == -1)
                    if(purificator1.Item1 == -1)
                        purificator1 = (r, c);
                    else
                        purificator2 = (r, c);
            }
        }

        for (int t = 0; t < _T; t++)
        {
            for (int r = 0; r < _R; r++)
            {
                for (int c = 0; c < _C; c++)
                {
                    if (_Map[r, c] > 0)
                    {
                        Nanodust(r,c);
                        _NewMap[r,c] += _Map[r,c];
                    }
                }
            }
            
            _Map = _NewMap.Clone() as int[,];
            _NewMap = new int[_R, _C];
            Purification(purificator1.Item1,purificator2.Item1);
        }

        int answer = 0;
        for (int r = 0; r < _R; r++)
        {
            for (int c = 0; c < _C; c++)
            {
                if(_Map[r,c] > 0)
                    answer += _Map[r,c];
            }
        }
        
        Console.WriteLine(answer);
    }

    public static int[] dx = new int[] {0,1,0,-1};
    public static int[] dy = new int[] {1,0,-1,0};
    public static void Nanodust(int x, int y)
    {
        int spreadDust = _Map[x, y]/5;

        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];
            if(newX < 0 || newX >= _R || newY < 0 || newY >= _C)
                continue;
            if(_Map[newX, newY] == -1)
                continue;
            if(_Map[newX, newY] == 0)
                queue.Enqueue((newX, newY));
            _NewMap[newX, newY] += spreadDust;
            _Map[x, y] -= spreadDust;
        }
    }

    public static void Purification(int x1, int x2)     // x1 < x2
    {
        for (int i = x2 + 1; i < _R - 1; i++)
        {
            _Map[i, 0] = _Map[i+1, 0];
        }

        for (int i = x1 - 1; i > 0; i--)
        {
            _Map[i, 0] = _Map[i-1, 0];
        }

        for (int i = 0; i < _C - 1; i++)
        {
            _Map[0, i] = _Map[0, i+1];
            _Map[_R - 1, i] = _Map[_R - 1, i+1];
        }

        for (int i = _R - 1; i > x2; i--)
        {
            _Map[i, _C - 1] = _Map[i - 1, _C - 1];
        }

        for (int i = 0; i < x1; i++)
        {
            _Map[i, _C - 1] = _Map[i + 1, _C - 1];
        }

        for (int i = _C - 1; i > 0; i--)
        {
            _Map[x1, i] = _Map[x1, i - 1];
            _Map[x2, i] = _Map[x2, i - 1];
        }

        _Map[x1, 1] = 0;
        _Map[x2, 1] = 0;
        _Map[x2, 0] = 0;
        _Map[x1, 0] = 0;
    }
}