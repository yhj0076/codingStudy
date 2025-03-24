using System.Text;

public class Starter
{
    public static void Main(string[] args)
    {
        Dictionary<long,long> results = new Dictionary<long,long>();    // 결과값 저장 Set
        
        int weightCount = int.Parse(Console.ReadLine());
        string[] weightsInput = Console.ReadLine().Split();
        int[] weights = new int[weightCount];
        int maxWeight = 0;
        long index = 0;
        for (int i = 0; i < weightCount; i++)
        {
            weights[i] = int.Parse(weightsInput[i]);
            maxWeight += weights[i];
            if (!results.ContainsValue(weights[i]))
            {
                results.Add(index, weights[i]);
                index++;
            }
        }
        
        int marbleCount = int.Parse(Console.ReadLine());
        string[] marblesInput = Console.ReadLine().Split();
        int[] marbles = new int[marbleCount];

        
        
        for (int i = 0; i < marbleCount; i++)
        {
            marbles[i] = int.Parse(marblesInput[i]);
        }
        
        #region 기본 배낭 문제 해결법
        // dp[x][y] = max(dp[x-1][y],dp[x-1][y-weight] + weight)

        int[,] dp = new int[maxWeight+1,weightCount];

        for (int i = 0; i <= maxWeight; i++)
        {
            if (i >= weights[0])
            {
                dp[i, 0] = weights[0];
            }
        }
        
        for (int i = 1; i < weightCount; i++)
        {
            for (int j = 1; j <= maxWeight; j++)
            {
                int beforeValue1 = dp[j, i - 1];
                int beforeValue2 = 0;
                if (j - weights[i] <= 0)
                {
                    beforeValue2 = dp[0, i-1] + weights[i];
                }
                else
                {
                    beforeValue2 = dp[j-weights[i], i - 1] + weights[i];
                }
                int max = Math.Max(beforeValue1, beforeValue2);
                if (max <= j)
                {
                    dp[j, i] = max;
                }
                else
                {
                    dp[j, i] = beforeValue1;
                }

                if (!results.ContainsValue(max))
                {
                    results.Add(index,max);
                    index++;
                }
            }
        }
        #endregion

        bool Break = false;
        long limit = index;
        for (int i = 0; i < limit && !Break; i++)
        {
            Break = true;
            long minusValue = results[i];
            for (int j = 0; j < limit; j++)
            {
                if (results[j] - minusValue > 0)
                {
                    Break = false;
                    if (!results.ContainsValue(results[j] - minusValue))
                    {
                        results.Add(index, results[j] - minusValue);
                        index++;
                    }
                }
            }
        }

        StringBuilder sb = new StringBuilder();
        foreach (var marble in marbles)
        {
            if (results.ContainsValue(marble))
            {
                sb.Append("Y ");
            }
            else
            {
                sb.Append("N ");
            }
        }

        Console.WriteLine(sb.ToString().TrimEnd());
    }
}