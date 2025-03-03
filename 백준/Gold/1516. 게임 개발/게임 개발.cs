using System.Text;

public class Starter
{
    class Element
    {
        public Element(int buildTime, HashSet<int> parent)
        {
            BuildTime = buildTime;
            Parent = parent;
        }
        
        public int Value { get; set; }
        public int BuildTime{get;set;}
        public HashSet<int> Parent{get;set;}
        public int BiggestParent{get;set;}
    }
    
    public static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        
        PriorityQueue<Element, int> queue = new PriorityQueue<Element, int>();
        
        HashSet<Element> set = new HashSet<Element>();
        for (int i = 1; i <= N; i++)
        {
            string[] input = Console.ReadLine().Split();
            
            int buildTime = int.Parse(input[0]);
            HashSet<int> parent = new HashSet<int>();
            
            int index = 1;
            while (input[index] != "-1")
            {
                int inDegree = int.Parse(input[index]);
                parent.Add(inDegree);
                index++;
            }
            
            Element element = new Element(buildTime, parent);
            element.Value = i;
            element.BiggestParent = 0;
            // queue.Enqueue(element, element.Value);
            set.Add(element);
        }

        // Console.WriteLine();

        int[] values = new int[N+1];
        
        while (set.Count > 0)
        {
            foreach (var element in set)
            {
                if (element.Parent.Count == 0)
                {
                    queue.Enqueue(element, element.Value);
                    set.Remove(element);
                }
            }
            
            while (queue.Count > 0)
            {
                Element current = queue.Dequeue();
                // Console.WriteLine($"{current.Value} : Parent = {current.BiggestParent}");

                values[current.Value] = current.BuildTime + current.BiggestParent;
                foreach (var element in set)
                {
                    if (element.Parent.Contains(current.Value))
                    {
                        element.Parent.Remove(current.Value);
                        if (element.BiggestParent < values[current.Value])
                        {
                            element.BiggestParent = values[current.Value];
                        }
                    }
                }
            }
        }

        // Console.WriteLine();
        StringBuilder answer = new StringBuilder();
        for (int i = 1; i <= N; i++)
        {
            answer.Append(values[i]).Append("\n");
        }
        Console.WriteLine(answer.ToString().TrimEnd('\n'));
    }
}