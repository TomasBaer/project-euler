namespace ProjectEuler.Problems;

public class Problem00003 : IProblem
{
    public long Limit => 600_851_475_143;

    public string Question => $"What is the largest prime factor of the number {Limit}?";

    public string Solve()
    {
        for (long i = 2; i < Limit; i++)
        {
            double factor = (double)Limit / (double)i;
            if (factor % 1 == 0)
            {
                long factorInt = (long)factor;

                if (Helper.IsPrime(factorInt))
                {
                    return factor.ToString();
                }
            }
        }

        return "No prime factors found.";
    }
}
