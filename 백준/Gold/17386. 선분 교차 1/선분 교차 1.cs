public class Starter
{
    public class Position
    {
        public long x { get; set; }
        public long y { get; set; }
    
        public Position(long x1, long y1)
        {
            x = x1;
            y = y1;
        }
    }

    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        long x1 = long.Parse(input[0]);
        long y1 = long.Parse(input[1]);
        long x2 = long.Parse(input[2]);
        long y2 = long.Parse(input[3]);
        Position p1 = new Position(x1, y1);
        Position p2 = new Position(x2, y2);

        input = Console.ReadLine().Split();
        long x3 = long.Parse(input[0]);
        long y3 = long.Parse(input[1]);
        long x4 = long.Parse(input[2]);
        long y4 = long.Parse(input[3]);
        Position p3 = new Position(x3, y3);
        Position p4 = new Position(x4, y4);
        
        bool isCrossed = isCross(p1, p2, p3, p4);
        if (isCrossed)
            Console.WriteLine(1);
        else
            Console.WriteLine(0);
    }
    
    public static int Ccw(Position pos1, Position pos2, Position pos3)
    {
        long S = pos1.x * pos2.y + pos2.x * pos3.y + pos3.x * pos1.y;
        S -= pos1.y * pos2.x + pos2.y * pos3.x + pos3.y * pos1.x;

        if (S > 0)
            return 1;
        if (S == 0)
            return 0;
        return -1;
    }

    public static bool isCross(Position pos1, Position pos2, Position pos3, Position pos4)
    {
        int pos123 = Ccw(pos1, pos2, pos3);
        int pos124 = Ccw(pos1, pos2, pos4);
        int pos341 = Ccw(pos3, pos4, pos1);
        int pos342 = Ccw(pos3, pos4, pos2);

        if (pos123 * pos124 == 0 && pos341 * pos342 == 0)
            return false;
        else if(pos123 * pos124 <= 0 && pos342 * pos341 <= 0)
            return true;

        return false;
    }
}