public class Starter
{
    class Delivery
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Cost { get; set; }
        public Delivery(int from, int to, int cost)
        {
            this.From = from;
            this.To = to;
            this.Cost = cost;
        }
    }
    
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();
        int villageCount = int.Parse(input[0]);
        int maxBox = int.Parse(input[1]);
        
        int M = int.Parse(Console.ReadLine());
        List<Delivery> deliveries = new List<Delivery>();

        for (int i = 0; i < M; i++)
        {
            var line = Console.ReadLine().Split();
            int from = int.Parse(line[0]);
            int to = int.Parse(line[1]);
            int cost = int.Parse(line[2]);
            deliveries.Add(new Delivery(from, to, cost));
        }
        
        // 받는 마을 기준으로 오름차순 정렬
        deliveries = deliveries.OrderBy(x => x.To).ThenBy(d => d.From).ToList();

        int[] truck = new int[villageCount + 1];
        int totalDelivered = 0;

        foreach (var box in deliveries)
        {
            int maxLoad = 0;
            // box.From 부터 box.To - 1 까지 구간에서 현재 실린 박스 수 중 최대값 찾기
            for (int i = box.From; i < box.To; i++)
            {
                if(truck[i] > maxLoad)
                    maxLoad = truck[i];
            }

            int available = maxBox - maxLoad;
            int load = Math.Min(available, box.Cost);
            
            // box.From부터 box.To - 1까지 구간에 Load만큼 박스 추가
            for (int i = box.From; i < box.To; i++)
            {
                truck[i] += load;
            }
            
            totalDelivered += load;
        }

        Console.WriteLine($"{totalDelivered}");
    }
}