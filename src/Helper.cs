namespace ProjectEuler;

public static class Helper
{
    public static bool IsPrime(long number)
    {
        for (long i = 1; i < Math.Sqrt(number); i++)
        {
            if (number % i == 0 && i != 1 && i != number)
            {
                return false;
            }
        }

        return true;
    }
}
