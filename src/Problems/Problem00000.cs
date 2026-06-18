namespace ProjectEuler.Problems;

public class Problem00000 : IProblem
{
    public long Limit => 245_000;

    public string Question => $"Among the first {Limit} square numbers, what is the sum of all the odd squares?";

    public string Solve()
    {
        long sum = 0;

        for (int i = 1; i <= Limit; i++)
        {
            long square = (long)i * i;

            if (square % 2 == 1)
            {
                sum += square;
            }
        }

        return sum.ToString();
    }
}
