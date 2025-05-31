public class TralaleroTralala
{
    public static int[,] _field;
    public static int[,] _newField;
    public static int N, Q, size;
    public static int[] L;
    public static bool[,] _visited;

    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        N = int.Parse(input[0]);
        Q = int.Parse(input[1]);

        size = 1 << N;
        _field = new int[size, size];
        _newField = new int[size, size];
        _visited = new bool[size, size];

        for (int i = 0; i < size; i++)
        {
            input = Console.ReadLine().Split();
            for (int j = 0; j < size; j++)
            {
                _field[i, j] = int.Parse(input[j]);
            }
        }

        L = Console.ReadLine().Split().Select(int.Parse).ToArray();

        foreach (int l in L)
        {
            int len = 1 << l;

            // 1. 회전
            for (int i = 0; i < size; i += len)
            {
                for (int j = 0; j < size; j += len)
                {
                    Rotate(i, j, len);
                }
            }

            // 복사 후 회전 결과 적용
            Array.Copy(_newField, _field, _field.Length);

            // 2. 얼음 녹이기
            MeltIce();

            // 복사 후 얼음 녹은 결과 적용
            Array.Copy(_newField, _field, _field.Length);
        }

        // 총 얼음 양 출력
        Console.WriteLine(_field.Cast<int>().Sum());

        // 최대 얼음 덩어리 크기 출력
        int maxSize = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (!_visited[i, j] && _field[i, j] > 0)
                {
                    maxSize = Math.Max(maxSize, BFS(i, j));
                }
            }
        }

        Console.WriteLine(maxSize);
    }

    public static void Rotate(int sx, int sy, int len)
    {
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                _newField[sx + j, sy + len - 1 - i] = _field[sx + i, sy + j];
            }
        }
    }

    public static void MeltIce()
    {
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                int cnt = 0;
                for (int d = 0; d < 4; d++)
                {
                    int ni = i + dx[d];
                    int nj = j + dy[d];

                    if (ni >= 0 && ni < size && nj >= 0 && nj < size && _field[ni, nj] > 0)
                        cnt++;
                }

                if (_field[i, j] > 0 && cnt < 3)
                    _newField[i, j] = _field[i, j] - 1;
                else
                    _newField[i, j] = _field[i, j];
            }
        }
    }

    public static int BFS(int x, int y)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((x, y));
        _visited[x, y] = true;

        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };
        int count = 1;

        while (queue.Count > 0)
        {
            var (cx, cy) = queue.Dequeue();

            for (int d = 0; d < 4; d++)
            {
                int nx = cx + dx[d];
                int ny = cy + dy[d];

                if (nx < 0 || nx >= size || ny < 0 || ny >= size) continue;
                if (_visited[nx, ny] || _field[nx, ny] <= 0) continue;

                queue.Enqueue((nx, ny));
                _visited[nx, ny] = true;
                count++;
            }
        }

        return count;
    }
}