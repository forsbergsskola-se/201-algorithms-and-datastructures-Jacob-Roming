namespace fibonacci;

public class fibonacciRecursive
{
    public static int Fib(int input)
    {
        if (input == 0)
        {
            return 0;
        }
        if (input == 1)
        {
            return 1;
        }

        return Fib(input - 1) + Fib(input - 2);
    }

    public static int FibIterative(int input)
    {
        int oldestNumber;
        int olderNumber = 0;
        int currentNumber = 1;

        for (int i = 1; i < input ; i++) {

            oldestNumber = olderNumber;
            olderNumber = currentNumber;
            currentNumber = oldestNumber + olderNumber;
        }
        return currentNumber;
    }
}

