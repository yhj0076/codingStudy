public class Starter
{
    public static void Main(string[] args)
    {
        int pizzaSize = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split();
        int m = int.Parse(input[0]);    // A 피자 크기
        int n = int.Parse(input[1]);    // B 피자 크기

        int[] A = new int[m];
        int[] B = new int[n];
        Dictionary<int, int> pizzaA = new Dictionary<int, int>();
        Dictionary<int, int> pizzaB = new Dictionary<int, int>();
        pizzaA.Add(0, 1);
        pizzaB.Add(0, 1);
        InputPiece(m, A, pizzaA, pizzaSize);
        InputPiece(n, B, pizzaB, pizzaSize);

        InputMultiPiece(A, m, pizzaSize, pizzaA);
        InputMultiPiece(B, n, pizzaSize, pizzaB);

        int answer = 0;
        
        foreach (var pieceA in pizzaA)
        {
            int pieceSizeA = pieceA.Key;
            int target = pizzaSize - pieceSizeA;

            if (pizzaB.ContainsKey(target))
            {
                answer += pieceA.Value * pizzaB[target];
            }
        }
        
        Console.WriteLine(answer);
    }
    public static void InputMultiPiece(int[] thePizza, int pieceCount, int pizzaSize, Dictionary<int, int> pizzaDict)
    {
        for (int i = 0; i < thePizza.Length; i++)
        {
            int head = thePizza[i];
            int j = i+1;
            j %= pieceCount;
            while (j != i)
            {
                int tail = thePizza[j];
                if (head + tail <= pizzaSize)
                {
                    head += tail;
                    if (pizzaDict.ContainsKey(head))
                    {
                        if ((j + 1) % pieceCount != i)
                        {
                            pizzaDict[head]++;
                        }
                    }
                    else
                    {
                        pizzaDict.Add(head, 1);
                    }
                }
                else
                {
                    break;
                }
                j++;
                j %= pieceCount;
            }
        }
    }
    public static void InputPiece(int pieceCount, int[] thePizza, Dictionary<int, int> pizzaDict,int pizzaSize)
    {
        for (int i = 0; i < pieceCount; i++)
        {
            int thePiece = int.Parse(Console.ReadLine());
            thePizza[i] = thePiece;
            if (thePiece <= pizzaSize)
            {
                if (!pizzaDict.ContainsKey(thePiece))
                {
                    pizzaDict.Add(thePiece, 1);
                }
                else
                {
                    pizzaDict[thePiece]++;
                }
            }
        }
    }
}