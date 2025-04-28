using System.Text;

public class Starter
{
    public static void Main(string[] args)
    {
        string method = Console.ReadLine();
        
        Stack<char> operatorStack = new Stack<char>();
        StringBuilder newMethod = new StringBuilder();
        for (int i = 0; i < method.Length; i++)
        {
            if (method[i] > 64 && method[i] < 91)
            {
                newMethod.Append(method[i]);
                continue;
            }

            switch (method[i])
            {
                case '(':
                {
                    operatorStack.Push(method[i]);
                    break;
                }
                case ')':
                {
                    while (operatorStack.Peek() != '(')
                    {
                        newMethod.Append(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                    break;
                }
                case '*':
                case '/':
                {
                    if (operatorStack.Count > 0)
                    {
                        while (operatorStack.Peek() == '*' ||
                               operatorStack.Peek() == '/' )
                        {
                            newMethod.Append(operatorStack.Pop());
                            if (operatorStack.Count == 0)
                                break;
                        }
                    }
                    operatorStack.Push(method[i]);
                    break;
                }
                case '+':
                case '-':
                {
                    if (operatorStack.Count > 0)
                    {
                        while (operatorStack.Peek() == '*' ||
                               operatorStack.Peek() == '/' ||
                               operatorStack.Peek() == '+' ||
                               operatorStack.Peek() == '-')
                        {
                            newMethod.Append(operatorStack.Pop());
                            if (operatorStack.Count == 0)
                                break;
                        }
                    }
                    operatorStack.Push(method[i]);
                    break;
                }
            }
        }
        while (operatorStack.Count > 0)
        {
            newMethod.Append(operatorStack.Pop());
        }
        Console.WriteLine(newMethod.ToString());
    }
}