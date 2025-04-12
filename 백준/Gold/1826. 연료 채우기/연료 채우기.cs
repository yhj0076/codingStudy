public class Starter
{
    public static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());

        // 1km/L
        
        PriorityQueue<(int,int), int> GasStaions = new PriorityQueue<(int,int), int>();
        // [주유소 정보, 주유소 위치]

        int fullFuel = 0;
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split();
            int pos = Convert.ToInt32(input[0]);
            int gas = Convert.ToInt32(input[1]);
            fullFuel += gas;
            GasStaions.Enqueue((pos, gas) ,pos);
        }

        string[] UserInfo = Console.ReadLine().Split();
        int LeftDistance = Convert.ToInt32(UserInfo[0]);
        int LeftFuel = Convert.ToInt32(UserInfo[1]);
        GasStaions.Enqueue((LeftDistance, 0),LeftDistance);
        if (LeftFuel + fullFuel < LeftDistance)
        {
            Console.WriteLine(-1);
            return;
        }
        else if (LeftFuel + fullFuel == LeftDistance)
        {
            Console.WriteLine(N);
            return;
        }

        PriorityQueue<(int, int), int> CanGoStation = new PriorityQueue<(int, int), int>();
        // [주유소 정보, 주유소 충전 가능]
        int stopCount = 0;
        while (GasStaions.Count > 0)
        {
            (int dist, int gas) s_oil = GasStaions.Peek();
            if (LeftFuel >= s_oil.dist)
            {
                s_oil = GasStaions.Dequeue();
                CanGoStation.Enqueue(s_oil, -s_oil.gas);
                // Console.WriteLine($"LeftFuel: {LeftFuel}");
            }
            else
            {
                if (CanGoStation.Count > 0)
                {
                    (int dist, int gas) gasStation = CanGoStation.Dequeue();
                    LeftFuel += gasStation.gas;
                    // Console.WriteLine($"Stop Station: [{gasStation.dist},{gasStation.gas}]");
                    stopCount++;
                    // 정지 1번
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }

        Console.WriteLine(stopCount);
    }
}