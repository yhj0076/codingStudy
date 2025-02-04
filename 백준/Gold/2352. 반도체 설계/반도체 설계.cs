public class Starter
{
    public static Dictionary<int,int> dict = new Dictionary<int,int>();
    public static int nextIndex = 1;
    
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split();
        
        
        dict.Add(0, 0);
        
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(input[i]);
            Find_Between(0,dict.Count-1,num);
            
        }

        Console.WriteLine(dict.Count-1);
    }
    
    public static void Find_Between(int fromIndex, int toIndex, int target)
    {
        if (toIndex - fromIndex > 1)
        {
            int middle = (toIndex + fromIndex) / 2;
            if (dict[middle] < target)
            {
                Find_Between(middle, toIndex, target);
            }
            else
            {
                Find_Between(fromIndex, middle, target);
            }
        }
        else
        {
            if (dict[toIndex] < target)
            {
                dict.Add(nextIndex,target);
                nextIndex++;
            }
            else
            {
                dict[toIndex] = target;
            }
        }
    }
}