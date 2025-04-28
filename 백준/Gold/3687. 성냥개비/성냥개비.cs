using System.Text;

public class Starter
{
    public static void Main(string[] args)
    {
        int caseCount = int.Parse(Console.ReadLine());
        
        long[] dp = new long[101];
        int[] num = new int[]{0,0,1,7,4,2,0,8};
        dp[1] = 9; 
        dp[2] = 1; 
        dp[3] = 7; 
        dp[4] = 4; 
        dp[5] = 2; 
        dp[6] = 6; 
        dp[7] = 8;
        for (int i = 8; i < 101; i++)
        {
            for (int j = 2; j < 8; j++)
            {
                if(dp[i] == 0)
                    dp[i] = long.MaxValue;
                dp[i] = Math.Min(dp[i], dp[i-j]*10 + num[j]);
            }
        }
        
        
        for (int i = 0; i < caseCount; i++)
        {
            int matches = int.Parse(Console.ReadLine());
            
            StringBuilder max = new StringBuilder();
            if (matches % 2 == 1)
                max.Append("7");
            else
                max.Append("1");
            for (int j = 0; j < matches/2-1; j++)
            {
                max.Append("1");
            }

            Console.WriteLine($"{dp[matches]} {max}");
        }
    }
}