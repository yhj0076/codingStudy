using System.Text;

public class Starter
{
    public static int preIndex = 0;
    public static StringBuilder answer = new StringBuilder();

    public static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());
        for (int i = 0; i < T; i++)
        {
            preIndex = 0;
            int n = int.Parse(Console.ReadLine());
            List<string> preOrder = Console.ReadLine().Split().ToList();
            List<string> inOrder = Console.ReadLine().Split().ToList();
            PostOrder(inOrder, preOrder, 0, n - 1);
            answer.Append("\n");
        }
        Console.WriteLine(answer.ToString().TrimEnd());
    }

    public static void PostOrder(List<string> inOrder, List<string> preOrder, int start, int end)
    {
        if (start > end) return;
        
        string current = preOrder[preIndex++];
        int currentIndex = inOrder.IndexOf(current);

        // 왼쪽 서브트리 재귀 호출
        PostOrder(inOrder, preOrder, start, currentIndex - 1);
        // 오른쪽 서브트리 재귀 호출
        PostOrder(inOrder, preOrder, currentIndex + 1, end);

        // 후위 순회 결과 추가
        answer.Append(current).Append(" ");
    }
}