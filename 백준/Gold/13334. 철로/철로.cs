public class RailRoad
{
    class Man
    {
        public int home;
        public int office;
        public Man(int home, int office)
        {
            if (home < office)
            {
                this.home = home;
                this.office = office;
            }
            else
            {
                this.home = office;
                this.office = home;
            }
        }
    }
    
    public static int n;
    public static int d;
    public static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        // 시작점, 도착점
        List<Man> list = new List<Man>();
        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine().Split();
            int a = Convert.ToInt32(input[0]);
            int b = Convert.ToInt32(input[1]);
            
            Man man = new Man(a, b);
            list.Add(man);
        }
        
        list.Sort((a,b) => a.office.CompareTo(b.office));
        
        d = int.Parse(Console.ReadLine());

        PriorityQueue<Man,int> trail = new PriorityQueue<Man, int>();
        int count = 0;
        foreach (Man man in list)
        {
            trail.Enqueue(man,man.home);
            while (trail.Count > 0 && trail.Peek().home < man.office - d)
            {
                trail.Dequeue();
            }
            count = Math.Max(count,trail.Count);
        }

        Console.WriteLine(count);
    }
}