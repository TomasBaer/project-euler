namespace ProjectEuler.Problems;

public class Problem00001 : IProblem
{
    public int Limit => 1_000;

    public string Question => $"Find the sum of all the multiples of 3 or 5 below {Limit}.";

    public string Solve()
    {
        long sum = 0;

        for (int i = 1; i < Limit; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += (long)i;
            }
        }

        return sum.ToString();
    }
}
