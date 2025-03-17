using System.Text;

public class Starter
{
    class Node
    {
        public int Inaccuracy { get; set; }
        public int Moved { get; set; }
        public string Puzzle { get; set; }
        public int ZeroIndex { get; set; }

        public int Value()
        {
            return Moved + Inaccuracy;
        }
    }

    public static void Main(string[] args)
    {
        StringBuilder Target = new StringBuilder("123456780");
        
        Dictionary<char, int> targetDict = new Dictionary<char, int>();
        // [element, index]

        for (int i = 0; i < Target.Length; i++)
        {
            targetDict.Add(Target[i], i);
        }

        StringBuilder puzzle = new StringBuilder();
        int inaccuracy = 0;
        int zeroIndex = 0;
        for (int i = 0; i < 3; i++)
        {
            string[] input = Console.ReadLine().Split();
            for (int j = 0; j < 3; j++)
            {
                puzzle.Append(input[j]);
                if (input[j] == "0")
                {
                    zeroIndex = i * 3 + j;
                }

                if (input[j][0] != Target[i*3 + j])
                {
                    inaccuracy++;
                }
            }
        }

        #region 가능성 체크

        // checkPossible이 짝수면 가능
        int checkPossible = 0;
        for (int i = 0; i < 9; i++)
        {
            if(puzzle[i] == '0')
                continue;
            for (int j = 0; j < i; j++)
            {
                if (puzzle[j] != '0' && puzzle[j] > puzzle[i])
                {
                    checkPossible++;
                }
            }
        }
        if (checkPossible % 2 != 0)
        {
            Console.WriteLine("-1");
            return;
        }
        
        #endregion

        Node start = new Node
        {
            Moved = 0,
            Puzzle = puzzle.ToString(),
            ZeroIndex = zeroIndex,
            Inaccuracy = inaccuracy
        };
        
        PriorityQueue<Node, int> queue = new PriorityQueue<Node, int>();
        HashSet<string> visited = new HashSet<string>();
        queue.Enqueue(start, start.Value());
        visited.Add(start.Puzzle);
        
        int[] moveOffsets = new int[4] { -3, 3, -1, 1 };    // 상, 하, 좌, 우
        int[] rowCheck = new int[4] { 0, 0, -1, 1 } ;
        
        
        Node current = null;
        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            // Console.WriteLine($"Moved : {current.Moved}");
            // Console.WriteLine($"[{current.Puzzle[0]}, {current.Puzzle[1]}, {current.Puzzle[2]}]\n" +
            //                   $"[{current.Puzzle[3]}, {current.Puzzle[4]}, {current.Puzzle[5]}]\n" +
            //                   $"[{current.Puzzle[6]}, {current.Puzzle[7]}, {current.Puzzle[8]}]");
            // Console.WriteLine($"Inaccuracy : {current.Inaccuracy}, Value: {current.Value()}");
            if (Target.ToString() == current.Puzzle)
            {
                break;
            }

            foreach (var offset in moveOffsets)
            {
                int nextIndex = current.ZeroIndex + offset;
                
                // 범위 체크
                // 좌우 이동 시에는 같은 행에 있는 건지 체크
                if (nextIndex < 0 || nextIndex >= 9 || (offset == -1 && current.ZeroIndex % 3 == 0) || (offset == 1 && current.ZeroIndex % 3 == 2))
                {
                    continue;
                }
                
                StringBuilder newPuzzle = new StringBuilder(current.Puzzle);
                (newPuzzle[current.ZeroIndex], newPuzzle[nextIndex]) = (newPuzzle[nextIndex], newPuzzle[current.ZeroIndex]);
                
                if(visited.Contains(newPuzzle.ToString()))
                    continue;

                int newInaccuracy = current.Inaccuracy;
                char changed = newPuzzle[current.ZeroIndex];
                if (changed != '0')
                {
                    if (targetDict[changed] == current.ZeroIndex)
                    {
                        newInaccuracy--;
                    }
                    if (targetDict[changed] == nextIndex)
                    {
                        newInaccuracy++;
                    }
                }


                Node next = new Node
                {
                    Moved = current.Moved + 1,
                    Puzzle = newPuzzle.ToString(),
                    ZeroIndex = nextIndex,
                    Inaccuracy = newInaccuracy
                };
                
                queue.Enqueue(next, next.Value());
                visited.Add(newPuzzle.ToString());
            }
            // Console.ReadLine();
        }

        Console.WriteLine($"{current.Moved}");
    }
}
