public class Starter
{
    public class Item
    {
        public int InDegree {get;set; } = 0;    // 진입 차수
        public List<string> Edges {get; } = new List<string>(); // 연결된 노드들

        public void AddEdge(string e)
        {
            Edges.Add(e);
        }
    }
    
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        
        // 그래프 생성
        Dictionary<string, Item> dict = new Dictionary<string, Item>();
        
        // 간선 입력
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            string firstItem = input[0];
            string lastItem = input[1];

            if (!dict.ContainsKey(firstItem))
            {
                dict.Add(firstItem, new Item());
            }

            if (!dict.ContainsKey(lastItem))
            {
                dict.Add(lastItem, new Item());
            }
            
            dict[firstItem].AddEdge(lastItem);
            dict[lastItem].InDegree++;
        }
        
        // 우선순위 큐
        PriorityQueue<string, string> priorityQueue = new PriorityQueue<string, string>();

        // 진입차수가 0인 노드 추가
        foreach (var item in dict)
        {
            if (item.Value.InDegree == 0)
            {
                priorityQueue.Enqueue(item.Key, item.Key);
            }
        }
        
        List<string> answer = new List<string>();   // 결과를 저장할 리스트

        var answerCount = 0;
        
        while (answer.Count < dict.Count)
        {
            bool isCircle = true;
            PriorityQueue<string,string> nextQueue = new PriorityQueue<string,string>();
            while (priorityQueue.Count > 0)
            {
                string item = priorityQueue.Dequeue();
                answer.Add(item);
                answerCount++;
                // 연결된 노드들의 진입 차수 감소
                foreach (var neighbor in dict[item].Edges)
                {
                    dict[neighbor].InDegree--;
                    if (dict[neighbor].InDegree == 0)
                    {
                        isCircle = false;
                        nextQueue.Enqueue(neighbor,neighbor);
                    }
                }
            }

            if (isCircle)
            {
                break;
            }
            
            priorityQueue = nextQueue;
        }

        if (answerCount == dict.Count)
        {
            Console.WriteLine(string.Join("\n", answer));
        }
        else
        {
            Console.WriteLine(-1);
        }
    }
}