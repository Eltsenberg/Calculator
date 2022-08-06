static class calculator
{
    private static void Main(string[] args)
    {
        string? arguments;
        var stack = new Stack<double>();
        Console.WriteLine("Enter the expression");
        Console.WriteLine("Info:\n" + "Summation: +\n" + 
                          "Subtraction: -\n" +
                          "Division: /\n" + 
                          "Multiplication: *\n" +
                          "Exponentiation: ^\n" +
                          "Find out the root: Sqrt\n" +
                          "Percent: -%, +%");

        while ((arguments = Console.ReadLine()) != "exit")
        {
            var isNum = double.TryParse(arguments, out var num);
            if (isNum)
                stack.Push(num);
            else
            {
                double operator2;
                switch (arguments)
                {
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case "-":
                        operator2 = stack.Pop();
                        stack.Push(stack.Pop() - operator2);
                        break;
                    case "/":
                        operator2 = stack.Pop();
                        if (operator2 != 0.0)
                            stack.Push(stack.Pop() / operator2);
                        else
                            Console.WriteLine("Error. Division by zero");
                        break;
                    case "Sqrt":
                        stack.Push(Math.Sqrt(stack.Pop()));
                        break;
                    case "^":
                        operator2 = stack.Pop();
                        stack.Push(Math.Pow(stack.Pop(), operator2));
                        break;
                    case "-%":
                        operator2 = stack.Pop();
                        stack.Push(stack.Peek() - stack.Pop() * (operator2 / 100));
                        break;
                    case "+%":
                        operator2 = stack.Pop();
                        stack.Push(stack.Peek() + stack.Pop() / 100 * operator2);
                        break;
                    case "=":
                        Console.WriteLine("Calculation result: " + stack.Pop());
                        break;
                    default:
                        Console.WriteLine("Error, unknown command!");
                        break;
                }
            }
        }
    }
}