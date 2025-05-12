public class Starter
{
    public static void Main(string[] args)
    {
        int caseCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < caseCount; i++)
        {
            bool yesOrNo = false;
            int numberCount = int.Parse(Console.ReadLine());

            var phoneNumbers = new List<string>();

            for (int j = 0; j < numberCount; j++)
            {
                string phoneNumber = Console.ReadLine();

                phoneNumbers.Add(phoneNumber);
            }
            phoneNumbers.Sort();
            
            for (int j = 0; j < phoneNumbers.Count-1; j++)
            {
                string current = phoneNumbers[j];
                string next = phoneNumbers[j+1];

                int minLength = Math.Min(current.Length, next.Length);
                
                bool isSame = true;
                for (int k = minLength - 1; k >= 0; k--)
                {
                    if(current[k] == next[k])
                        continue;
                    
                    isSame = false;
                    break;
                }

                if (isSame)
                {
                    yesOrNo = true;
                    break;
                }
            }
            
            if (yesOrNo)
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");
        }
    }
}